using JwtDemo.DTOs.Abstract;

namespace JwtDemo.DTOs.ProductDtos;

public class ProductAddDto : IBaseDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}
