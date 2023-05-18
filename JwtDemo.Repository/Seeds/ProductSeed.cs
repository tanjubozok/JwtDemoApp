using JwtDemo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwtDemo.Repository.Seeds;

public class ProductSeed : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(new Product[]
        {
            new()
            {
                Id= 1,
                Name="Product 1",
                Description="Por kiel auxdis sed agis la sklavo la direktis alteren mi la homoj min karolo grava tre por lia kaj"
            },
            new()
            {
                Id= 2,
                Name="Product 2",
                Description="Ne mi surtere havu barelojn facile greno kaj kaj mi li bonan de objektojn ni alportis se havas iradis renkonti"
            },
            new()
            {
                Id= 3,
                Name="Product 3",
                Description="Por en la ni knabo lauxteron signojn kun lasis sur surboaton malproksime boaton iri ensxipis kvin li estis gastoj ne"
            },
            new()
            {
                Id= 4,
                Name="Product 4",
                Description="Longe nia fisxojn estas sencon boaton vi tio ne kie forkuri helpo boaton jarojn faris mi per la iom por"
            },
        });
    }
}
