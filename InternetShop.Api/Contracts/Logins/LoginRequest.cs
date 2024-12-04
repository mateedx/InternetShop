using System.ComponentModel.DataAnnotations;

namespace InternetShop.Api.Contracts.Logins;

public class LoginRequest
{
    [Required] public string Email { get; set; }

    [Required] public string Password { get; set; }
}