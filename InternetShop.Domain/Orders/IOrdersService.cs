using InternetShop.Domain.Orders.Dto;

namespace InternetShop.Domain.Orders;

public interface IOrdersService
{
    Task<int> CreateOrderAsync(CreateOrderDto request);
    
    Task DeclineOrderAsync(int orderId);
}