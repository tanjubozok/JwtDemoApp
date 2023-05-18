using JwtDemo.Entities.Abstract;
using JwtDemo.Repository.Abstract;
using JwtDemo.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JwtDemo.Repository.Repositories;

public class BaseRepository<T> : IBaseRepository<T>
    where T : class, IBaseEntity, new()
{
    protected readonly DatabaseContext _databaseContext;
    private readonly DbSet<T> _table;

    public BaseRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
        _table = _databaseContext.Set<T>();
    }

    public async Task Add(T entity)
        => await _table.AddAsync(entity);

    public void Delete(T entity)
        => _table.Remove(entity);

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null)
        => expression is null
        ? await _table.AsNoTracking().ToListAsync()
        : await _table.Where(expression).AsNoTracking().ToListAsync();

    public async Task<T?> GetByIdAsync(object id)
        => await _table.FindAsync(id);

    public async Task<T?> GetOneAsync(Expression<Func<T, bool>> expression)
        => expression is null
        ? await _table.AsNoTracking().FirstOrDefaultAsync()
        : await _table.Where(expression).AsNoTracking().FirstOrDefaultAsync();

    public void Update(T entity)
        => _table.Update(entity);
}
