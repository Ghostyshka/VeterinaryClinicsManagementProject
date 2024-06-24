using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetClinic.Domain.Entity;


namespace VetClinic.Domain.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.UserId);

        builder.Property(u => u.FirstName)
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(u => u.LastName)
            .HasMaxLength(128)
            .IsRequired();

        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(u => u.PhoneNumber)
            .HasMaxLength(15);

        builder.Property(u => u.Password)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(u => u.DateOfBirth)
            .HasColumnType("Date")
            .IsRequired();

        builder.Property(u => u.CreatedAt)
            .IsRequired();

        builder.Property(u => u.UserRole)
            .IsRequired();

    }
}