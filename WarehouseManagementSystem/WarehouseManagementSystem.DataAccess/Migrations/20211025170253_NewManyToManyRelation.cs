using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class NewManyToManyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryProducts_Pallets_PalletId",
                table: "DeliveryProducts");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryProducts_PalletId",
                table: "DeliveryProducts");

            migrationBuilder.DropColumn(
                name: "PalletId",
                table: "DeliveryProducts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EmploymentDate",
                table: "Seniorities",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AddColumn<DateTime>(
                name: "EmploymentDuration",
                table: "Seniorities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "OrderLines",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Locations",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DeliveryProductPalletLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryProductId = table.Column<int>(type: "int", nullable: false),
                    PalletId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryProductPalletLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryProductPalletLines_DeliveryProducts_DeliveryProductId",
                        column: x => x.DeliveryProductId,
                        principalTable: "DeliveryProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryProductPalletLines_Pallets_PalletId",
                        column: x => x.PalletId,
                        principalTable: "Pallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pallets_EmployeeId",
                table: "Pallets",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryProductPalletLines_DeliveryProductId",
                table: "DeliveryProductPalletLines",
                column: "DeliveryProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryProductPalletLines_PalletId",
                table: "DeliveryProductPalletLines",
                column: "PalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pallets_Employees_EmployeeId",
                table: "Pallets",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pallets_Employees_EmployeeId",
                table: "Pallets");

            migrationBuilder.DropTable(
                name: "DeliveryProductPalletLines");

            migrationBuilder.DropIndex(
                name: "IX_Pallets_EmployeeId",
                table: "Pallets");

            migrationBuilder.DropColumn(
                name: "EmploymentDuration",
                table: "Seniorities");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderLines");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EmploymentDate",
                table: "Seniorities",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Locations",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<int>(
                name: "PalletId",
                table: "DeliveryProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryProducts_PalletId",
                table: "DeliveryProducts",
                column: "PalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryProducts_Pallets_PalletId",
                table: "DeliveryProducts",
                column: "PalletId",
                principalTable: "Pallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
