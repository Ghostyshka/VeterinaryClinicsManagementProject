using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<AnimalOwner> AnimalOwner { get; set; }
    public DbSet<Animal> Animals { get; set; }
    public DbSet<Specie> Specie { get; set; }
    public DbSet<Color> Color { get; set; }
    public DbSet<Breed> Breed { get; set; }    

    public DbSet<Visit> Visit { get; set; }
    public DbSet<Invoice> Invoice { get; set; }
    public DbSet<InvoiceItem> InvoiceItem { get; set; }

    public DbSet<Medicals> Medicals { get; set; }
    public DbSet<MedicalsType> MedicalsTypes { get; set; }
}