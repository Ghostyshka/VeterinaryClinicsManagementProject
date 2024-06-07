using Microsoft.EntityFrameworkCore;
using VetClinicsDomain.Entity;

namespace VetClinicsDomain.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=admin;Database=VetClinic;Trust Server Certificate=true;");
    }


    public DbSet<User> User { get; set; }
}