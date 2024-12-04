using InternetShop.Database;
using InternetShop.Domain.Carts;
using InternetShop.Domain.Carts.Dto;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Services;

public class CartService : ICartsService
{
    private readonly InternetShopDbContext _context;

    public CartService(InternetShopDbContext context)
    {
        _context = context;
    }

    public async Task AddItemAsync(AddItemDto dto)
    {
        var user = await _context.Users.Include(user => user.Cart).ThenInclude(cart => cart.ProductVariations)
            .FirstOrDefaultAsync(u => u.Id == dto.UserId);
        if (user == null)
            throw new Exception("User not found");

        var product = await _context.ProductVariations.FirstOrDefaultAsync(p => p.Id == dto.ProductId);
        if(product == null)
            throw new Exception("Product not found");
        
        var cart = user.Cart;
        
        var productExistsInCart = cart.ProductVariations.Any(p => p.Id == dto.ProductId);

        if (!productExistsInCart)
        {
            if (product.AvailableCount > 0)
            {
                cart.ProductVariations.Add(product);
                product.AvailableCount -= 1;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Product not available");
            }
        }
        else
        {
            throw new Exception("Product already in cart");
        }
    }

    public async Task RemoveItemAsync(RemoveItemDto dto)
    {
        var cart = await _context.Carts.FirstOrDefaultAsync(f => f.Id == dto.CartId);
        if (cart == null)
            throw new Exception("cart not found");
        var product = await _context.ProductVariations.FirstOrDefaultAsync(p => p.Id == dto.ProductId);
        if (product == null)
            throw new Exception("product not found");

        cart.ProductVariations.Remove(product);
        await _context.SaveChangesAsync();
    }
}

