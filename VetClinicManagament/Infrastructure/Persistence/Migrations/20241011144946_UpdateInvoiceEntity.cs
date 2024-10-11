using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInvoiceEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Visit_VisitId1",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Invoice_InvoiceId",
                table: "Visit");

            migrationBuilder.DropIndex(
                name: "IX_Visit_InvoiceId",
                table: "Visit");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_VisitId1",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "VisitId1",
                table: "Invoice");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_VisitId",
                table: "Invoice",
                column: "VisitId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Visit_VisitId",
                table: "Invoice",
                column: "VisitId",
                principalTable: "Visit",
                principalColumn: "VisitId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Visit_VisitId",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_VisitId",
                table: "Invoice");

            migrationBuilder.AddColumn<int>(
                name: "VisitId1",
                table: "Invoice",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Visit_InvoiceId",
                table: "Visit",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_VisitId1",
                table: "Invoice",
                column: "VisitId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Visit_VisitId1",
                table: "Invoice",
                column: "VisitId1",
                principalTable: "Visit",
                principalColumn: "VisitId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Invoice_InvoiceId",
                table: "Visit",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
