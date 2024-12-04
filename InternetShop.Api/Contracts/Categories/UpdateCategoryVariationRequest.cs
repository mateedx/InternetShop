using InternetShop.Domain.Categories.Dto;

namespace InternetShop.Api.Contracts.Categories;

public class UpdateCategoryVariationRequest
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public CategoryVariationDto[] Variation { get; set; } = [];
}