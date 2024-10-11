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
                name: "FK_InvoiceItem_Invoice_InvoiceItemId",
                table: "InvoiceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Invoice_InvoiceItemId",
                table: "Visit");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "Visit",
                newName: "InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Visit_InvoiceItemId",
                table: "Visit",
                newName: "IX_Visit_InvoiceId");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "InvoiceItem",
                newName: "InvoiceItemItemId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItem_InvoiceItemId",
                table: "InvoiceItem",
                newName: "IX_InvoiceItem_InvoiceItemItemId");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "Invoice",
                newName: "InvoiceId");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "InvoiceItem",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_InvoiceId",
                table: "InvoiceItem",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItem_InvoiceItem_InvoiceItemItemId",
                table: "InvoiceItem",
                column: "InvoiceItemItemId",
                principalTable: "InvoiceItem",
                principalColumn: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItem_Invoice_InvoiceId",
                table: "InvoiceItem",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Invoice_InvoiceId",
                table: "Visit",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItem_InvoiceItem_InvoiceItemItemId",
                table: "InvoiceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItem_Invoice_InvoiceId",
                table: "InvoiceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Invoice_InvoiceId",
                table: "Visit");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceItem_InvoiceId",
                table: "InvoiceItem");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "InvoiceItem");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "Visit",
                newName: "InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Visit_InvoiceId",
                table: "Visit",
                newName: "IX_Visit_InvoiceItemId");

            migrationBuilder.RenameColumn(
                name: "InvoiceItemItemId",
                table: "InvoiceItem",
                newName: "InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItem_InvoiceItemItemId",
                table: "InvoiceItem",
                newName: "IX_InvoiceItem_InvoiceItemId");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "Invoice",
                newName: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItem_Invoice_InvoiceItemId",
                table: "InvoiceItem",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Invoice_InvoiceItemId",
                table: "Visit",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
