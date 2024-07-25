using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetClinic.Domain.Migrations
{
    /// <inheritdoc />
    public partial class VaccineEntityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnimalId",
                table: "Vaccine",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vaccine_AnimalId",
                table: "Vaccine",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccine_Animals_AnimalId",
                table: "Vaccine",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaccine_Animals_AnimalId",
                table: "Vaccine");

            migrationBuilder.DropIndex(
                name: "IX_Vaccine_AnimalId",
                table: "Vaccine");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "Vaccine");
        }
    }
}