using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetClinic.Domain.Entity;

namespace VetClinic.Domain.Configurations;

internal class VaccineConfiguration : IEntityTypeConfiguration<Vaccine>
{
    public void Configure(EntityTypeBuilder<Vaccine> builder)
    {
        builder.HasKey(v => v.VaccineId);

        builder.Property(v => v.VaccineName)
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(v => v.VaccineType)
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(v => v.Manufacturer)
            .HasMaxLength(128)
            .IsRequired();       
        
        builder.Property(v => v.ExpiryDate)
            .IsRequired();
    }
}