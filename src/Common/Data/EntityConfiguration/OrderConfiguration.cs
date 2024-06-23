using Core.Entities;
using Core.Enums.EntityEnums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfiguration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Order");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .IsRequired()
            .HasIdentityOptions(1_000_000_000, 1)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.UserId)
            .HasColumnName("UserId")
            .IsRequired();

        builder.Property(x => x.TotalPrice)
            .HasColumnName("TotalPrice")
            .IsRequired();

        builder.Property(x => x.OrderStatus)
            .HasColumnName("OrderStatus")
            .HasDefaultValue(OrderStatusType.Created)
            .IsRequired();
    }
}
