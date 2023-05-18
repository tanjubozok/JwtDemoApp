using JwtDemo.Entities.Concrete;
using JwtDemo.Repository.Abstract;
using JwtDemo.Repository.Context;

namespace JwtDemo.Repository.Repositories;

public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
{
    public AppUserRepository(DatabaseContext databaseContext)
        : base(databaseContext)
    {
    }
}
