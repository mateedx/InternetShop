using InternetShop.Api.Contracts.Carts;
using InternetShop.Domain.Carts.Dto;

namespace InternetShop.Api.Extensions;

public static class CartMappingExtension
{
    public static AddItemDto ToDto(this AddItemRequest request)
    {
        return new AddItemDto
        {
            UserId = request.UserId,
            ProductId = request.ProductId,
        };
    }

    public static RemoveItemDto ToDto(this RemoveItemRequest request)
    {
        return new RemoveItemDto
        {
            CartId = request.CartId,
            ProductId = request.ProductId,
        };
    }
}