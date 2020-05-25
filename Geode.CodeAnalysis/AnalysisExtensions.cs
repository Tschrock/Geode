// <copyright>
// Licensed under the MIT license. See the LICENSE.md file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Geode.CodeAnalysis
{
    /// <summary>
    /// A collection of extension methods to simplify code analysis.
    /// </summary>
    public static class AnalysisExtensions
    {
        /// <summary>
        /// Determines whether the <see cref="ClassDeclarationSyntax"/> extends a <see cref="SimpleNameSyntax"/> with the specified name.
        /// </summary>
        /// <param name="classDeclaration">The <see cref="ClassDeclarationSyntax"/> to check.</param>
        /// <param name="simpleTypeName">A <see cref="string"/> that defines the name of the type to search for.</param>
        /// <returns>`true` if the <see cref="ClassDeclarationSyntax"/> extends a type with the specified name; otherwise, `false`.</returns>
        public static bool Extends(this ClassDeclarationSyntax classDeclaration, string simpleTypeName)
        {
            return Extends(classDeclaration, t => t.IsSimpleType(simpleTypeName));
        }

        /// <summary>
        /// Determines whether the <see cref="ClassDeclarationSyntax"/> extends a <see cref="TypeSyntax"/> that matches the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="classDeclaration">The <see cref="ClassDeclarationSyntax"/> to check.</param>
        /// <param name="callback">The delegate that defines the conditions of the elements to search for.</param>
        /// <returns>`true` if the <see cref="ClassDeclarationSyntax"/> extends a type that match the conditions defined by the specified predicate; otherwise, `false`.</returns>
        public static bool Extends(this ClassDeclarationSyntax classDeclaration, Func<TypeSyntax, bool> callback)
        {
            return classDeclaration?.BaseList?.Types.Select(t => t.Type).Any(callback) ?? false;
        }

        /// <summary>
        /// Gets a list of the <see cref="ClassDeclarationSyntax"/>'s property definitions.
        /// </summary>
        /// <param name="classDeclaration">The <see cref="ClassDeclarationSyntax"/> to get the properties for.</param>
        /// <returns>An <see cref="IEnumerable{PropertyDeclarationSyntax}"/> containing the <see cref="ClassDeclarationSyntax"/>'s property definitions.</returns>
        public static IEnumerable<PropertyDeclarationSyntax> GetProperties(this ClassDeclarationSyntax classDeclaration)
        {
            if (classDeclaration == null)
            {
                return Array.Empty<PropertyDeclarationSyntax>();
            }
            else
            {
                return classDeclaration.Members.OfType<PropertyDeclarationSyntax>();
            }
        }

        /// <summary>
        /// Determines whether the <see cref="TypeSyntax"/> is a simple type that matches the specified name.
        /// </summary>
        /// <param name="type">The <see cref="TypeSyntax"/> to check.</param>
        /// <param name="name">The type name.</param>
        /// <returns>`true` if the <see cref="TypeSyntax"/> is a simple type with the specified name; otherwise, `false`.</returns>
        public static bool IsSimpleType(this TypeSyntax type, string name)
        {
            return type is SimpleNameSyntax simpleType && simpleType.Identifier.ValueText == name;
        }

        /// <summary>
        /// Determines whether the <see cref="TypeSyntax"/> is a generic type that matches the specified name and type parameter.
        /// </summary>
        /// <param name="type">The <see cref="TypeSyntax"/> to check.</param>
        /// <param name="name">The type name.</param>
        /// <param name="typeParameter1Matcher">The delegate for checking the first type parameter.</param>
        /// <returns>`true` if the <see cref="TypeSyntax"/> is a generic type that matches the specified criteria; otherwise, `false`.</returns>
        public static bool IsGenericType(this TypeSyntax type, string name, Func<TypeSyntax, bool> typeParameter1Matcher)
        {
            if (typeParameter1Matcher == null)
            {
                throw new ArgumentNullException(nameof(typeParameter1Matcher));
            }

            return type is GenericNameSyntax genericType
             && genericType.Identifier.ValueText == name
             && genericType.TypeArgumentList.Arguments.Count == 1
             && typeParameter1Matcher(genericType.TypeArgumentList.Arguments.ElementAt(0));
        }
    }
}
