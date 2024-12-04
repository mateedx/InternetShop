using InternetShop.Api.Contracts.Orders;
using InternetShop.Api.Extensions;
using InternetShop.Domain.Jwts;
using InternetShop.Domain.Orders;
using InternetShop.Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class OrdersController(IOrdersService ordersService, IJwtService jwtService) : ApiBaseController(jwtService)
{
    [HttpPost]
    [Route("create-order")]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
    {
        var orderId = await ordersService.CreateOrderAsync(request.ToDto());
        return Ok(new CreateOrderResponse(orderId));
    }

    [HttpPut]
    [Route("decline-order")]
    public async Task<IActionResult> DeclineOrder([FromQuery] DeclineOrderRequest request)
    {
        await ordersService.DeclineOrderAsync(request.Id);
        return Ok();
    }
}