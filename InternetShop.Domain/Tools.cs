using System.Security.Cryptography;
using System.Text;

namespace InternetShop.Domain;

public static class Tools
{
    public static string GetSha256Hash(string password)
    {
        var passBytes = Encoding.UTF8.GetBytes(password);
        var hashBytes = SHA256.HashData(passBytes);
        return Encoding.UTF8.GetString(hashBytes);
    }
}