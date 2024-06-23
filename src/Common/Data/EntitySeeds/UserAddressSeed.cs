using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitySeeds;

public class UserAddressSeed : IEntityTypeConfiguration<UserAddress>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder.HasData(new List<UserAddress>
        {
            new()
            {
                Id = 1,
                UserId = 1,
                Address = "Yukarıbayır Mh 1775 Sk No:44 Daire:18 Kat:4",
                CityId = 35,
                DistrictId = 471,
                Direction = "Eczane karşısı",
            }
        });
    }
}
