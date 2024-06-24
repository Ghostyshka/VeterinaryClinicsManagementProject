namespace VetClinic.Domain.Models.Dtos;

public class UserLoginDto
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}