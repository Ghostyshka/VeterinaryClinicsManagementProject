namespace Domain.Entities;

public class Medicals
{
    public int MedicalsId { get; set; }
    public string MedicalName { get; set; }

    public int MedicalsTypeId { get; set; }
    public MedicalsType MedicalsType { get; set; }

    public int AnimalId { get; set; }
    public Animal Animal { get; set; }
}