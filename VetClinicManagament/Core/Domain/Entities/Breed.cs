namespace Domain.Entities;

public class Breed
{
    public int BreedId { get; set; }
    public string BreedName { get; set; }

    public ICollection<Animal> Animals { get; set; } = new List<Animal>();
}