// <copyright>
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Linq;

using Geode.Models;

namespace Geode.Data
{
    /// <summary>
    /// Contains utility methods used to initialize the database.
    /// </summary>
    public static class DbInitializer
    {
        /// <summary>
        /// Initializes the database using the given context. Initialization makes sure the database is created, seeded, and updated.
        /// </summary>
        /// <param name="context">The <see cref="GeodeContext"/> to use to initialize the database.</param>
        public static void Initialize(GeodeContext context)
        {
            // Create the database if needed
            context.Database.EnsureCreated();

            // Check if the db is already seeded
            if (context.Blocks.Any())
            {
                return;
            }

            // Add initial blocks
            context.Blocks.AddRange(new Block[] {
                new Block("Test Block 1", "Geode.Web.Blocks.Cms.HtmlContentDetail, Geode.Web"),
                new Block("Test Block 2", "Geode.Web.Blocks.Cms.HtmlContentDetail, Geode.Web"),
                new Block("Test Block 3", "Geode.Web.Blocks.Cms.HtmlContentDetail, Geode.Web"),
            });

            // Save changes
            context.SaveChanges();
        }
    }
}
