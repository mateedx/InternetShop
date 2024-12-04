namespace InternetShop.Database.Exceptions;

public class NotFoundException : BaseClientException
{
    public NotFoundException(string message) : base(message)
    {
    }
}