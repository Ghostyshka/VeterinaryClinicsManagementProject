namespace VetClinic.Domain.Entity;

public class VaccineType
{
    public int VaccineTypeId { get; set; }

    public string? LiveAttenuated { get; set; }
    public string? Inactivated { get; set; }
    public string? Toxoid { get; set; }
    public string? Subunit { get; set; }
    public string? Recombinant { get; set; }
    public string? Conjugate { get; set; }
    public string? DNARNA { get; set; }
    public string? Adjuvanted { get; set; }
    public string? Multivalent { get; set; }
    public string? Vector { get; set; }

    public ICollection<Vaccine> Vaccines { get; set; }
}