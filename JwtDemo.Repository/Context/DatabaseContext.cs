using JwtDemo.Entities.Concrete;
using JwtDemo.Repository.Configurations;
using JwtDemo.Repository.Seeds;
using Microsoft.EntityFrameworkCore;

namespace JwtDemo.Repository.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // configurations
        modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
        modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        modelBuilder.ApplyConfiguration(new AppUserRoleConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());

        // seeds
        modelBuilder.ApplyConfiguration(new AppRoleSeed());
        modelBuilder.ApplyConfiguration(new AppUserSeed());
        modelBuilder.ApplyConfiguration(new AppUserRolesSeed());
        modelBuilder.ApplyConfiguration(new ProductSeed());
    }

    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<AppRole> AppRoles { get; set; }
    public DbSet<AppUserRole> AppUserRoles { get; set; }
    public DbSet<Product> Products { get; set; }
}
