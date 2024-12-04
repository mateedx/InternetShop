using InternetShop.Domain.Categories.Dto;

namespace InternetShop.Api.Contracts.Categories;

public class CreateCategoryRequest
{
    public string Name { get; set; }
    
    public CategoryVariationDto[] Variations { get; set; }
}