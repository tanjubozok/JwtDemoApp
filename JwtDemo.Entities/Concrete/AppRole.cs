using JwtDemo.Entities.Abstract;

namespace JwtDemo.Entities.Concrete;

public class AppRole : IBaseEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public List<AppUserRole>? AppUserRoles { get; set; }
}
