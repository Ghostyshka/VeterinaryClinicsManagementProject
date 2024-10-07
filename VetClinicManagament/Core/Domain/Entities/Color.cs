namespace Domain.Entities;

public class Color
{
    public int ColorId { get; set; }
    public string ColorName { get; set; }

    public ICollection<Animal> Animals { get; set; } = new List<Animal>();
}