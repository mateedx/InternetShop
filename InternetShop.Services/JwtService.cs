using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using InternetShop.Database.Enums;
using InternetShop.Domain.Jwts;
using InternetShop.Domain.Jwts.Dto;
using InternetShop.Services.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace InternetShop.Services;

public class JwtService : IJwtService
{
    private readonly SigningCredentials _credentials;
    private readonly JwtConfiguration _jwtConfiguration;
    private readonly JwtSecurityTokenHandler _tokenHandler;

    public JwtService(JwtConfiguration options, JwtSecurityTokenHandler tokenHandler)
    {
        _jwtConfiguration = options;
        _tokenHandler = tokenHandler;

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Key));
        _credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
    }

    public string CreateToken(JwtUserDto userModel)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Email, userModel.Email),
            new Claim(ClaimTypes.Role, userModel.Role.ToString()),
            new Claim(ClaimTypes.NameIdentifier, userModel.UserId.ToString())
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.Add(_jwtConfiguration.LifeTime),
            SigningCredentials = _credentials
        };

        var token = _tokenHandler.CreateToken(tokenDescriptor);
        return _tokenHandler.WriteToken(token);
    }

    public JwtUserDto? GetUser(ClaimsPrincipal user)
    {
        if (user.Identity?.IsAuthenticated ?? false)
        {
            var claims = user.Claims.ToArray();

            var email = claims.FirstOrDefault(f => f.Type == ClaimTypes.Email)?.Value;
            if (email is null)
                return null;

            var userIdStr = claims.FirstOrDefault(f => f.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userIdStr is null)
                return null;

            var userId = int.Parse(userIdStr);

            var roleStr = claims.FirstOrDefault(f => f.Type == ClaimTypes.Role)?.Value;
            if (roleStr is null)
                return null;

            var role = Enum.Parse<UserRole>(roleStr);

            return new JwtUserDto(email, userId, role);
        }

        return null;
    }
}