namespace InternetShop.Services.Configuration;

public class JwtConfiguration
{
    public TimeSpan LifeTime { get; set; }

    public string Key { get; set; }
}