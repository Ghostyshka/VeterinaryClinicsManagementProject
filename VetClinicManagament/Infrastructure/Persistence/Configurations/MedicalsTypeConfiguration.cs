using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class MedicalsTypeConfiguration : IEntityTypeConfiguration<MedicalsTypes>
{
    public void Configure(EntityTypeBuilder<MedicalsTypes> builder)
    {
        builder.HasKey(mt => mt.TypeId);

        builder.Property(mt => mt.TypeName)
            .IsRequired()
            .HasMaxLength(100);
    }
}