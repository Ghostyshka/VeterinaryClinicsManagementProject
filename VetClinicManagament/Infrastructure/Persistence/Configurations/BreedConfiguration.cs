using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class BreedConfiguration : IEntityTypeConfiguration<Breed>
{
    public void Configure(EntityTypeBuilder<Breed> builder)
    {
        builder.HasKey(b => b.BreedId);

        builder.Property(b => b.BreedName)
            .HasMaxLength(128)
            .IsRequired();

        builder.HasMany(b => b.Animals)
            .WithOne(a => a.Breed)
            .HasForeignKey(a => a.BreedId);
    }
}