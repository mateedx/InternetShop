using InternetShop.Domain.Products.Dto;

namespace InternetShop.Domain.Orders.Dto;

public class CartDto
{
    public ProductVariationDto[] ProductsVariationsDto { get; set; } = [];
    
    public int UserId { get; set; }
}