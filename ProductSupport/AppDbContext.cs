using Microsoft.EntityFrameworkCore;
using ProductSupport.API.Models;
using ProductSupport.Models;

namespace ProductSupport.API
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(p => p.Products)
                .WithOne(c => c.Category)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>()
               .HasMany(p => p.Products)
               .WithOne(c => c.Company)
               .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }


    }
}
