using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class MedicalsTypeConfiguration : IEntityTypeConfiguration<MedicalType>
{
    public void Configure(EntityTypeBuilder<MedicalType> builder)
    {
        builder.HasKey(mt => mt.TypeId);

    }
}