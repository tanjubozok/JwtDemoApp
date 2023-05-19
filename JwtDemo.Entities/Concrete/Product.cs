using JwtDemo.Entities.Abstract;

namespace JwtDemo.Entities.Concrete;

public class Product : IBaseEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }
    public bool IsActive { get; set; } = true;
    public bool Status { get; set; } = true;
}
