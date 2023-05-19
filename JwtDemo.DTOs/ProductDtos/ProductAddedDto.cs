using JwtDemo.DTOs.Abstract;

namespace JwtDemo.DTOs.ProductDtos;

public class ProductAddedDto : IBaseDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public bool Status { get; set; }
}
