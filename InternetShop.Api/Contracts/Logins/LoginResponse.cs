namespace InternetShop.Api.Contracts.Logins;

public class LoginResponse(string token)
{
    public string Token { get; } = token;   
}