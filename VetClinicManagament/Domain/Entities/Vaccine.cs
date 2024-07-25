﻿namespace Domain.Entities;

public class Vaccine
{
    public int VaccineId { get; set; }
    public string VaccineName { get; set; }
    public string Manufacturer { get; set; }
    public DateTime ExpiryDate { get; set; }

    public int VaccineTypeId { get; set; }
    public VaccineType VaccineType { get; set; }

    public int AnimalId { get; set; }
    public Animal Animal { get; set; }
}