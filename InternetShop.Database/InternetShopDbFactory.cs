using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InternetShop.Database
{
    public class InternetShopDbFactory : IDesignTimeDbContextFactory<InternetShopDbContext>
    {
        public InternetShopDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InternetShopDbContext>();
            optionsBuilder.UseNpgsql("User ID=postgres;Password=123;Host=localhost;Port=5432;Database=InternetShop;Pooling=true;");

            return new InternetShopDbContext(optionsBuilder.Options);
        }
    }
}
