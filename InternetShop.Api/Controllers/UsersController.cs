using InternetShop.Api.Contracts.Logins;
using InternetShop.Api.Contracts.Users;
using InternetShop.Api.Extensions;
using InternetShop.Domain.Jwts;
using InternetShop.Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace InternetShop.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UsersController(IUsersService userService, IJwtService jwtService) : ApiBaseController(jwtService)
{
    [HttpPost]
    [AllowAnonymous]
    [Route("registration")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
    {
        await userService.RegisterAsync(request.ToDto());
        return Ok();
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] DeleteUserRequest request)
    {
        await userService.DeleteAsync(request.Id);
        return Ok();
    }

    [HttpPut]
    [Route("profile")]
    public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileRequest request)
    {
        await userService.UpdateProfileAsync(request.ToDto(GetUserId()!.Value));
        return Ok();
    }

    
    
    [HttpPost]
    [AllowAnonymous]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var token = await userService.LoginAsync(request.ToDto());
        return Ok(new LoginResponse(token));
    }
}