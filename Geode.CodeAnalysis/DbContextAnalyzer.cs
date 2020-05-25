// <copyright>
// Licensed under the MIT license. See the LICENSE.md file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Geode.CodeAnalysis
{
    /// <summary>
    /// Analyzes DbContexts for common issues.
    /// </summary>
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class DbContextAnalyzer : DiagnosticAnalyzer
    {
        private static readonly DiagnosticDescriptor DbContextMissingDbSetPropertiesRule = new DiagnosticDescriptor(
            "Geode0002",
            "DbContext missing DbSet properties",
            "DbContext '{0}' is missing DbSet properties for the following entities: {1}",
            "Database",
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "Classes that extend DbContext should contain a DbSet property for all models.");

        private static readonly DiagnosticDescriptor DbSetPropertyNameMismatchRule = new DiagnosticDescriptor(
            "Geode0003",
            "Property name mismatch",
            "Property '{0}' should be named '{1}' to match it's type.",
            "Database",
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "Properties should be named after their DbSet model.");

        private static readonly DiagnosticDescriptor DuplicateDbSetPropertyRule = new DiagnosticDescriptor(
            "Geode0004",
            "Duplicate DbSet Property",
            "Property '{0}' has the same DbSet type as property '{1}'. This is most likely a copy-paste error.",
            "Database",
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "The DbSet properties of a DbContext should be unique.");

        /// <inheritdoc/>
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(
            DbContextMissingDbSetPropertiesRule,
            DbSetPropertyNameMismatchRule,
            DuplicateDbSetPropertyRule);

        /// <inheritdoc/>
        public override void Initialize(AnalysisContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze);
            context.EnableConcurrentExecution();
            context.RegisterSyntaxNodeAction(this.AnalyzeNode, SyntaxKind.ClassDeclaration);
            context.RegisterCompilationAction(this.AnalyzeDbContext);
        }

        private void AnalyzeNode(SyntaxNodeAnalysisContext context)
        {
            var classDeclaration = (ClassDeclarationSyntax)context.Node;

            // If it's a DbContext class
            if (classDeclaration.Extends("DbContext"))
            {
                var seenTypes = new Dictionary<string, string>();
                var properties = classDeclaration.GetProperties();
                foreach (var property in properties)
                {
                    // If it's a DbSet<T> property
                    if (
                        property.Type is GenericNameSyntax type
                        && type.Identifier.ValueText == "DbSet"
                        && type.TypeArgumentList.Arguments.Count == 1
                        && type.TypeArgumentList.Arguments.ElementAt(0) is SimpleNameSyntax modelType)
                    {
                        // Check that the property name is the plural of the type name
                        var propertyName = property.Identifier.ValueText;
                        var typeName = modelType.Identifier.ValueText;
                        var expectedName = typeName + "s";
                        if (propertyName != expectedName)
                        {
                            context.ReportDiagnostic(Diagnostic.Create(DbSetPropertyNameMismatchRule, property.GetLocation(), new[] { propertyName, expectedName, typeName }));
                        }

                        // Check that the type name hasn't been seen before in this class
                        if (seenTypes.TryGetValue(typeName, out var previousPropertyName))
                        {
                            context.ReportDiagnostic(Diagnostic.Create(DuplicateDbSetPropertyRule, property.GetLocation(), new[] { propertyName, previousPropertyName }));
                        }
                        else
                        {
                            seenTypes.Add(typeName, propertyName);
                        }
                    }
                }
            }
        }

        private void AnalyzeDbContext(CompilationAnalysisContext context)
        {
            var visitor = new DbContextSymbolsVisitor();
            visitor.Visit(context.Compilation.GlobalNamespace);

            var entities = visitor.EntityExtensions.Select(s => s.Name).ToArray();
            foreach (var dbContext in visitor.DbContextExtensions)
            {
                var dbSets = dbContext
                    .GetMembers()
                    .OfType<IPropertySymbol>()
                    .Select(p => p.Type)
                    .OfType<INamedTypeSymbol>()
                    .Where(t => t.Name == "DbSet" && t.TypeArguments.Length == 1)
                    .Select(t => t.TypeArguments.ElementAt(0).Name)
                    .ToArray();

                var missingEntities = entities.Except(dbSets).ToArray();

                if (missingEntities.Any())
                {
                    foreach (var location in dbContext.Locations)
                    {
                        context.ReportDiagnostic(Diagnostic.Create(DbContextMissingDbSetPropertiesRule, location, new[] { dbContext.Name, string.Join<string>(", ", missingEntities) }));
                    }
                }
            }
        }

        private class DbContextSymbolsVisitor : SymbolVisitor
        {
            public ConcurrentBag<INamedTypeSymbol> DbContextExtensions { get; } = new ConcurrentBag<INamedTypeSymbol>();

            public ConcurrentBag<INamedTypeSymbol> EntityExtensions { get; } = new ConcurrentBag<INamedTypeSymbol>();

            public override void VisitNamespace(INamespaceSymbol symbol)
            {
                // Visit each child Type/Namespace
                Parallel.ForEach(symbol.GetMembers(), s => s.Accept(this));
            }

            public override void VisitNamedType(INamedTypeSymbol symbol)
            {
                var baseType = symbol.BaseType;
                if (baseType != null)
                {
                    if (baseType.Name == "DbContext")
                    {
                        this.DbContextExtensions.Add(symbol);
                    }
                    else if (baseType.Name == "Entity")
                    {
                        this.EntityExtensions.Add(symbol);
                    }
                }

                // Visit each child Type
                Parallel.ForEach(symbol.GetTypeMembers(), s => s.Accept(this));
            }
        }
    }
}
