namespace InternetShop.Domain.Categories.Dto;

public class CreateCategoryDto
{
    public string Name { get; set; }
    
    public CategoryVariationDto[] Variations { get; set; }
}

