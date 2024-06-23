using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.LastName)
            .HasColumnName("LastName")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.UserType)
            .HasColumnName("UserType")
            .IsRequired()
            .HasColumnType("int");

        builder.Property(x => x.Email)
            .HasColumnName("Email")
            .IsRequired()
            .HasMaxLength(240);

        builder.Property(x => x.Password)
            .HasColumnName("Password")
            .IsRequired()
            .HasMaxLength(400);

        builder.Property(x => x.CreatedDate)
            .HasColumnName("CreatedDate")
            .IsRequired()
            .HasDefaultValueSql("getdate()");
    }
}