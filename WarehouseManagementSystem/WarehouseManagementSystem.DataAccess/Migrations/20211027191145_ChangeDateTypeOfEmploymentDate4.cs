using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ChangeDateTypeOfEmploymentDate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EmploymentDate",
                table: "Seniorities",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EmploymentDate",
                table: "Seniorities",
                type: "datetime4",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
