using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class SmallEntitiesChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Special",
                table: "MagazineProducts");

            migrationBuilder.DropColumn(
                name: "Special",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Special",
                table: "DeliveryProducts");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Orders",
                newName: "PickingStart");

            migrationBuilder.RenameColumn(
                name: "Completion",
                table: "Orders",
                newName: "PickingEnd");

            migrationBuilder.RenameColumn(
                name: "Expiration",
                table: "MagazineProducts",
                newName: "ExpirationDate");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Locations",
                newName: "CurrentAmount");

            migrationBuilder.RenameColumn(
                name: "Expiration",
                table: "DeliveryProducts",
                newName: "ExpirationDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EmploymentDate",
                table: "Seniorities",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PickingStart",
                table: "Orders",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "PickingEnd",
                table: "Orders",
                newName: "Completion");

            migrationBuilder.RenameColumn(
                name: "ExpirationDate",
                table: "MagazineProducts",
                newName: "Expiration");

            migrationBuilder.RenameColumn(
                name: "CurrentAmount",
                table: "Locations",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "ExpirationDate",
                table: "DeliveryProducts",
                newName: "Expiration");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EmploymentDate",
                table: "Seniorities",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "Special",
                table: "MagazineProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Special",
                table: "Locations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Special",
                table: "DeliveryProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
