using Domain.Entities;
using Domain.Enum;

namespace Domain.Models.Dtos;

public class AnimalDto
{
    private AnimalGender _gender;

    public string EmployeeEmail { get; set; }
    public string UserEmail { get; set; }
    public string AnimalName { get; set; }
    public int SpeciesId { get; set; }
    public int ColorId { get; set; }
    public int BreedId { get; set; }
    public DateTime DateOfBirth { get; set; }

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

    public bool IsLive { get; set; }
    public double Weight { get; set; }

    public Specie Specie { get; set; }
    public Color Color { get; set; }
    public Breed Breed { get; set; }
}