using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class RenameEntityColumns2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nazwisko",
                table: "Users",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "Imię",
                table: "Users",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "Imię");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Users",
                newName: "Nazwisko");
        }
    }
}
