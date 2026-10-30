using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Raname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ucet",
                table: "Ucet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kategorie",
                table: "Kategorie");

            migrationBuilder.RenameTable(
                name: "Ucet",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "Kategorie",
                newName: "Movies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "Kategorie");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Ucet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kategorie",
                table: "Kategorie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ucet",
                table: "Ucet",
                column: "Id");
        }
    }
}
