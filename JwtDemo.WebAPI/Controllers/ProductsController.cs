using JwtDemo.DTOs.ProductDtos;
using JwtDemo.Service.Abstract;
using JwtDemo.WebAPI.CustomFilters;
using Microsoft.AspNetCore.Mvc;

namespace JwtDemo.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var data = await _productService.GetAllAsync();
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _productService.GetByIdAsync(id);
        return Ok(data);
    }

    [HttpPost]
    [ValidModel]
    public async Task<IActionResult> Create(ProductAddDto dto)
    {
        var data = await _productService.AddAsync(dto);
        return Created("", data);
    }

    [HttpPut()]
    [ValidModel]
    public IActionResult Edit(ProductUpdateDto dto)
    {
        _productService.Update(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _productService.Delete(id);
        return NoContent();
    }
}
