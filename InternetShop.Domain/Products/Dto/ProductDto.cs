namespace InternetShop.Domain.Products.Dto;

public class ProductDto
{
    public string Name { get; set; }

    public string Description { get; set; }

    public int CategoryVariationId { get; set; }

    public ProductVariationDto[] Variations { get; set; } = [];
}