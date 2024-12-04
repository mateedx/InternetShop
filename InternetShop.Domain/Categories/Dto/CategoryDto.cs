using InternetShop.Database.Entities;

namespace InternetShop.Domain.Categories.Dto;

public class CategoryDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public CategoryVariationDto[] Variation { get; set; } = [];
}