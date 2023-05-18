namespace JwtDemo.Repository.Abstract;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
    int SaveChanges();
}
