using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations;

internal class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasKey(s => s.ServiceId);

        builder.Property(s => s.ServiceName)
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(s => s.Description)
            .HasMaxLength(256);

        //mb in the future, discuss with mentor
        //builder.Property(s => s.Price)
        //    .HasColumnType("decimal(18,2)");

        builder.HasMany(s => s.Treatments)
            .WithOne(t => t.Service)
            .HasForeignKey(t => t.ServiceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
} 