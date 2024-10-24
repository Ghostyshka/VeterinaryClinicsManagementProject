using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations;

internal class VisitConfiguration : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        builder.HasKey(v => v.VisitId);

        builder.Property(v => v.DataOfVisit)
            .IsRequired();

        builder.Property(v => v.UserId)
            .IsRequired();

        builder.Property(v => v.EmployeeId)
            .IsRequired();

        builder.Property(v => v.Status)
            .IsRequired();

        builder.Property(v => v.Description)
            .HasMaxLength(1000);

        builder.HasOne(v => v.User)
            .WithMany(u => u.Visits)
            .HasForeignKey(v => v.UserId)
            .IsRequired();

        builder.HasOne(v => v.Employee)
            .WithMany(e => e.Visits)
            .HasForeignKey(v => v.EmployeeId)
            .IsRequired();

        builder.HasMany(v => v.Invoice)
            .WithOne(i => i.Visit)
            .HasForeignKey(i => i.VisitId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(v => v.TreatmentPlan)
           .WithOne(tp => tp.Visit)
           .HasForeignKey(tp => tp.VisitId)
           .OnDelete(DeleteBehavior.SetNull);
    }
}
