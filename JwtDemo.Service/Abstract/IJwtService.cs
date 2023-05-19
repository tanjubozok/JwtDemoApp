using JwtDemo.Entities.Concrete;

namespace JwtDemo.Service.Abstract;

public interface IJwtService
{
    string GenerateToken(AppUser appUser, List<AppRole> appRoles);
}