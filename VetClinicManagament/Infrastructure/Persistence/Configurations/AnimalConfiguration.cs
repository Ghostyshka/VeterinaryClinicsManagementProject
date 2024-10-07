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

        builder.Property(a => a.IsLive)
            .IsRequired();

        builder.Property(a => a.SpeciesId)
            .IsRequired();

        builder.Property(a => a.ColorId)
            .IsRequired();

        builder.Property(a => a.DateOfBirth)
            .IsRequired();

        builder.Property(a => a.BreedId)
            .IsRequired();

        builder.Property(a => a.AnimalGender)
            .IsRequired();

        builder.Property(a => a.Weight)
            .IsRequired();

        // Configure the relationships
        builder.HasOne(a => a.Specie)
            .WithMany(s => s.Animals)
            .HasForeignKey(a => a.SpeciesId)
            .IsRequired();

        builder.HasOne(a => a.Color)
            .WithMany(c => c.Animals)
            .HasForeignKey(a => a.ColorId)
            .IsRequired();

        builder.HasOne(a => a.Breed)
            .WithMany(b => b.Animals)
            .HasForeignKey(a => a.BreedId)
            .IsRequired();
    }
}