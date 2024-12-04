using InternetShop.Database.Entities;
using InternetShop.Domain.ProductVariations.Dto;

namespace InternetShop.Domain.Carts.Dto;

public class CartDto
{
    public ICollection<ProductVariationDto> ProductVariations { get; set; } = [];

    

    public int UserId { get; set; }
}