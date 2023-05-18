using JwtDemo.Repository.Abstract;
using JwtDemo.Repository.Context;

namespace JwtDemo.Repository.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _databaseContext;

    public UnitOfWork(DatabaseContext databaseContext)
        => _databaseContext = databaseContext;

    public int SaveChanges()
        => _databaseContext.SaveChanges();

    public async Task<int> SaveChangesAsync()
        => await _databaseContext.SaveChangesAsync();
}
