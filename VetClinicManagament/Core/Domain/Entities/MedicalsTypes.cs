namespace Domain.Entities;

public class MedicalsTypes
{
    public int TypeId { get; set; }
    public string TypeName { get; set; }
    public int Dosage { get; set; }

    public ICollection<Medical> Medicals { get; set; }
}