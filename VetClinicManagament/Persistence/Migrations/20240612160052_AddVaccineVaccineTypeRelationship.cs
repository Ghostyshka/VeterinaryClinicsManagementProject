using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VetClinic.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddVaccineVaccineTypeRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VaccinesType",
                columns: table => new
                {
                    VaccineTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LiveAttenuated = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Inactivated = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Toxoid = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Subunit = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Recombinant = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Conjugate = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DNARNA = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Adjuvanted = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Multivalent = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Vector = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinesType", x => x.VaccineTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Vaccine",
                columns: table => new
                {
                    VaccineId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VaccineName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Manufacturer = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VaccineTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccine", x => x.VaccineId);
                    table.ForeignKey(
                        name: "FK_Vaccine_VaccinesType_VaccineTypeId",
                        column: x => x.VaccineTypeId,
                        principalTable: "VaccinesType",
                        principalColumn: "VaccineTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vaccine_VaccineTypeId",
                table: "Vaccine",
                column: "VaccineTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vaccine");

            migrationBuilder.DropTable(
                name: "VaccinesType");
        }
    }
}