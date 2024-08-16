using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class MedicalsTypeConfiguration : IEntityTypeConfiguration<MedicalsType>
{
    public void Configure(EntityTypeBuilder<MedicalsType> builder)
    {
        builder.HasKey(mt => mt.MedicalsTypeId);

        builder.Property(mt => mt.Analgesic)
            .HasMaxLength(100);
        builder.Property(mt => mt.Antibiotic)
            .HasMaxLength(100);
        builder.Property(mt => mt.Antiseptic)
            .HasMaxLength(100);
        builder.Property(mt => mt.Vaccine)
            .HasMaxLength(100);
        builder.Property(mt => mt.AntiInflammatory)
            .HasMaxLength(100);
        builder.Property(mt => mt.Hormone)
            .HasMaxLength(100);
        builder.Property(mt => mt.Sedative)
            .HasMaxLength(100);
        builder.Property(mt => mt.Antiviral)
            .HasMaxLength(100);
        builder.Property(mt => mt.Diagnostic)
            .HasMaxLength(100);

        builder.HasMany(mt => mt.Medicals)
            .WithOne(m => m.MedicalsType)
            .HasForeignKey(m => m.MedicalsTypeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}