using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VetClinic.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddMedicalsAndTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Medicals",
                table: "Animals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MedicalsType",
                table: "Animals",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MedicalsTypes",
                columns: table => new
                {
                    MedicalsTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Analgesic = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Antibiotic = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Antiseptic = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Vaccine = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    AntiInflammatory = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Hormone = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Sedative = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Antiviral = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Diagnostic = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalsTypes", x => x.MedicalsTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Medicals",
                columns: table => new
                {
                    MedicalsId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicalName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    MedicalsTypeId = table.Column<int>(type: "integer", nullable: false),
                    AnimalId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicals", x => x.MedicalsId);
                    table.ForeignKey(
                        name: "FK_Medicals_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicals_MedicalsTypes_MedicalsTypeId",
                        column: x => x.MedicalsTypeId,
                        principalTable: "MedicalsTypes",
                        principalColumn: "MedicalsTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicals_AnimalId",
                table: "Medicals",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicals_MedicalsTypeId",
                table: "Medicals",
                column: "MedicalsTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicals");

            migrationBuilder.DropTable(
                name: "MedicalsTypes");

            migrationBuilder.DropColumn(
                name: "Medicals",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "MedicalsType",
                table: "Animals");
        }
    }
}
