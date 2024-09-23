using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVisitEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VisitId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    InvoiceStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceId);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentPlan",
                columns: table => new
                {
                    PlanId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TreatmentId = table.Column<int>(type: "integer", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "integer", nullable: false),
                    StartOfTreatment = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndOfTreatment = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    InClinic = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentPlan", x => x.PlanId);
                });

            migrationBuilder.CreateTable(
                name: "Visit",
                columns: table => new
                {
                    VisitId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataOfVisit = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    InvoiceId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    TreatmentId = table.Column<int>(type: "integer", nullable: false),
                    TreatmentPlanPlanId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visit", x => x.VisitId);
                    table.ForeignKey(
                        name: "FK_Visit_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visit_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visit_TreatmentPlan_TreatmentPlanPlanId",
                        column: x => x.TreatmentPlanPlanId,
                        principalTable: "TreatmentPlan",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visit_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visit_EmployeeId",
                table: "Visit",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_InvoiceId",
                table: "Visit",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_TreatmentPlanPlanId",
                table: "Visit",
                column: "TreatmentPlanPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_UserId",
                table: "Visit",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visit");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "TreatmentPlan");
        }
    }
}