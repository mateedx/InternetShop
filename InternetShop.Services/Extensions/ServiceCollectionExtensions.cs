using InternetShop.Domain.Carts;
using InternetShop.Domain.Categories;
using InternetShop.Domain.Jwts;
using InternetShop.Domain.Orders;
using InternetShop.Domain.Products;
using InternetShop.Domain.Users;
using Microsoft.Extensions.DependencyInjection;

namespace InternetShop.Services.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUsersService, UserService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IProductsService, ProductService>();
        services.AddScoped<ICategoriesService, CategoryService>();
        services.AddScoped<IOrdersService, OrderService>();
        services.AddScoped<ICartsService, CartService>();
    }
}