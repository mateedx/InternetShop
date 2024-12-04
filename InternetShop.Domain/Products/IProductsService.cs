using InternetShop.Domain.Products.Dto;

namespace InternetShop.Domain.Products;

public interface IProductsService
{
    Task<int> CreateProductAsync(CreateProductDto request); //создать продукт
    
    Task UpdateProductAsync(UpdateProductDto request); //изменить продукт
    
    Task AddProductVariationAsync(AddProductVariationDto request); //добавить вариацию продукта

    Task<ProductDto?> GetProductAsync(int id); //получить продукт по айди
    
    Task DeleteProductAsync(int id); //удалить продукт
    
    Task DeleteProductVariationAsync(int id); //удалить вариацию продукта

    Task<ProductDto[]> GetProductsByCategoryAsync(int id); //получить все продукты по категории
    
    Task UpdateProductVariationAsync(UpdateProductVariationDto request);
    
}