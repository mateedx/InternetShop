using InternetShop.Domain.Jwts;
using InternetShop.Domain.Jwts.Dto;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Api.Controllers;

public class ApiBaseController(IJwtService jwtService) : ControllerBase
{
    protected JwtUserDto? GetUser() => jwtService.GetUser(User);

    protected int? GetUserId() => jwtService.GetUser(User)?.UserId;
}