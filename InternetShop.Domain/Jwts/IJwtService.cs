using System.Security.Claims;
using InternetShop.Domain.Jwts.Dto;

namespace InternetShop.Domain.Jwts;

public interface IJwtService
{
    string CreateToken(JwtUserDto userModel);

    JwtUserDto? GetUser(ClaimsPrincipal user);
}