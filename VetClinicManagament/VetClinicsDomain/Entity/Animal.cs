namespace VetClinicsDomain.Entity;

public class Animal
{
    public int AnimalId { get; set; }
    public string AnimalName { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }
    public string Breed { get; set; }
    public string Color { get; set; }
    public string Gender { get; set; }
    public bool Health { get; set; }
    public bool Vaccination { get; set; }
    public string VaccineType { get; set; }
    public double Weight { get; set; }
}