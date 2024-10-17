using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;


namespace Persistence.Configurations;

internal class TreatmentPlanItemsConfiguration : IEntityTypeConfiguration<TreatmentPlanItem>
{
    public void Configure(EntityTypeBuilder<TreatmentPlanItem> builder)
    {
        builder.HasKey(t => t.PlanItemId);

        builder.Property(t => t.ItemDescription)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(t => t.Dosage)
            .IsRequired();

        builder.Property(t => t.Quantity)
            .IsRequired();

        builder.HasOne(t => t.Medical)
            .WithMany(m => m.TreatmentPlanItems)
            .HasForeignKey(t => t.MedicalId);

        builder.HasOne(t => t.Service)
            .WithMany(s => s.TreatmentPlanItems)
            .HasForeignKey(t => t.ServiceId);
    }
}