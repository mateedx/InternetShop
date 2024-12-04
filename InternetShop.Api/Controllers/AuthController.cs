using InternetShop.Api.Contracts.Login;
using InternetShop.Api.Extensions;
using InternetShop.Domain.Jwts;
using InternetShop.Domain.Users;
using InternetShop.Domain.Users.Dto;
using InternetShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AuthController(IUsersService userService, IJwtService jwtService) : ApiBaseController(jwtService)
{   
    /*[HttpPost]
    [AllowAnonymous]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var token = await userService.LoginAsync(request.ToDto());
        return Ok(new LoginResponse(token));
    }
   */
}