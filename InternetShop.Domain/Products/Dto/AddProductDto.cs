using InternetShop.Database.Entities;

namespace InternetShop.Domain.Products.Dto;

public class AddProductDto
{
    public string Name { get; set; }

    public string Description { get; set; }

    public CategoryVariation CategoryVariation { get; set; }

    public int CategoryId { get; set; }
}