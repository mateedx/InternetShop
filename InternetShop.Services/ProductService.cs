using InternetShop.Database;
using InternetShop.Database.Entities;
using InternetShop.Database.Exceptions;
using InternetShop.Domain.Products;
using InternetShop.Domain.Products.Dto;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Services;

public class ProductService : IProductsService
{
    private readonly InternetShopDbContext _context;

    public ProductService(InternetShopDbContext context)
    {
        _context = context;
    }


    public async Task<int> CreateProductAsync(CreateProductDto productDto)
    {
        var product = new Product 
        {
            Name = productDto.Name,
            Description = productDto.Description,
            CategoryVariationId = productDto.CategoryVariationId,
            Variations = productDto.Variations.Select(s => new ProductVariation
            {
                Price = s.Price,
                AvailableCount = s.AvailableCount,
                Size = s.Size,
                Type = s.Type,
                
            }).ToArray() //при создании продукта можно создать много  вариаций продукта 
        };
        
        await _context.AddAsync(product);
        await _context.SaveChangesAsync();
        
        return product.Id;
    }

    public async Task UpdateProductAsync(UpdateProductDto productDto)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productDto.Id);
        
        if(product == null)
            throw new NotFoundException("Product not found");
        
        product.Name = productDto.Name;
        product.Description = productDto.Description;
        product.CategoryVariationId = productDto.CategoryVariationId;
        
         await _context.SaveChangesAsync();
    }

    public async Task AddProductVariationAsync(AddProductVariationDto productVariationDto)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productVariationDto.ProductId);

        if (product == null)
            throw new NotFoundException("Product not found");

        var productVariation = new ProductVariation
        {
            Price = productVariationDto.Price,
            Type = productVariationDto.Type,
            Size = productVariationDto.Size,
            AvailableCount = productVariationDto.AvailableCount,
            ProductId = productVariationDto.ProductId
        };
        
        product.Variations.Add(productVariation);
        
        _context.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task<ProductDto?> GetProductAsync(int id)
    {
        var productDto = await _context.Set<Product>().Where(w => w.Id == id).Select(s => new ProductDto
        {
            Name = s.Name,
            Description = s.Description,
            CategoryVariationId = s.CategoryVariationId,
            Variations = s.Variations.Select(s => new ProductVariationDto
            {
                Price = s.Price,
                AvailableCount = s.AvailableCount,
                Size = s.Size,
                Type = s.Type,
            }).ToArray()
        }).FirstOrDefaultAsync();
        
        return productDto;
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProductVariationAsync(int id)
    {
        var productVariation = _context.ProductVariations.FirstOrDefault(s => s.ProductId == id);
        
        _context.ProductVariations.Remove(productVariation);
        await _context.SaveChangesAsync();
    }

    public async Task<ProductDto[]> GetProductsByCategoryAsync(int categoryId)
    {
        var products =  _context.Set<Product>().Where(p => p.CategoryVariationId == categoryId).Select(s =>
            new ProductDto
            {
                Name = s.Name,
                CategoryVariationId = s.CategoryVariationId,
                Variations = s.Variations.Select(s => new ProductVariationDto
                {
                    Price = s.Price,
                    AvailableCount = s.AvailableCount,
                    Size = s.Size,
                    Type = s.Type
                }).ToArray()
            }).ToArray();
        return products;
    }

    public async Task UpdateProductVariationAsync(UpdateProductVariationDto request)
    {
        var productVariation = await _context.Set<ProductVariation>().Where(w => w.ProductId == request.ProductId).FirstOrDefaultAsync();

        if (productVariation == null)
            throw new NotFoundException($"Product not found");
        {
            productVariation.Price = request.Price;
            productVariation.AvailableCount = request.AvailableCount;
            productVariation.Size = request.Size;
            productVariation.Type = request.Type;
        }

        await _context.SaveChangesAsync();
    }
}