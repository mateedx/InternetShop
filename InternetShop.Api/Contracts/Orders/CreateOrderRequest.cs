namespace InternetShop.Api.Contracts.Orders;

public class CreateOrderRequest
{
    public DateTime CreatedAt { get; set; }
    
    public int UserId { get; set; }
    
    public string DeliveryAdress { get; set; }
}