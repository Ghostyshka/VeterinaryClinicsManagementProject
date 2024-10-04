using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVisitAddStatusAndDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visit_TreatmentPlan_TreatmentPlanPlanId",
                table: "Visit");

            migrationBuilder.DropIndex(
                name: "IX_Visit_TreatmentPlanPlanId",
                table: "Visit");

            migrationBuilder.RenameColumn(
                name: "TreatmentPlanPlanId",
                table: "Visit",
                newName: "Status");

            migrationBuilder.AlterColumn<int>(
                name: "TreatmentId",
                table: "Visit",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Visit",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_TreatmentId",
                table: "Visit",
                column: "TreatmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_TreatmentPlan_TreatmentId",
                table: "Visit",
                column: "TreatmentId",
                principalTable: "TreatmentPlan",
                principalColumn: "PlanId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visit_TreatmentPlan_TreatmentId",
                table: "Visit");

            migrationBuilder.DropIndex(
                name: "IX_Visit_TreatmentId",
                table: "Visit");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Visit");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Visit",
                newName: "TreatmentPlanPlanId");

            migrationBuilder.AlterColumn<int>(
                name: "TreatmentId",
                table: "Visit",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visit_TreatmentPlanPlanId",
                table: "Visit",
                column: "TreatmentPlanPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_TreatmentPlan_TreatmentPlanPlanId",
                table: "Visit",
                column: "TreatmentPlanPlanId",
                principalTable: "TreatmentPlan",
                principalColumn: "PlanId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
