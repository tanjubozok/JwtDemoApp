using JwtDemo.Entities.Abstract;
using System.Linq.Expressions;

namespace JwtDemo.Repository.Abstract;

public interface IBaseRepository<T>
    where T : class, IBaseEntity, new()
{
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null);
    Task<T?> GetOneAsync(Expression<Func<T, bool>> expression);
    Task<T?> GetByIdAsync(object id);

    Task Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}
