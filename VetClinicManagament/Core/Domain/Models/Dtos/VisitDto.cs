namespace Domain.Models.Dtos;

public class VisitDto
{
    public DateTime DataOfVisit { get; set; }
    public int UserId { get; set; }
    public int EmployeeId { get; set; }
    public int Status { get; set; }
    public string Description { get; set; }
}