using InternetShop.Database.Enums;
using InternetShop.Domain.Products.Dto;

namespace InternetShop.Domain.Orders.Dto;

public class OrderProductDto
{
    public decimal Price { get; set; }
    
    public ProductVariationDto ProductVariation { get; set; }
    
    public double? Discount { get; set; }
    
    public OrderProductStatus Status { get; set; }

    public CartDto Cart { get; set; }
}