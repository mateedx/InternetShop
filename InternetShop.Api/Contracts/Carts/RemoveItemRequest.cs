namespace InternetShop.Api.Contracts.Carts;

public class RemoveItemRequest
{
    public int CartId { get; set; }

    public int ProductId { get; set; }
}