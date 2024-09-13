using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class AnimaOwnerlConfiguration : IEntityTypeConfiguration<AnimalOwner>
{
    public void Configure(EntityTypeBuilder<AnimalOwner> builder)
    {
        builder.HasKey(ua => ua.Id);

        builder.Property(tp => tp.UserId)
    .IsRequired();

        builder.Property(tp => tp.AnimalId)
    .IsRequired();

        builder
            .HasOne(ua => ua.User)
            .WithMany(u => u.AnimalOwner)
            .HasForeignKey(ua => ua.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(ua => ua.Animal)
            .WithMany(a => a.AnimalOwner)
            .HasForeignKey(ua => ua.AnimalId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}