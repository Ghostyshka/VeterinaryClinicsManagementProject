using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceTypeTreatmentPlanMedicalsType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ServiceTypeId",
                table: "Service",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Service",
                type: "numeric(8,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.CreateTable(
                name: "ServiceType",
                columns: table => new
                {
                    ServiceTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceType", x => x.ServiceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentPlanItem",
                columns: table => new
                {
                    PlanItemId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlanId = table.Column<int>(type: "integer", nullable: false),
                    ServiceId = table.Column<int>(type: "integer", nullable: false),
                    MedicalId = table.Column<int>(type: "integer", nullable: false),
                    ItemDescription = table.Column<string>(type: "text", nullable: false),
                    Dosage = table.Column<double>(type: "double precision", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentPlanItem", x => x.PlanItemId);
                    table.ForeignKey(
                        name: "FK_TreatmentPlanItem_Medicals_MedicalId",
                        column: x => x.MedicalId,
                        principalTable: "Medicals",
                        principalColumn: "MedicalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentPlanItem_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentPlanItem_TreatmentPlan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "TreatmentPlan",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentPlan_ServiceTypeId",
                table: "TreatmentPlan",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_MedicalId",
                table: "Service",
                column: "MedicalId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_ServiceTypeId",
                table: "Service",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicals_MedicalTypeId",
                table: "Medicals",
                column: "MedicalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentPlanItem_MedicalId",
                table: "TreatmentPlanItem",
                column: "MedicalId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentPlanItem_PlanId",
                table: "TreatmentPlanItem",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentPlanItem_ServiceId",
                table: "TreatmentPlanItem",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicals_MedicalsTypes_MedicalTypeId",
                table: "Medicals",
                column: "MedicalTypeId",
                principalTable: "MedicalsTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Medicals_MedicalId",
                table: "Service",
                column: "MedicalId",
                principalTable: "Medicals",
                principalColumn: "MedicalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_ServiceType_ServiceTypeId",
                table: "Service",
                column: "ServiceTypeId",
                principalTable: "ServiceType",
                principalColumn: "ServiceTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentPlan_ServiceType_ServiceTypeId",
                table: "TreatmentPlan",
                column: "ServiceTypeId",
                principalTable: "ServiceType",
                principalColumn: "ServiceTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicals_MedicalsTypes_MedicalTypeId",
                table: "Medicals");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_Medicals_MedicalId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_ServiceType_ServiceTypeId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentPlan_ServiceType_ServiceTypeId",
                table: "TreatmentPlan");

            migrationBuilder.DropTable(
                name: "ServiceType");

            migrationBuilder.DropTable(
                name: "TreatmentPlanItem");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentPlan_ServiceTypeId",
                table: "TreatmentPlan");

            migrationBuilder.DropIndex(
                name: "IX_Service_MedicalId",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_ServiceTypeId",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Medicals_MedicalTypeId",
                table: "Medicals");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceTypeId",
                table: "Service",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Service",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(8,2)");
        }
    }
}
