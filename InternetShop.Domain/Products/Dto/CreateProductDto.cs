namespace InternetShop.Domain.Products.Dto;

public class CreateProductDto
{
    public string Name { get; set; }

    public string Description { get; set; }


    public int CategoryVariationId { get; set; }

    public CreateProductVariationDto[] Variations { get; set; }
}