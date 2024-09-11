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

        builder.Property(i => i.UpdateAt)
            .IsRequired();

        builder.Property(i => i.InvoiceStatus)
            .IsRequired();

        //TO:DO
        // Define relationships
        //builder.HasOne(i => i.Visit)
        //  .WithMany(v => v)
        //  .HasForeignKey(v => v.UserId)
        //  .IsRequired();
    }
}