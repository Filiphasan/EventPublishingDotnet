using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitySeeds;

public class ProductSeed : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(new List<Product>
        {
            new()
            {
                Id = 1,
                Name = "Product 1",
                Price = 99.99m,
                Description = "Product 1 Description",
                Quantity = 1000
            },
            new()
            {
                Id = 1,
                Name = "Product 2",
                Price = 199.99m,
                Description = "Product 2 Description",
                Quantity = 1000
            },
            new()
            {
                Id = 1,
                Name = "Product 3",
                Price = 49.99m,
                Description = "Product 3 Description",
                Quantity = 1000
            },
        });
    }
}
