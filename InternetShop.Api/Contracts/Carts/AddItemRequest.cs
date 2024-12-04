namespace InternetShop.Api.Contracts.Carts;

public class AddItemRequest
{
    public int UserId { get; set; }
    
    public int ProductId { get; set; }
}