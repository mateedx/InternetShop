using InternetShop.Database;
using InternetShop.Database.Entities;
using InternetShop.Database.Enums;
using InternetShop.Database.Exceptions;
using InternetShop.Domain.Orders;
using InternetShop.Domain.Orders.Dto;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Services;

public class OrderService :IOrdersService
{
    private readonly InternetShopDbContext _context;

    public OrderService(InternetShopDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> CreateOrderAsync(CreateOrderDto orderDto)
    {
      var cart = await _context.Carts.Include(i => i.ProductVariations).FirstOrDefaultAsync(f => f.UserId == orderDto.UserId);

      if (cart == null)
          throw new NotFoundException($"Cart was not found");
      
      if (cart.ProductVariations.Count <= 0)
          throw new CartEmptyException($"There are no products in cart");

      var order = new Order
      {
          CreatedAt = DateTime.Now,
          UserId = orderDto.UserId,
          Status = OrderStatus.Created,
          OrderProducts = cart.ProductVariations.Select(s => new OrderProduct
          {
              Price = s.Price,
              ProductVariation = s,
              Status = OrderProductStatus.Created
          }).ToArray(),
          DeliveryAdress = orderDto.DeliveryAdress,
      };
      await _context.Orders.AddAsync(order);
      cart.ProductVariations = [];
      await _context.SaveChangesAsync();
      return order.Id;
    }

    public async Task DeclineOrderAsync(int orderId) 
    {
        var order = await _context.Orders.FirstOrDefaultAsync(f => f.Id == orderId); //лежит заказ. 
        
        order.Status = OrderStatus.Canceled;
        order.ClosedAt = DateTime.Now;
        
        await _context.SaveChangesAsync();
    }
    
}