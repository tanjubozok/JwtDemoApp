using JwtDemo.DTOs.Abstract;

namespace JwtDemo.DTOs.ProductDtos;

public class ProductListDto : IBaseDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsActive { get; set; }
    public bool Status { get; set; }
}