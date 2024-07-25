using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class AnimalConfiguration : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> builder)
    {
        builder.HasKey(a => a.AnimalId);

        builder.Property(a => a.AnimalName)
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(a => a.Species)
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(a => a.Age)
            .IsRequired();

        builder.Property(a => a.Breed)
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(a => a.Color)
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(a => a.IsLive)
            .IsRequired();

        builder.Property(a => a.Vaccination)
            .IsRequired();

        builder.Property(a => a.VaccineType)
            .HasMaxLength(128);

        builder.Property(a => a.Weight)
            .IsRequired();

    }
}