using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class MedicalConfiguration : IEntityTypeConfiguration<Medical>
{
    public void Configure(EntityTypeBuilder<Medical> builder)
    {
        builder.HasKey(m => m.MedicalId);
        builder.Property(m => m.MedicalName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.MedicalName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.Quantity)
            .IsRequired();

        builder.Property(m => m.ExpirationDate)
            .IsRequired();

        builder.HasOne(m => m.MedicalsType)
            .WithMany(mt => mt.Medicals)
            .HasForeignKey(m => m.MedicalTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(m => m.TreatmentPlanItems)
            .WithOne(tpi => tpi.Medical)
            .HasForeignKey(tpi => tpi.MedicalId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}