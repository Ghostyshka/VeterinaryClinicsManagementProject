using Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service;

public class JwtToken
{
    private readonly IConfiguration _configuration;
    public JwtToken(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string CreateToken(PersonModel person)
    {
        List<Claim> claims;
        if (person is UserModel user)
        {
            claims = new List<Claim>()
            {
                new Claim("UserId", user.UserId.ToString()),
                new Claim("UserName", user.FullName)
            };
        }
        else if (person is EmployeeModel employee)
        {
            claims = new List<Claim>()
            {
                new Claim("EmployeeId", employee.EmployeeId.ToString()),
                new Claim("EmployeeName", employee.FullName.ToString())
            };
        }
        else
        {
            throw new ArgumentException("Invalid person type");
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration.GetSection("Jwt:Key").Value!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds,
            issuer: _configuration.GetSection("Jwt:Issuer").Value,
            audience: _configuration.GetSection("Jwt:Audience").Value
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}