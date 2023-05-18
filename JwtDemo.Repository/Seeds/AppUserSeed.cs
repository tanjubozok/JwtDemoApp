using JwtDemo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwtDemo.Repository.Seeds;

public class AppUserSeed : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasData(new AppUser[]
        {
            new()
            {
                Id=1,
                Username="admin",
                Password="123456",
                FullName="Admin"
            },
            new()
            {
                Id=2,
                Username="member",
                Password="123456",
                FullName="Member"
            },
        });
    }
}
