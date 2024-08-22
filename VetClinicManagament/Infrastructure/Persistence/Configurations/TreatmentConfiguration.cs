using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations;

internal class TreatmentConfiguration : IEntityTypeConfiguration<Treatment>
{
    public void Configure(EntityTypeBuilder<Treatment> builder)
    {
        builder.HasKey(t => t.TreatmentId);

        builder.Property(t => t.TreatmentName)
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(t => t.Date)
            .IsRequired();

        builder.Property(t => t.Notes)
            .HasMaxLength(256);

        builder.HasOne(t => t.Service)
            .WithMany(s => s.Treatments)
            .HasForeignKey(t => t.ServiceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(t => t.Animal)
            .WithMany(a => a.Treatments)
            .HasForeignKey(t => t.AnimalId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(t => t.Medicals)
            .WithMany(m => m.Treatments)
            .HasForeignKey(t => t.MedicalsId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}