using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class TreatmentPlanConfiguration : IEntityTypeConfiguration<TreatmentPlan>
{
    public void Configure(EntityTypeBuilder<TreatmentPlan> builder)
    {
        builder.HasKey(tp => tp.PlanId);

        builder.Property(tp => tp.StartOfTreatment)
               .IsRequired();

        builder.Property(tp => tp.EndOfTreatment)
               .IsRequired();

        builder.Property(tp => tp.InClinic)
            .IsRequired();

        builder.Property(tp => tp.VisitId)
            .IsRequired();

        builder.HasOne(tp => tp.Visit)
               .WithMany(v => v.TreatmentPlan)
               .HasForeignKey(tp => tp.VisitId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(tp => tp.TreatmentPlanItems)
               .WithOne(tpi => tpi.TreatmentPlan)
               .HasForeignKey(tpi => tpi.PlanId);
    }
}