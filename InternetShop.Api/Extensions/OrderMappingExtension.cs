using InternetShop.Api.Contracts.Orders;
using InternetShop.Domain.Orders.Dto;

namespace InternetShop.Api.Extensions;

public static class OrderMappingExtension
{
    public static CreateOrderDto ToDto(this CreateOrderRequest request)
    {
        return new CreateOrderDto
        {
            CreatedAt = request.CreatedAt,
            UserId = request.UserId,
            DeliveryAdress = request.DeliveryAdress
        };
    }
}