using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VetClinic.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAnimalAndAddedServicesAndTreatment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Services",
                table: "Animals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServiceName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    TreatmentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TreatmentName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Notes = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ServiceId = table.Column<int>(type: "integer", nullable: false),
                    AnimalId = table.Column<int>(type: "integer", nullable: false),
                    MedicalsId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.TreatmentId);
                    table.ForeignKey(
                        name: "FK_Treatment_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Treatment_Medicals_MedicalsId",
                        column: x => x.MedicalsId,
                        principalTable: "Medicals",
                        principalColumn: "MedicalsId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Treatment_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_AnimalId",
                table: "Treatment",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_MedicalsId",
                table: "Treatment",
                column: "MedicalsId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_ServiceId",
                table: "Treatment",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropColumn(
                name: "Services",
                table: "Animals");
        }
    }
}
