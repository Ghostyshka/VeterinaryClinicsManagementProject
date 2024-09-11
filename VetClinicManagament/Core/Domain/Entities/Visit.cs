﻿namespace Domain.Entities;

public class Visit
{
    public int VisitId { get; set; }
    public DateTime DataOfVisit { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }

    public int TreatmentId { get; set; }
    public TreatmentPlan TreatmentPlan { get; set; }
}