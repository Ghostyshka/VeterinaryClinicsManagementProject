using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class UserAnimalConfiguration : IEntityTypeConfiguration<UserAnimal>
{
    public void Configure(EntityTypeBuilder<UserAnimal> builder)
    {
        builder.HasKey(ua => ua.Id);

        builder
            .HasOne(ua => ua.User)
            .WithMany(u => u.UserAnimals)
            .HasForeignKey(ua => ua.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(ua => ua.Animal)
            .WithMany(a => a.UserAnimals)
            .HasForeignKey(ua => ua.AnimalId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}