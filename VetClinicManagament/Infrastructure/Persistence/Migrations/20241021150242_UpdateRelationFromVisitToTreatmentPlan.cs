using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationFromVisitToTreatmentPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visit_TreatmentPlan_TreatmentId",
                table: "Visit");

            migrationBuilder.DropColumn(
                name: "TreatmentId",
                table: "TreatmentPlan");

            migrationBuilder.RenameColumn(
                name: "TreatmentId",
                table: "Visit",
                newName: "PlanId");

            migrationBuilder.RenameIndex(
                name: "IX_Visit_TreatmentId",
                table: "Visit",
                newName: "IX_Visit_PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_TreatmentPlan_PlanId",
                table: "Visit",
                column: "PlanId",
                principalTable: "TreatmentPlan",
                principalColumn: "PlanId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visit_TreatmentPlan_PlanId",
                table: "Visit");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "Visit",
                newName: "TreatmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Visit_PlanId",
                table: "Visit",
                newName: "IX_Visit_TreatmentId");

            migrationBuilder.AddColumn<int>(
                name: "TreatmentId",
                table: "TreatmentPlan",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_TreatmentPlan_TreatmentId",
                table: "Visit",
                column: "TreatmentId",
                principalTable: "TreatmentPlan",
                principalColumn: "PlanId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
