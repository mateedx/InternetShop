using InternetShop.Database.Enums;

namespace InternetShop.Domain.Orders.Dto;

public class CreateOrderDto
{
    public DateTime CreatedAt { get; set; }
    
    public int UserId { get; set; }
    
    public string DeliveryAdress { get; set; }
}