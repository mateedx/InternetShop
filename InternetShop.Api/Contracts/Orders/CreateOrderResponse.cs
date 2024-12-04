namespace InternetShop.Api.Contracts.Orders;

public class CreateOrderResponse
{
    public int Id { get; }
    
    public CreateOrderResponse(int id)
    {
        Id = id;
    }
}