using InternetShop.Database.Entities;

namespace InternetShop.Domain.ProductVariations.Dto;

public class `ProductVariationDto
{
    public decimal Price { get; set; }

    public int AvailableCount { get; set; }

    public double Size { get; set; }

    public string Type { get; set; }

    public Product Product { get; set; }

    public int ProductId { get; set; }
}