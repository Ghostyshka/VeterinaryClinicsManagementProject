using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Configurations;

internal class ServiceTypeConfiguration : IEntityTypeConfiguration<ServiceType>
{
    public void Configure(EntityTypeBuilder<ServiceType> builder)
    {
        builder.HasKey(st => st.ServiceTypeId);

        builder.Property(st => st.TypeName)
               .HasMaxLength(128)
               .IsRequired();
    }
}