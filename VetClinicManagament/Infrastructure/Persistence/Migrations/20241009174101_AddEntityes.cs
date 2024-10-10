using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddEntityes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Medicals_MedicalId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentPlanItem_Medicals_MedicalId",
                table: "TreatmentPlanItem");

            migrationBuilder.DropTable(
                name: "Medicals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalsTypes",
                table: "MedicalType");

            migrationBuilder.RenameTable(
                name: "MedicalType",
                newName: "MedicalType");

            migrationBuilder.AlterColumn<string>(
                name: "ItemDescription",
                table: "TreatmentPlanItem",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "TypeName",
                table: "MedicalType",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalType",
                table: "MedicalType",
                column: "TypeId");

            migrationBuilder.CreateTable(
                name: "Medical",
                columns: table => new
                {
                    MedicalId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicalName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MedicalTypeId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medical", x => x.MedicalId);
                    table.ForeignKey(
                        name: "FK_Medical_MedicalType_MedicalTypeId",
                        column: x => x.MedicalTypeId,
                        principalTable: "MedicalType",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medical_MedicalTypeId",
                table: "Medical",
                column: "MedicalTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Medical_MedicalId",
                table: "Service",
                column: "MedicalId",
                principalTable: "Medical",
                principalColumn: "MedicalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentPlanItem_Medical_MedicalId",
                table: "TreatmentPlanItem",
                column: "MedicalId",
                principalTable: "Medical",
                principalColumn: "MedicalId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Medical_MedicalId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentPlanItem_Medical_MedicalId",
                table: "TreatmentPlanItem");

            migrationBuilder.DropTable(
                name: "Medical");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalType",
                table: "MedicalType");

            migrationBuilder.RenameTable(
                name: "MedicalType",
                newName: "MedicalType");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AnimalOwner",
                newName: "MedicalId");

            migrationBuilder.AlterColumn<string>(
                name: "ItemDescription",
                table: "TreatmentPlanItem",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "TypeName",
                table: "MedicalType",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalsTypes",
                table: "MedicalType",
                column: "TypeId");

            migrationBuilder.CreateTable(
                name: "Medicals",
                columns: table => new
                {
                    MedicalId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicalTypeId = table.Column<int>(type: "integer", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MedicalName = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicals", x => x.MedicalId);
                    table.ForeignKey(
                        name: "FK_Medicals_MedicalsTypes_MedicalTypeId",
                        column: x => x.MedicalTypeId,
                        principalTable: "MedicalType",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicals_MedicalTypeId",
                table: "Medicals",
                column: "MedicalTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Medicals_MedicalId",
                table: "Service",
                column: "MedicalId",
                principalTable: "Medicals",
                principalColumn: "MedicalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentPlanItem_Medicals_MedicalId",
                table: "TreatmentPlanItem",
                column: "MedicalId",
                principalTable: "Medicals",
                principalColumn: "MedicalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
