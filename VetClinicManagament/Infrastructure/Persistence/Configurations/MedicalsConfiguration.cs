using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class MedicalsConfiguration : IEntityTypeConfiguration<Medicals>
{
    public void Configure(EntityTypeBuilder<Medicals> builder)
    {
        builder.HasKey(m => m.MedicalId);

    }
}