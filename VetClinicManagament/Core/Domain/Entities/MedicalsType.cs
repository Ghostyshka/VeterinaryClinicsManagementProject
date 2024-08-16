namespace Domain.Entities;

public class MedicalsType
{
    public int MedicalsTypeId { get; set; }

    public string? Analgesic { get; set; }
    public string? Antibiotic { get; set; }
    public string? Antiseptic { get; set; }
    public string? Vaccine { get; set; }
    public string? AntiInflammatory { get; set; }
    public string? Hormone { get; set; }
    public string? Sedative { get; set; }
    public string? Antiviral { get; set; }
    public string? Diagnostic { get; set; }

    public ICollection<Medicals> Medicals{ get; set; }
}