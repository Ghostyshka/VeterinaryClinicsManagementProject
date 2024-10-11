using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInvoiceEntityWithNewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Visit_InvoiceId",
                table: "Visit",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Invoice_InvoiceId",
                table: "Visit",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "InvoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Invoice_InvoiceId",
                table: "Visit");

            migrationBuilder.DropIndex(
                name: "IX_Visit_InvoiceId",
                table: "Visit");
        }
    }
}
