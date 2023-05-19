using JwtDemo.DTOs.ProductDtos;
using JwtDemo.Entities.Concrete;
using JwtDemo.Service.Abstract;
using JwtDemo.WebAPI.CustomFilters;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
    [ServiceFilter(typeof(ValidIdAttribute<Product>))]
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
    [ServiceFilter(typeof(ValidIdAttribute<Product>))]
    public IActionResult Delete(int id)
    {
        _productService.Delete(id);
        return NoContent();
    }

    [Route("/error")]
    public IActionResult Error()
    {
        var errorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

        var error = errorInfo?.Error;
        var path = errorInfo?.Path;

        ProblemDetails problemDetails = new()
        {
            Title = "Apide bir hata oluştu",
            Detail = "En kısa sürede düzeltilecektir",
            Status = (int)HttpStatusCode.InternalServerError,
            Instance = path,
            Extensions =
            {
                ["message"] = error?.Message,
                //["data"] = error?.Data,
                //["helpLink"] = error?.HelpLink,
                //["hResult"] = error?.HResult,
                //["innerException"] = error?.InnerException,
                //["source"] = error?.Source,
                //["stackTrace"] = error?.StackTrace,
                //["targetSite"] = error?.TargetSite,
                //["displayName"] = errorInfo?.Endpoint?.DisplayName,
                //["metadata"] = errorInfo?.Endpoint?.Metadata,
                //["requestDelegate"] = errorInfo?.Endpoint?.RequestDelegate,
                //["routeValues"] = errorInfo?.RouteValues
            }
        };

        return StatusCode((int)HttpStatusCode.InternalServerError, problemDetails);

    }
}
