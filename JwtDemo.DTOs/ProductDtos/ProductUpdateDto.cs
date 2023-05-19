using JwtDemo.DTOs.Abstract;

namespace JwtDemo.DTOs.ProductDtos;

public class ProductUpdateDto : IBaseDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime UpdatedDate { get; set; }
}