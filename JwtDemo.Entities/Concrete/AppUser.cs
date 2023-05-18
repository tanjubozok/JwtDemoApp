using JwtDemo.Entities.Abstract;

namespace JwtDemo.Entities.Concrete;

public class AppUser : IBaseEntity
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? FullName { get; set; }

    public List<AppUserRole>? AppUserRoles { get; set; }
}
