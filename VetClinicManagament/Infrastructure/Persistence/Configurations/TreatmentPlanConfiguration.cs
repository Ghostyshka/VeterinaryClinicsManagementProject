//using Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Persistence.Configurations;

//internal class TreatmentPlanConfiguration : IEntityTypeConfiguration<TreatmentPlanItem>
//{
//    public void Configure(EntityTypeBuilder<TreatmentPlanItem> builder)
//    {
//        builder.HasKey(tp => tp.TreatmentPlanId);

//        builder.Property(tp => tp.PlanName)
//            .HasMaxLength(128)
//            .IsRequired();

//        builder.Property(tp => tp.StartDate)
//            .IsRequired();

//        builder.Property(tp => tp.EndDate)
//            .IsRequired();

//        builder.Property(tp => tp.IsAdministeredAtClinic)
//            .IsRequired();

//        builder.HasOne(tp => tp.Animal)
//            .WithMany(a => a.TreatmentPlans)
//            .HasForeignKey(tp => tp.AnimalId)
//            .OnDelete(DeleteBehavior.Cascade);

//        builder.HasMany(tp => tp.Medicals)
//            .WithOne()
//            .OnDelete(DeleteBehavior.Cascade);

//        builder.HasMany(tp => tp.Treatments)
//            .WithOne()
//            .OnDelete(DeleteBehavior.Cascade);
//    }
//}