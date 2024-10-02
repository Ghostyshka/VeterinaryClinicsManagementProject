using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations;

internal class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.HasKey(i => i.InvoiceId);

        builder.Property(i => i.VisitId)
            .IsRequired();

        builder.Property(i => i.CreatedAt)
            .IsRequired();

        builder.Property(i => i.UpdatedAt)
            .IsRequired();

        builder.Property(i => i.InvoiceStatus)
            .IsRequired();

        builder.HasMany(i => i.Visits)  // invoice has many visits
            .WithOne(v => v.Invoice)   // a visit has one invoice
            .HasForeignKey(v => v.InvoiceId)
            .IsRequired(false);
    }
}