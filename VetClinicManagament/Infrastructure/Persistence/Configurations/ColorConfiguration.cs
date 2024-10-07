using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.HasKey(c => c.ColorId);

        builder.Property(c => c.ColorName)
            .HasMaxLength(128)
            .IsRequired();

        builder.HasMany(c => c.Animals)
            .WithOne(a => a.Color)
            .HasForeignKey(a => a.ColorId);
    }
}