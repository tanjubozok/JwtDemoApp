using JwtDemo.Entities.Concrete;
using JwtDemo.Repository.Abstract;
using JwtDemo.Repository.Context;

namespace JwtDemo.Repository.Repositories;

public class AppRoleRepository : BaseRepository<AppRole>, IAppRoleRepository
{
    public AppRoleRepository(DatabaseContext databaseContext)
        : base(databaseContext)
    {
    }
}
