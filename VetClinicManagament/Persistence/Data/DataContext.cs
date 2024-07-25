﻿using Domain.Entities;
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

    public DbSet<User> Users { get; set; }
    public DbSet<Animal> Animals { get; set; }
    public DbSet<UserAnimal> UserAnimals { get; set; }
    public DbSet<Vaccine> Vaccine { get; set; }
    public DbSet<VaccineType> VaccinesType { get; set; }
}