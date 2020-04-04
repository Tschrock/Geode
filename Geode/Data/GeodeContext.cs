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

            modelBuilder.Entity<Block>().ToTable("Block");
        }
    }
}
