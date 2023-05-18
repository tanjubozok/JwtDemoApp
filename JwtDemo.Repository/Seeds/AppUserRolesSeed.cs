using JwtDemo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwtDemo.Repository.Seeds;

public class AppUserRolesSeed : IEntityTypeConfiguration<AppUserRole>
{
    public void Configure(EntityTypeBuilder<AppUserRole> builder)
    {
        builder.HasData(new AppUserRole[]
        {
            new()
            {
                Id = 1,
                AppRoleId = 1,
                AppUserId = 1,
            },
            new()
            {
                Id= 2,
                AppRoleId = 2,
                AppUserId = 2,
            }
        });
    }
}
