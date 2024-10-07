using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class SpecieConfiguration : IEntityTypeConfiguration<Specie>
{
    public void Configure(EntityTypeBuilder<Specie> builder)
    {
        builder.HasKey(s => s.SpecieId);

        builder.Property(s => s.SpecieName)
            .HasMaxLength(128)
            .IsRequired();

        builder.HasMany(s => s.Animals)
            .WithOne(a => a.Specie)
            .HasForeignKey(a => a.SpeciesId);
    }
}