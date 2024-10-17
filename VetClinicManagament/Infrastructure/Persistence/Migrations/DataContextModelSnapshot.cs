﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence.Data;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AnimalId"));

                    b.Property<int>("AnimalGender")
                        .HasColumnType("integer");

                    b.Property<string>("AnimalName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<int>("BreedId")
                        .HasColumnType("integer");

                    b.Property<int>("ColorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsLive")
                        .HasColumnType("boolean");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("integer");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("AnimalId");

                    b.HasIndex("BreedId");

                    b.HasIndex("ColorId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("Domain.Entities.AnimalOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AnimalId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("UserId");

                    b.ToTable("AnimalOwner");
                });

            modelBuilder.Entity("Domain.Entities.Breed", b =>
                {
                    b.Property<int>("BreedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BreedId"));

                    b.Property<string>("BreedName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("BreedId");

                    b.ToTable("Breed");
                });

            modelBuilder.Entity("Domain.Entities.Color", b =>
                {
                    b.Property<int>("ColorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ColorId"));

                    b.Property<string>("ColorName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("ColorId");

                    b.ToTable("Color");
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EmployeeId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EmployeeFullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Domain.Entities.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("InvoiceId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("InvoiceStatus")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("VisitId")
                        .HasColumnType("integer");

                    b.HasKey("InvoiceId");

                    b.HasIndex("VisitId")
                        .IsUnique();

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("Domain.Entities.InvoiceItem", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ItemId"));

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("integer");

                    b.Property<string>("ItemType")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("ItemId");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceItem");
                });

            modelBuilder.Entity("Domain.Entities.Medical", b =>
                {
                    b.Property<int>("MedicalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MedicalId"));

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MedicalName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("MedicalTypeId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("MedicalId");

                    b.HasIndex("MedicalTypeId");

                    b.ToTable("Medical");
                });

            modelBuilder.Entity("Domain.Entities.MedicalType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TypeId"));

                    b.Property<int>("Dosage")
                        .HasColumnType("integer");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("TypeId");

                    b.ToTable("MedicalType");
                });

            modelBuilder.Entity("Domain.Entities.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ServiceId"));

                    b.Property<int>("MedicalId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<int>("ServiceTypeId")
                        .HasColumnType("integer");

                    b.HasKey("ServiceId");

                    b.HasIndex("MedicalId");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("Domain.Entities.ServiceType", b =>
                {
                    b.Property<int>("ServiceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ServiceTypeId"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("ServiceTypeId");

                    b.ToTable("ServiceType");
                });

            modelBuilder.Entity("Domain.Entities.Specie", b =>
                {
                    b.Property<int>("SpecieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SpecieId"));

                    b.Property<string>("SpecieName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("SpecieId");

                    b.ToTable("Specie");
                });

            modelBuilder.Entity("Domain.Entities.TreatmentPlan", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PlanId"));

                    b.Property<DateTime>("EndOfTreatment")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("InClinic")
                        .HasColumnType("boolean");

                    b.Property<int>("ServiceTypeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartOfTreatment")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TreatmentId")
                        .HasColumnType("integer");

                    b.HasKey("PlanId");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("TreatmentPlan");
                });

            modelBuilder.Entity("Domain.Entities.TreatmentPlanItem", b =>
                {
                    b.Property<int>("PlanItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PlanItemId"));

                    b.Property<double>("Dosage")
                        .HasColumnType("double precision");

                    b.Property<string>("ItemDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int>("MedicalId")
                        .HasColumnType("integer");

                    b.Property<int>("PlanId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.HasKey("PlanItemId");

                    b.HasIndex("MedicalId");

                    b.HasIndex("PlanId");

                    b.HasIndex("ServiceId");

                    b.ToTable("TreatmentPlanItem");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.Visit", b =>
                {
                    b.Property<int>("VisitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("VisitId"));

                    b.Property<DateTime>("DataOfVisit")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int?>("TreatmentId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("VisitId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("TreatmentId");

                    b.HasIndex("UserId");

                    b.ToTable("Visit");
                });

            modelBuilder.Entity("Domain.Entities.Animal", b =>
                {
                    b.HasOne("Domain.Entities.Breed", "Breed")
                        .WithMany("Animals")
                        .HasForeignKey("BreedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Color", "Color")
                        .WithMany("Animals")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Specie", "Specie")
                        .WithMany("Animals")
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Breed");

                    b.Navigation("Color");

                    b.Navigation("Specie");
                });

            modelBuilder.Entity("Domain.Entities.AnimalOwner", b =>
                {
                    b.HasOne("Domain.Entities.Animal", "Animal")
                        .WithMany("AnimalOwner")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("AnimalOwner")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Invoice", b =>
                {
                    b.HasOne("Domain.Entities.Visit", "Visit")
                        .WithOne("Invoice")
                        .HasForeignKey("Domain.Entities.Invoice", "VisitId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("Domain.Entities.InvoiceItem", b =>
                {
                    b.HasOne("Domain.Entities.Invoice", "Invoice")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("Domain.Entities.Medical", b =>
                {
                    b.HasOne("Domain.Entities.MedicalType", "MedicalsType")
                        .WithMany("Medicals")
                        .HasForeignKey("MedicalTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalsType");
                });

            modelBuilder.Entity("Domain.Entities.Service", b =>
                {
                    b.HasOne("Domain.Entities.Medical", "Medicals")
                        .WithMany()
                        .HasForeignKey("MedicalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ServiceType", "ServiceType")
                        .WithMany("Services")
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicals");

                    b.Navigation("ServiceType");
                });

            modelBuilder.Entity("Domain.Entities.TreatmentPlan", b =>
                {
                    b.HasOne("Domain.Entities.ServiceType", "ServiceType")
                        .WithMany("TreatmentPlans")
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServiceType");
                });

            modelBuilder.Entity("Domain.Entities.TreatmentPlanItem", b =>
                {
                    b.HasOne("Domain.Entities.Medical", "Medical")
                        .WithMany("TreatmentPlanItems")
                        .HasForeignKey("MedicalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TreatmentPlan", "TreatmentPlan")
                        .WithMany("TreatmentPlanItems")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Service", "Service")
                        .WithMany("TreatmentPlanItems")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medical");

                    b.Navigation("Service");

                    b.Navigation("TreatmentPlan");
                });

            modelBuilder.Entity("Domain.Entities.Visit", b =>
                {
                    b.HasOne("Domain.Entities.Employee", "Employee")
                        .WithMany("Visits")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Invoice", null)
                        .WithMany("Visits")
                        .HasForeignKey("InvoiceId");

                    b.HasOne("Domain.Entities.TreatmentPlan", "TreatmentPlan")
                        .WithMany("Visit")
                        .HasForeignKey("TreatmentId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Visits")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("TreatmentPlan");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Animal", b =>
                {
                    b.Navigation("AnimalOwner");
                });

            modelBuilder.Entity("Domain.Entities.Breed", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("Domain.Entities.Color", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.Navigation("Visits");
                });

            modelBuilder.Entity("Domain.Entities.Invoice", b =>
                {
                    b.Navigation("InvoiceItems");

                    b.Navigation("Visits");
                });

            modelBuilder.Entity("Domain.Entities.Medical", b =>
                {
                    b.Navigation("TreatmentPlanItems");
                });

            modelBuilder.Entity("Domain.Entities.MedicalType", b =>
                {
                    b.Navigation("Medicals");
                });

            modelBuilder.Entity("Domain.Entities.Service", b =>
                {
                    b.Navigation("TreatmentPlanItems");
                });

            modelBuilder.Entity("Domain.Entities.ServiceType", b =>
                {
                    b.Navigation("Services");

                    b.Navigation("TreatmentPlans");
                });

            modelBuilder.Entity("Domain.Entities.Specie", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("Domain.Entities.TreatmentPlan", b =>
                {
                    b.Navigation("TreatmentPlanItems");

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("AnimalOwner");

                    b.Navigation("Visits");
                });

            modelBuilder.Entity("Domain.Entities.Visit", b =>
                {
                    b.Navigation("Invoice")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
