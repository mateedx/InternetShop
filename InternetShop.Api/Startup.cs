using InternetShop.Api.Extensions;
using InternetShop.Database;
using InternetShop.Services.Extensions;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Api;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen();
        services.AddServices();
        services.AddDbContextPool<InternetShopDbContext>((_, options) =>
            options.UseNpgsql("User ID=postgres;Password=123;Host=localhost;Port=5432;Database=InternetShop;Pooling=true;"));
        services.AddJwtAuthentication(_configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        
        
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1"));
        }
        
        app.UseHttpsRedirection();
        app.UseCors("AllowAll");
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(e => { e.MapControllers(); });
    }
}