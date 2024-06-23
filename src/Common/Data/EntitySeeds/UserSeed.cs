using Core.Entities;
using Core.Enums.EntityEnums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitySeeds;

public class UserSeed : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(new List<User>
        {
            new()
            {
                Id = 1,
                Name = "Hasan",
                LastName = "Erdal",
                Email = "hasaerda@hotmail.com",
                Password = "",
                UserType = UserType.Purchaser,
                CreatedDate = DateTime.Now,
                UserSeller = null,
            }
        });
    }
}
