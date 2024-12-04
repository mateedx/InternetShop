using InternetShop.Api.Contracts.Products;
using InternetShop.Api.Extensions;
using InternetShop.Database.Enums;
using InternetShop.Domain.Jwts;
using InternetShop.Domain.Products;
using InternetShop.Domain.Products.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace InternetShop.Api.Controllers;

[Authorize(Roles = nameof(UserRole.Admin))]
[ApiController]
[Route("[controller]")]
public class ProductsController(IProductsService productService, IJwtService jwtService) : ApiBaseController(jwtService)
{
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
    {
        var productId = await productService.CreateProductAsync(request.ToDto());
        return Ok(new CreateProductResponse(productId));
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest request)
    {
        await productService.UpdateProductAsync(request.ToDto());
        return Ok();
    }

    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> AddProductVariation([FromBody] AddProductVariationRequest request)
    {
        await productService.AddProductVariationAsync(request.ToDto());
        return Ok();
    }

    [HttpGet]
    [AllowAnonymous]
    [Route("get")]
    public async Task<IActionResult> GetProduct([FromQuery] GetProductRequest request)
    {
        var product = await productService.GetProductAsync(request.Id);
        return Ok(product!.ToResponse());
    }

    [HttpGet]
    [AllowAnonymous]
    [Route("get-all")]
    public async Task<IActionResult> GetProducts([FromQuery] GetProductsRequest request)
    {
        var products = await productService.GetProductsByCategoryAsync(request.Id);
        return Ok(products);
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<IActionResult> DeleteProduct([FromQuery] DeleteProductRequest request)
    {
        await productService.DeleteProductAsync(request.Id);
        return Ok();
    }

    [HttpDelete]
    [Route("delete-variation")]
    public async Task<IActionResult> DeleteProductVariation([FromQuery] DeleteProductVariationRequest request)
    {
        await productService.DeleteProductVariationAsync(request.Id);
        return Ok();
    }

    [HttpPut]
    [Route("update-variation")]
    public async Task<IActionResult> UpdateProductVariation([FromBody] UpdateProductVariationRequest request)
    {
        await productService.UpdateProductVariationAsync(request.ToDto());
        return Ok();
    }

}