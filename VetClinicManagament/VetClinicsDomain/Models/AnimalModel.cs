using VetClinic.Domain.Enum;
using VetClinic.Domain.Models.Dtos;

namespace VetClinic.Domain.Models;

public class AnimalDto
{
    private AnimalGender _gender;

    public UserDto OwnerId { get; set; }
    public int AnimalId { get; set; }
    public string AnimalName { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }
    public string Breed { get; set; }
    public string Color { get; set; }

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

    public bool Health { get; set; }
    public bool Vaccination { get; set; }
    public string VaccineType { get; set; }
    public double Weight { get; set; }
}