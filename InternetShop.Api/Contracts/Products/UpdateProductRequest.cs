using InternetShop.Domain.Products.Dto;

namespace InternetShop.Api.Contracts.Products;

public class UpdateProductRequest
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int CategoryVariationId { get; set; }

    public UpdateProductVariationDto[] Variations { get; set; }
}