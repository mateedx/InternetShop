using InternetShop.Database.Entities;
using InternetShop.Domain.Carts.Dto;
using InternetShop.Domain.Products.Dto;

namespace InternetShop.Domain.Carts;

public interface ICartsService
{
 Task AddItemAsync(AddItemDto request);
 
 Task RemoveItemAsync(RemoveItemDto request);
}