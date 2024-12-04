using InternetShop.Api.Contracts.Categories;
using InternetShop.Api.Contracts.Orders;
using InternetShop.Api.Extensions;
using InternetShop.Domain.Categories;
using InternetShop.Domain.Jwts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class CategoriesController(ICategoriesService categoriesService, IJwtService jwtService)
    : ApiBaseController(jwtService)
{
    [HttpPost]
    [Route("create-category")]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
    {
        var categoryId = await categoriesService.CreateCategoryAsync(request.ToDto());
        return Ok(new CreateCategoryResponse(categoryId));
    }

    [HttpPut]
    [Route("update-category")]
    public async Task<IActionResult> UpdateCategoryForProduct([FromBody] UpdateCategoryRequest request)
    {
        await categoriesService.UpdateCategoryForProduct(request.ToDto());
        return Ok();
    }

    [HttpPost]
    [Route("add-variation")]
    public async Task<IActionResult> AddCategoryVariation([FromBody]AddCategoryVariationRequest request)
    {
        await categoriesService.AddCategoryVariation(request.ToDto());
        return Ok();
    }

    [HttpPut]
    [Route("update-variation")]
    public async Task<IActionResult> UpdateCategoryVariation([FromBody]UpdateCategoryVariationRequest request)
    {
        await categoriesService.UpdateCategoryVariation(request.ToDto());
        return Ok();
    }

    [HttpDelete]
    [Route("delete-variation")]
    public async Task<IActionResult> DeleteCategoryVariation([FromQuery] int id)
    {
        await categoriesService.DeleteCategoryVariation(id);
        return Ok();
    }
    
    [HttpDelete]
    [Route("delete-category")]
    public async Task<IActionResult> DeleteCategory([FromQuery] int id)
    {
        await categoriesService.DeleteCategory(id);
        return Ok();
    }
}