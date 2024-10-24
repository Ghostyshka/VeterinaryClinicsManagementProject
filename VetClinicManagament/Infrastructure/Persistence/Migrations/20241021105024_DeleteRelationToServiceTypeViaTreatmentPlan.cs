using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DeleteRelationToServiceTypeViaTreatmentPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentPlan_ServiceType_ServiceTypeId",
                table: "TreatmentPlan");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceTypeId",
                table: "TreatmentPlan",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentPlan_ServiceType_ServiceTypeId",
                table: "TreatmentPlan",
                column: "ServiceTypeId",
                principalTable: "ServiceType",
                principalColumn: "ServiceTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentPlan_ServiceType_ServiceTypeId",
                table: "TreatmentPlan");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceTypeId",
                table: "TreatmentPlan",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentPlan_ServiceType_ServiceTypeId",
                table: "TreatmentPlan",
                column: "ServiceTypeId",
                principalTable: "ServiceType",
                principalColumn: "ServiceTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
