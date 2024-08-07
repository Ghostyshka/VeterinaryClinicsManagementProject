using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class VaccineTypeConfiguration : IEntityTypeConfiguration<VaccineType>
{
    public void Configure(EntityTypeBuilder<VaccineType> builder)
    {
        builder.HasKey(vt => vt.VaccineTypeId);

        builder.Property(vt => vt.LiveAttenuated)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(vt => vt.Inactivated)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(vt => vt.Toxoid)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(vt => vt.Subunit)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(vt => vt.Recombinant)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(vt => vt.Conjugate)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(vt => vt.DNARNA)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(vt => vt.Adjuvanted)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(vt => vt.Multivalent)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(vt => vt.Vector)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasMany(vt => vt.Vaccines)
            .WithOne(v => v.VaccineType)
            .HasForeignKey(v => v.VaccineTypeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}