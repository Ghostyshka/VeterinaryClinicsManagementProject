using Domain.Enum;

namespace Domain.Entities;

public class Animal
{
    private AnimalGender _gender;

    public int AnimalId { get; set; }
    public string AnimalName { get; set; }
    public bool IsLive { get; set; }
    public int SpeciesId { get; set; }
    public int ColorId { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int BreedId { get; set; }
    public AnimalGender AnimalGender
    {
        get => _gender;
        set
        {
            if (!System.Enum.IsDefined(typeof(AnimalGender), value))
            {
                throw new ArgumentException("Invalid animal gender");
            }
            _gender = value;
        }
    }
    public double Weight { get; set; }

    public Specie Specie { get; set; }
    public Color Color { get; set; }
    public Breed Breed { get; set; }

    public ICollection<AnimalOwner> AnimalOwner { get; set; }
}