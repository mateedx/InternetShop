using InternetShop.Api.Contracts.Carts;
using InternetShop.Api.Extensions;
using InternetShop.Domain.Carts;
using InternetShop.Domain.Categories;
using InternetShop.Domain.Jwts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class CartsController(ICartsService cartsService, IJwtService jwtService) : ApiBaseController(jwtService)
{
    [HttpPost]
    [Route("additem")]
    public async Task<IActionResult> AddItem(AddItemRequest request)
    {
    await cartsService.AddItemAsync(request.ToDto());
    return Ok();
    }
    
    [HttpDelete]
    [Route("deleteitem")]
    public async Task<IActionResult> RemoveItem(RemoveItemRequest request)
    {
        await cartsService.RemoveItemAsync(request.ToDto());
        return Ok();
    }
}