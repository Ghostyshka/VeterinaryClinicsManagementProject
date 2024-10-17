using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations;

internal class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasKey(s => s.ServiceId);

        builder.Property(s => s.Price)
               .HasColumnType("decimal(8, 2)")
               .IsRequired();

        builder.HasOne(s => s.ServiceType)
               .WithMany(st => st.Services)
               .HasForeignKey(s => s.ServiceTypeId)
               .IsRequired();

        builder.HasOne(s => s.Medicals)
               .WithMany()
               .HasForeignKey(s => s.MedicalId)
               .IsRequired();
    }
}