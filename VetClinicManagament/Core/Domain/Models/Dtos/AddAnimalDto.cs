using Domain.Enum;

namespace Domain.Models.Dtos;

public class AddAnimalDto
{
    private AnimalGender _gender;

    public string WorkerEmail { get; set; }
    public string OwnerEmail { get; set; }
    public string AnimalName { get; set; }
    public string Species { get; set; }
    public DateTime DateOfBirth { get; set; }
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

    public bool IsLive { get; set; }
    public bool Vaccination { get; set; }
    public string VaccineType { get; set; }
    public double Weight { get; set; }
}