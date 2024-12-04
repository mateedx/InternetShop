using InternetShop.Database.Enums;

namespace InternetShop.Api.Contracts.Users;

public class RegisterUserRequest
{
    public string Name { get; set; }

    public string Lastname { get; set; }

    public string Email { get; set; }   

    public string PhoneNumber { get; set; } 

    public string Password { get; set; }

    public UserRole Role { get; set; }
}