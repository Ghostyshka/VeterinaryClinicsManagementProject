using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class AnimalOwnersConfiguration : IEntityTypeConfiguration<AnimalOwner>
{
    public void Configure(EntityTypeBuilder<AnimalOwner> builder)
    {
        builder.HasKey(ao => ao.Id);

        builder.Property(s => s.UserId)
            .IsRequired();        
        
        builder.Property(s => s.AnimalId)
            .IsRequired();
    }
}