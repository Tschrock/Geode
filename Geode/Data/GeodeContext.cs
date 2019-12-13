using Microsoft.EntityFrameworkCore;

using Geode.Models;

namespace Geode.Data
{
    public class GeodeContext : DbContext
    {
        public GeodeContext (DbContextOptions<GeodeContext> options) : base(options)
        {
        }

        public DbSet<Block> Blocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Block>().ToTable("Block");
        }
    }
}
