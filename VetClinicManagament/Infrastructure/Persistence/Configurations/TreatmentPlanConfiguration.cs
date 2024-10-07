﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class TreatmentPlanConfiguration : IEntityTypeConfiguration<TreatmentPlan>
{
    public void Configure(EntityTypeBuilder<TreatmentPlan> builder)
    {
        builder.HasKey(tp => tp.PlanId);

        builder.Property(tp => tp.TreatmentId)
            .IsRequired();

        builder.Property(tp => tp.ServiceTypeId)
            .IsRequired();

        builder.Property(tp => tp.StartOfTreatment)
            .IsRequired();

        builder.Property(tp => tp.EndOfTreatment)
            .IsRequired();        
        
        builder.Property(tp => tp.InClinic)
            .IsRequired();
    }
}