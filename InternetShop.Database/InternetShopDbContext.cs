using InternetShop.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Database
{
    public class InternetShopDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }

        public DbSet<ProductVariation> ProductVariations { get; set; }

        public DbSet<CategoryVariation> CategoryVariations { get; set; }

        public InternetShopDbContext(DbContextOptions<InternetShopDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(p => p.Email).IsRequired();
                entity.Property(p => p.Name).IsRequired();
                entity.Property(p => p.Lastname).IsRequired();
                entity.Property(p => p.Password).IsRequired();
            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(p => p.Name).IsRequired().HasMaxLength(20); //
            });
            modelBuilder.Entity<CategoryVariation>(entity =>
            {
                entity.Property(p => p.Name).IsRequired().HasMaxLength(20);
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(p => p.DeliveryAdress).IsRequired().HasMaxLength(100);
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Name).IsRequired().HasMaxLength(20);
                entity.Property(p => p.Description).IsRequired().HasMaxLength(300);
            });
            modelBuilder.Entity<ProductVariation>(entity =>
            {
                entity.Property(p => p.Type).IsRequired().HasMaxLength(20);
            });
        }
    }
}