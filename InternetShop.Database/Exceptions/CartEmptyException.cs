namespace InternetShop.Database.Exceptions;

public class CartEmptyException : Exception
{
    public CartEmptyException(string message) : base(message)
    {
    }
}