using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitySeeds;

public class DistrictSeed : IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        builder.HasData(new List<District>
        {
            new()
            {
                Id = 471,
                Name = "Karşıyaka",
                CityId = 35,
            }
        });
    }
}
