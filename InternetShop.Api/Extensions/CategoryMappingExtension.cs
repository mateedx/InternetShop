using InternetShop.Api.Contracts.Categories;
using InternetShop.Database.Entities;
using InternetShop.Domain.Categories.Dto;

namespace InternetShop.Api.Extensions;

public static class CategoryMappingExtension
{
    public static CreateCategoryDto ToDto(this CreateCategoryRequest request)
    {
        return new CreateCategoryDto
        {
            Name = request.Name,
            Variations = request.Variations
        };
    }
    public static UpdateCategoryDto ToDto(this UpdateCategoryRequest request)
    {
        return new UpdateCategoryDto
        {
            CategoryId = request.CategoryId,
            ProductId = request.ProductId
        };
    }
    public static CategoryVariationDto ToDto(this AddCategoryVariationRequest request)
    {
        return new CategoryVariationDto
        {
            Name = request.Name,
            CategoryId = request.CategoryId
        };
    }
    public static CategoryDto ToDto(this UpdateCategoryVariationRequest request)
    {
        return new CategoryDto
        {
            Name = request.Name,
            Variation = request.Variation
        };
    }
}