using JwtDemo.Entities.Concrete;
using JwtDemo.Repository.Abstract;
using JwtDemo.Repository.Context;

namespace JwtDemo.Repository.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(DatabaseContext databaseContext)
        : base(databaseContext)
    {
    }
}
