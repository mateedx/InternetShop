namespace InternetShop.Domain.Products.Dto;

public class UpdateProductDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int CategoryVariationId { get; set; }

    public UpdateProductVariationDto[] Variations { get; set; }
    
}
