using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class TreatmentHistoryConfiguration : IEntityTypeConfiguration<TreatmentHistory>
{
    public void Configure(EntityTypeBuilder<TreatmentHistory> builder)
    {
        builder.HasKey(th => th.TreatmentHistoryId);

        builder.Property(th => th.Date)
            .IsRequired();

        builder.HasOne(th => th.Treatment)
            .WithMany(t => t.TreatmentHistories)
            .HasForeignKey(th => th.TreatmentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}