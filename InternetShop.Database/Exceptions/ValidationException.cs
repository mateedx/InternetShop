namespace InternetShop.Database.Exceptions;

public class ValidationException : BaseClientException
{
    public ValidationException(string message) : base(message)
    {
    }
}