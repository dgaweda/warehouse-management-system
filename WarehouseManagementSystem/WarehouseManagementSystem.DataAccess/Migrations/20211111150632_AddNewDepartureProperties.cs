using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddNewDepartureProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "Departures");

            migrationBuilder.AddColumn<DateTime>(
                name: "CloseTime",
                table: "Departures",
                type: "smalldatetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Departures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CloseTime",
                table: "Departures");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Departures");

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureTime",
                table: "Departures",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
