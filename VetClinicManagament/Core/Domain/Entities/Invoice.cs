﻿using Domain.Enum;

namespace Domain.Entities;

public class Invoice
{
    public int InvoiceId { get; set; }

    public int VisitId { get; set; }
    public Visit Visit { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public InvoiceStatus InvoiceStatus { get; set; }

    public ICollection<InvoiceItem> InvoiceItems { get; set; }
    public ICollection<Visit> Visits { get; set; }
}
