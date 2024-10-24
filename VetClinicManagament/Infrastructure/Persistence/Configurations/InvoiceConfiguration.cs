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

        builder.HasOne(i => i.Visit)
       .WithMany(v => v.Invoice)
       .HasForeignKey(i => i.VisitId)
       .OnDelete(DeleteBehavior.SetNull);
    }
}