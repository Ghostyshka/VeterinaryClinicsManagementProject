using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class MedicalsTypeConfiguration : IEntityTypeConfiguration<MedicalsType>
{
    public void Configure(EntityTypeBuilder<MedicalsType> builder)
    {
        builder.HasKey(mt => mt.TypeId);

    }
}