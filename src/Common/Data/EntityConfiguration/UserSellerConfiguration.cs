using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfiguration;

public class UserSellerConfiguration : IEntityTypeConfiguration<UserSeller>
{
    public void Configure(EntityTypeBuilder<UserSeller> builder)
    {
        builder.ToTable("UserSellers");
        builder.HasKey(x => x.UserSellerId);

        builder.Property(x => x.UserSellerId)
            .IsRequired()
            .HasColumnName("UserSellerId")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.UserId)
            .IsRequired()
            .HasColumnName("UserId");

        builder.Property(x => x.TaxNumber)
            .IsRequired()
            .HasColumnName("TaxNumber")
            .HasMaxLength(40);

        builder.Property(x => x.TaxOffice)
            .IsRequired()
            .HasColumnName("TaxOffice")
            .HasMaxLength(120);

        builder.HasOne(x => x.User)
            .WithOne(x => x.UserSeller)
            .HasForeignKey<UserSeller>(x => x.UserId);
    }
}