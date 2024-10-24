using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationsInVisit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Invoice_VisitId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "Visit");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_VisitId",
                table: "Invoice",
                column: "VisitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Invoice_VisitId",
                table: "Invoice");

            migrationBuilder.AddColumn<int>(
                name: "PlanId",
                table: "Visit",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_VisitId",
                table: "Invoice",
                column: "VisitId",
                unique: true);
        }
    }
}
