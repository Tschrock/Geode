// <copyright>
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;

using Microsoft.EntityFrameworkCore;

using Geode.Models;

namespace Geode.Data
{
    /// <summary>
    /// The DbContext for Geode.
    /// </summary>
    public class GeodeContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeodeContext"/> class.
        /// </summary>
        /// <param name="options">The DbContext options.</param>
        public GeodeContext(DbContextOptions<GeodeContext> options)
        : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the Blocks DbSet.
        /// </summary>
        public DbSet<Block> Blocks { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Layouts DbSet.
        /// </summary>
        public DbSet<Layout> Layouts { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Pages DbSet.
        /// </summary>
        public DbSet<Page> Pages { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Sites DbSet.
        /// </summary>
        public DbSet<Site> Sites { get; set; } = null!;

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            // For every model
            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                // If it's an entity
                if (type.ClrType.IsSubclassOf(typeof(Entity)))
                {
                    // Create a builder
                    var entityBuilder = modelBuilder.Entity(type.ClrType);

                    // Use the singular type name for the table
                    entityBuilder.ToTable(type.ClrType.Name);

                    // Set up default values
                    entityBuilder.Property("Guid").HasDefaultValueSql("newid()");
                    entityBuilder.Property("CreatedDateTime").HasDefaultValueSql("CURRENT_TIMESTAMP");
                    entityBuilder.Property("ModifiedDateTime").HasDefaultValueSql("CURRENT_TIMESTAMP");
                }
            }
        }
    }
}
