using System.IdentityModel.Tokens.Jwt;
using System.Text;
using InternetShop.Domain.Jwts;
using InternetShop.Domain.Users;
using InternetShop.Services;
using InternetShop.Services.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace InternetShop.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthorization();

        services.AddSingleton<JwtSecurityTokenHandler>();

        var jwtConfig = configuration.GetSection("Jwt").Get<JwtConfiguration>()!;
        services.AddSingleton(jwtConfig);

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key));

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = true
                };
            });
    }
}