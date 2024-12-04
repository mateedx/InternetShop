using System.Security.Claims;

namespace InternetShop.Api.Services;

public interface IJwtService
{
    string CreateToken(JwtUserModel userModel);

    JwtUserModel? GetUser(ClaimsPrincipal user);
}