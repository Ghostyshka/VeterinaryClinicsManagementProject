using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVisitInvoiceNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_InvoiceItem_InvoiceId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Invoice_InvoiceId",
                table: "Visit");

            migrationBuilder.DropColumn(
                name: "VisitId",
                table: "InvoiceItem");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "Invoice",
                newName: "UpdatedAt");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "Visit",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "Invoice",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "VisitId1",
                table: "Invoice",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_InvoiceId",
                table: "InvoiceItem",
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
                name: "FK_Invoice_Visit_VisitId1",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItem_Invoice_InvoiceId",
                table: "InvoiceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Invoice_InvoiceId",
                table: "Visit");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceItem_InvoiceId",
                table: "InvoiceItem");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_VisitId1",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "VisitId1",
                table: "Invoice");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Invoice",
                newName: "UpdateAt");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "Visit",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VisitId",
                table: "InvoiceItem",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "Invoice",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_InvoiceItem_InvoiceId",
                table: "Invoice",
                column: "InvoiceId",
                principalTable: "InvoiceItem",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Invoice_InvoiceId",
                table: "Visit",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}