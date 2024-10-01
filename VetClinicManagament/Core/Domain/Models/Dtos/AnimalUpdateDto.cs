using Domain.Enum;

namespace Domain.Models.Dtos;

public class AnimalUpdateDto
{
    private AnimalGender? _gender;

    public string AnimalName { get; set; }
    public int? SpeciesId { get; set; }
    public int? ColorId { get; set; }
    public int? BreedId { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public AnimalGender? AnimalGender
    {
        get => _gender;
        set
        {
            if (value.HasValue && !System.Enum.IsDefined(typeof(AnimalGender), value.Value))
            {
                throw new ArgumentException("Invalid animal gender");
            }
            _gender = value;
        }
    }

    public bool IsLive { get; set; }
    public double? Weight { get; set; }
}