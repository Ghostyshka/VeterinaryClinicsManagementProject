﻿namespace Domain.Models.Dtos;

public class InvoiceItemDto
{
    public int? InvoiceId { get; set; }
    public string ItemType { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
}