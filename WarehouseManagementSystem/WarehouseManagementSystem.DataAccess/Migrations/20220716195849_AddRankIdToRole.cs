using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddRankIdToRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Wynagrodzenie",
                table: "Roles",
                newName: "Salary");

            migrationBuilder.RenameColumn(
                name: "Opis roli",
                table: "Roles",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Nazwa roli",
                table: "Roles",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Roles");

            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "Roles",
                newName: "Wynagrodzenie");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Roles",
                newName: "Nazwa roli");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Roles",
                newName: "Opis roli");
        }
    }
}
