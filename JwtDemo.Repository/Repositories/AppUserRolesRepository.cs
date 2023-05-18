using JwtDemo.Entities.Concrete;
using JwtDemo.Repository.Abstract;
using JwtDemo.Repository.Context;

namespace JwtDemo.Repository.Repositories;

public class AppUserRolesRepository : BaseRepository<AppUserRole>, IAppUserRolesRepository
{
    public AppUserRolesRepository(DatabaseContext databaseContext)
        : base(databaseContext)
    {
    }
}
