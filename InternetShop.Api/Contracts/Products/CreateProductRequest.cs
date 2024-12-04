using InternetShop.Domain.Products.Dto;

namespace InternetShop.Api.Contracts.Products;

public class CreateProductRequest
{
    public string Name { get; set; }

    public string Description { get; set; }


    public int CategoryVariationId { get; set; }

    public CreateProductVariationDto[] Variations { get; set; }
}