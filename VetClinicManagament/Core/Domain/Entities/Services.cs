namespace Domain.Entities;

public class Service
{
    public int ServiceId { get; set; }
    public string ServiceName { get; set; }
    public string? Description { get; set; }

    //mb in the future, discuss with mentor
    //public decimal? Price { get; set; } 

    public ICollection<Treatment> Treatments { get; set; }
}