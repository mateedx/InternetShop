using InternetShop.Domain.Categories.Dto;

namespace InternetShop.Domain.Categories;

public interface ICategoriesService
{
    Task<int> CreateCategoryAsync(CreateCategoryDto request);

    Task UpdateCategoryForProduct(UpdateCategoryDto request);

    Task AddCategoryVariation(CategoryVariationDto request);
    
    Task UpdateCategoryVariation(CategoryDto request);

    Task DeleteCategoryVariation(int id);
    
    Task DeleteCategory(int id);

}