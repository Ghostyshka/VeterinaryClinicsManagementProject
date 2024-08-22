namespace Domain.Entities;

public class TreatmentHistory
{
    public int TreatmentHistoryId { get; set; }
    public DateTime Date { get; set; }

    // Foreign Keys
    public int TreatmentId { get; set; }
    public Treatment Treatment { get; set; }
}