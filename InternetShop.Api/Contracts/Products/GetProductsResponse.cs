using InternetShop.Domain.Products.Dto;

namespace InternetShop.Api.Contracts.Products;

public class GetProductResponse
{
    public string Name { get; set; }

    public string Description { get; set; }

    public int CategoryVariationId { get; set; }

    public ProductVariationDto[] Variations { get; set; } = [];
}