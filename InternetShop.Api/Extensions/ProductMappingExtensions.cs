using InternetShop.Api.Contracts.Products;
using InternetShop.Domain.Products.Dto;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Api.Extensions;

public static class ProductMappingExtensions
{
    public static GetProductResponse ToResponse(this ProductDto dto)
    {
        return new GetProductResponse
        {
            Name = dto.Name,
            Description = dto.Description,
            CategoryVariationId = dto.CategoryVariationId,
            Variations = dto.Variations
        };
    }

    public static CreateProductDto ToDto(this CreateProductRequest request)
    {
        return new CreateProductDto()
        {
            Name = request.Name,
            Description = request.Description,
            CategoryVariationId = request.CategoryVariationId,
            Variations = request.Variations
        };
    }

    public static UpdateProductDto ToDto(this UpdateProductRequest request)
    {
        return new UpdateProductDto()
        {
            Name = request.Name,
            Description = request.Description,
            CategoryVariationId = request.CategoryVariationId,
            Variations = request.Variations
        };
    }
    
    public static AddProductVariationDto ToDto(this AddProductVariationRequest request)
    {
        return new AddProductVariationDto
        {
            Price = request.Price,
            AvailableCount = request.AvailableCount,
            Size = request.Size,
            Type = request.Type,
            ProductId = request.ProductId,
        };
    }
    public static UpdateProductVariationDto ToDto(this UpdateProductVariationRequest request)
    {
        return new UpdateProductVariationDto()
        {
            Price = request.Price,
            AvailableCount = request.AvailableCount,
            Size = request.Size,
            Type = request.Type,
            ProductId = request.ProductId,
        };
    }
}