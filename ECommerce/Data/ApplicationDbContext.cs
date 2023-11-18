using ECommerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base (options)
        {
               
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProductSize>()
                .HasKey(p => new { p.ProductId,p.SizeId});
            builder.Entity<ProductSize>()
                .HasOne(p => p.Product)
                .WithMany(p => p.ProductSizes)
                .HasForeignKey(p => p.ProductId);
            builder.Entity<ProductSize>()
                .HasOne(p => p.Size)
                .WithMany(p => p.ProductSizes)
                .HasForeignKey(p => p.SizeId);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
