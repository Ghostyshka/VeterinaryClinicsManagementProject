using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class MedicalsConfiguration : IEntityTypeConfiguration<Medicals>
{
    public void Configure(EntityTypeBuilder<Medicals> builder)
    {
        builder.HasKey(m => m.MedicalsId);

        builder.Property(m => m.MedicalName)
            .HasMaxLength(128)
            .IsRequired();

        builder.HasOne(m => m.MedicalsType)
            .WithMany(mt => mt.Medicals)
            .HasForeignKey(m => m.MedicalsTypeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}