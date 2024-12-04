using InternetShop.Database;
using InternetShop.Database.Entities;
using InternetShop.Database.Exceptions;
using InternetShop.Domain.Categories;
using InternetShop.Domain.Categories.Dto;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Services;

public class CategoryService : ICategoriesService
{
    private readonly InternetShopDbContext _context;

    public CategoryService(InternetShopDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateCategoryAsync(CreateCategoryDto categoryDto)
    {
        var category = new Category
        {
            Name = categoryDto.Name,
            Variations = categoryDto.Variations.Select(s => new CategoryVariation
            {
                Name = s.Name,
                CategoryId = s.CategoryId
            }).ToList()
        };
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();

        return category.Id;
    }

    public async Task UpdateCategoryForProduct(UpdateCategoryDto updateDto)
    {
        var product = await _context.Products.FirstOrDefaultAsync(f => f.Id == updateDto.ProductId);

        if (product == null)
            throw new NotFoundException("Product not found");

        product.CategoryVariationId = updateDto.CategoryId;

        await _context.SaveChangesAsync();
    }


    public async Task AddCategoryVariation(CategoryVariationDto categoryDto)
    {
        var category = await _context.Categories.Include(c => c.Variations)
            .FirstOrDefaultAsync(c => c.Id == categoryDto.Id);
        if (category == null)
            throw new NotFoundException("Category not found");

        var categoryVariation = new CategoryVariation
        {
            Name = categoryDto.Name,
            CategoryId = categoryDto.CategoryId
        };
        category.Variations.Add(categoryVariation);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateCategoryVariation(CategoryDto categoryDto)
    {
        var category = await _context.Categories.Include(c=> c.Variations).FirstOrDefaultAsync(f => f.Id == categoryDto.Id);
        if (category == null)
            throw new NotFoundException("category not found");

        category.Variations = categoryDto.Variation.Select(s => new CategoryVariation
        {
            Name = s.Name,
            CategoryId = s.CategoryId
        }).ToArray();
        
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCategoryVariation(int categoryVariationId)
    {
        var subCategory = await _context.CategoryVariations.FirstOrDefaultAsync(f => f.Id == categoryVariationId);
        if (subCategory == null)
            throw new NotFoundException("Category Variation not found");

        _context.CategoryVariations.Remove(subCategory);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCategory(int categoryId)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
        if(category == null)
            throw new NotFoundException("Category not found");
        
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }
}