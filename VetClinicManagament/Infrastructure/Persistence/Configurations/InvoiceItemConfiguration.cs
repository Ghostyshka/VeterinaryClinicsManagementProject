using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations;

internal class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
{
    public void Configure(EntityTypeBuilder<InvoiceItem> builder)
    {
        builder.HasKey(it => it.ItemId);

        builder.Property(it => it.InvoiceId)
            .IsRequired();

        builder.Property(it => it.ItemType)
            .HasMaxLength(128)
            .IsRequired();

        builder.HasOne(it => it.Invoice)  // each InvoiceItem belongs to one Invoice
            .WithMany(i => i.InvoiceItems)  // An Invoice can have many InvoiceItems
            .HasForeignKey(it => it.InvoiceId)
            .IsRequired();
    }
}