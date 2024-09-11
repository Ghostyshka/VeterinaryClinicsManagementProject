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

        builder.Property(v => v.TreatmentId)
            .IsRequired();

        // Define relationships
        builder.HasOne(v => v.User)
          .WithMany(u => u.Visit)
          .HasForeignKey(v => v.UserId)
          .IsRequired();

        builder.HasOne(v => v.Employee)
          .WithMany(e => e.Visit)
          .HasForeignKey(v => v.EmployeeId)
          .IsRequired();

        builder.HasOne(v => v.Invoice)
            .WithMany(i => i.Visit)
            .HasForeignKey(v => v.InvoiceId)
            .IsRequired();
    }
}