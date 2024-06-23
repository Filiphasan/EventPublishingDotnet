using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitySeeds;

public class CitySeed : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasData(new List<City>
        {
            new()
            {
                Id = 35,
                Name = "İzmir",
            }
        });
    }
}
