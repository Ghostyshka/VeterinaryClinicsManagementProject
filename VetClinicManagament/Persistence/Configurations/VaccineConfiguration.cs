using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class VaccineConfiguration : IEntityTypeConfiguration<Vaccine>
{
    public void Configure(EntityTypeBuilder<Vaccine> builder)
    {
        builder.HasKey(v => v.VaccineId);

        builder.Property(v => v.VaccineName)
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(v => v.Manufacturer)
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(v => v.ExpiryDate)
            .IsRequired();

        builder.HasOne(v => v.VaccineType)
            .WithMany(vt => vt.Vaccines)
            .HasForeignKey(v => v.VaccineTypeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}