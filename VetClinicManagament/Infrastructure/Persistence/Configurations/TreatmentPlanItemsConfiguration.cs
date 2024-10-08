using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;


namespace Persistence.Configurations;

internal class TreatmentPlanItemsConfiguration : IEntityTypeConfiguration<TreatmentPlanItem>
{
    public void Configure(EntityTypeBuilder<TreatmentPlanItem> builder)
    {
        builder.HasKey(tpi => tpi.PlanItemId);

        builder.Property(tpi => tpi.Dosage)
               .IsRequired();

        builder.Property(tpi => tpi.Quantity)
               .IsRequired();

        builder.HasOne(tpi => tpi.Medicals)
               .WithMany()
               .HasForeignKey(tpi => tpi.MedicalId)
               .IsRequired();
    }
}