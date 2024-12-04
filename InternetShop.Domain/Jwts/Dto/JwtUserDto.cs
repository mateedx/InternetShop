using InternetShop.Database.Enums;

namespace InternetShop.Domain.Jwts.Dto;

public class JwtUserDto(string email, int userId, UserRole userRole)
{
    public string Email { get; } = email;

    public int UserId { get; } = userId;

    public UserRole Role { get; } = userRole;
}