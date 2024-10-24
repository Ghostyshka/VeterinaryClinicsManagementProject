using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationInVisit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visit_TreatmentPlan_PlanId",
                table: "Visit");

            migrationBuilder.DropIndex(
                name: "IX_Visit_PlanId",
                table: "Visit");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentPlan_VisitId",
                table: "TreatmentPlan",
                column: "VisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentPlan_Visit_VisitId",
                table: "TreatmentPlan",
                column: "VisitId",
                principalTable: "Visit",
                principalColumn: "VisitId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentPlan_Visit_VisitId",
                table: "TreatmentPlan");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentPlan_VisitId",
                table: "TreatmentPlan");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_PlanId",
                table: "Visit",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_TreatmentPlan_PlanId",
                table: "Visit",
                column: "PlanId",
                principalTable: "TreatmentPlan",
                principalColumn: "PlanId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
