using System;
using System.Linq;

using Geode.Data;
using Geode.Models;

namespace Geode.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GeodeContext context)
        {
            // Create the database if needed
            context.Database.EnsureCreated();

            // Check if the db is already seeded
            if (context.Blocks.Any()) return;

            // Add initial blocks
            context.Blocks.AddRange(new Block[] {
                new Block("Test Block 1", "Geode.Web.Blocks.Cms.HtmlContentDetail, Geode.Web"),
                new Block("Test Block 2", "Geode.Web.Blocks.Cms.HtmlContentDetail, Geode.Web"),
                new Block("Test Block 3", "Geode.Web.Blocks.Cms.HtmlContentDetail, Geode.Web")
            });

            // Save changes
            context.SaveChanges();

        }
    }
}
