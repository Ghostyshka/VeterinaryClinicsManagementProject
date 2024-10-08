namespace Domain.Entities;

public class ServiceType
{
    public int ServiceTypeId { get; set; }
    public string TypeName { get; set; }

    public ICollection<TreatmentPlan> TreatmentPlans { get; set; }
    public ICollection<Service> Services { get; set; }
}