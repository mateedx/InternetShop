using InternetShop.Database.Enums;

namespace InternetShop.Api.Services;

public class JwtUserModel(string email, int userId, UserRole userRole)
{
    public string Email { get; set; } = email;

    public int UserId { get; set; } = userId;

    public UserRole Role { get; } = userRole;
}