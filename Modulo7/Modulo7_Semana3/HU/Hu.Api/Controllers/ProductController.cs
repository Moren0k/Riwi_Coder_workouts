using Hu.Application.DTOs;
using Hu.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hu.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Add([FromBody] AddProductDto productDto)
    {
        await _productService.AddProductAsync(productDto);
        return Ok(new { message = "Product added successfully" });
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, [FromBody] AddProductDto productDto)
    {
        await _productService.UpdateProductAsync(id, productDto);
        return Ok(new { message = "Product updated successfully" });
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Remove(int id)
    {
        await _productService.RemoveProductAsync(id);
        return Ok(new { message = "Product deleted successfully" });
    }

    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _productService.GetProductAsync(id);
        return Ok(product);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }
}