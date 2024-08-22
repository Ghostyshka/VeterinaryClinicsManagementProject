using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VetClinic.Domain.Migrations
{
    /// <inheritdoc />
    public partial class ToAdTreatmetPlans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TreatmentPlanId",
                table: "Treatment",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TreatmentPlanId",
                table: "Medicals",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TreatmentPlan",
                columns: table => new
                {
                    TreatmentPlanId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlanName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsAdministeredAtClinic = table.Column<bool>(type: "boolean", nullable: false),
                    AnimalId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentPlan", x => x.TreatmentPlanId);
                    table.ForeignKey(
                        name: "FK_TreatmentPlan_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_TreatmentPlanId",
                table: "Treatment",
                column: "TreatmentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicals_TreatmentPlanId",
                table: "Medicals",
                column: "TreatmentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentPlan_AnimalId",
                table: "TreatmentPlan",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicals_TreatmentPlan_TreatmentPlanId",
                table: "Medicals",
                column: "TreatmentPlanId",
                principalTable: "TreatmentPlan",
                principalColumn: "TreatmentPlanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treatment_TreatmentPlan_TreatmentPlanId",
                table: "Treatment",
                column: "TreatmentPlanId",
                principalTable: "TreatmentPlan",
                principalColumn: "TreatmentPlanId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicals_TreatmentPlan_TreatmentPlanId",
                table: "Medicals");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatment_TreatmentPlan_TreatmentPlanId",
                table: "Treatment");

            migrationBuilder.DropTable(
                name: "TreatmentPlan");

            migrationBuilder.DropIndex(
                name: "IX_Treatment_TreatmentPlanId",
                table: "Treatment");

            migrationBuilder.DropIndex(
                name: "IX_Medicals_TreatmentPlanId",
                table: "Medicals");

            migrationBuilder.DropColumn(
                name: "TreatmentPlanId",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "TreatmentPlanId",
                table: "Medicals");
        }
    }
}
