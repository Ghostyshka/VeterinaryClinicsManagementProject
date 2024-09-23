using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InvoiceItemEntityUpd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnimals_Animals_AnimalId",
                table: "UserAnimals");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnimals_Users_UserId",
                table: "UserAnimals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAnimals",
                table: "UserAnimals");

            migrationBuilder.RenameTable(
                name: "UserAnimals",
                newName: "AnimalOwner");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnimals_UserId",
                table: "AnimalOwner",
                newName: "IX_AnimalOwner_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnimals_AnimalId",
                table: "AnimalOwner",
                newName: "IX_AnimalOwner_AnimalId");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "Invoice",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimalOwner",
                table: "AnimalOwner",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "InvoiceItem",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvoiceId = table.Column<int>(type: "integer", nullable: false),
                    VisitId = table.Column<int>(type: "integer", nullable: false),
                    ItemType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItem", x => x.ItemId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalOwner_Animals_AnimalId",
                table: "AnimalOwner",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalOwner_Users_UserId",
                table: "AnimalOwner",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_InvoiceItem_InvoiceId",
                table: "Invoice",
                column: "InvoiceId",
                principalTable: "InvoiceItem",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalOwner_Animals_AnimalId",
                table: "AnimalOwner");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimalOwner_Users_UserId",
                table: "AnimalOwner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimalOwner",
                table: "AnimalOwner");

            migrationBuilder.RenameTable(
                name: "AnimalOwner",
                newName: "UserAnimals");

            migrationBuilder.RenameIndex(
                name: "IX_AnimalOwner_UserId",
                table: "UserAnimals",
                newName: "IX_UserAnimals_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AnimalOwner_AnimalId",
                table: "UserAnimals",
                newName: "IX_UserAnimals_AnimalId");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "Invoice",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAnimals",
                table: "UserAnimals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnimals_Animals_AnimalId",
                table: "UserAnimals",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnimals_Users_UserId",
                table: "UserAnimals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
