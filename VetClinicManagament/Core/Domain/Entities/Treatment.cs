namespace Domain.Entities;

public class Treatment
{
    public int TreatmentId { get; set; }
    public string TreatmentName { get; set; }
    public DateTime Date { get; set; }
    public string? Notes { get; set; }

    public int ServiceId { get; set; }
    public Service Service { get; set; }

    public int AnimalId { get; set; }
    public Animal Animal { get; set; }

    public int? MedicalsId { get; set; }
    public Medicals? Medicals { get; set; }

    public ICollection<TreatmentHistory> TreatmentHistories { get; set; }
}