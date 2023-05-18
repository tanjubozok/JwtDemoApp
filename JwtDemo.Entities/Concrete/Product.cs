using JwtDemo.Entities.Abstract;

namespace JwtDemo.Entities.Concrete;

public class Product : IBaseEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}
