namespace Domain.Entities;

public class Specie
{
    public int SpecieId { get; set; }
    public string SpecieName { get; set; }

    public ICollection<Animal> Animals { get; set; } = new List<Animal>();
}