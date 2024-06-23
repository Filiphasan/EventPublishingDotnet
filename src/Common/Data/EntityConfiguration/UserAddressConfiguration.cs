using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfiguration;

public class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder.ToTable("UserAddress");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(x => x.UserId)
            .HasColumnName("UserId")
            .IsRequired();
        
        builder.Property(x => x.Address)
            .HasColumnName("Address")
            .HasMaxLength(400)
            .IsRequired();

        builder.Property(x => x.CityId)
            .HasColumnName("CityId")
            .IsRequired();

        builder.Property(x => x.DistrictId)
            .HasColumnName("DistrictId")
            .IsRequired();
        
        builder.Property(x => x.Direction)
            .HasColumnName("Direction")
            .HasMaxLength(240)
            .IsRequired(false);

        builder.HasOne(x => x.User)
            .WithMany(x => x.UserAddresses)
            .HasForeignKey(x => x.UserId);
    }
}