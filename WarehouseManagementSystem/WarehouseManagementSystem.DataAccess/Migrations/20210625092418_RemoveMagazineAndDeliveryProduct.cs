using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class RemoveMagazineAndDeliveryProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_DeliveryProducts_ProductId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_MagazineProducts_ProductId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_MagazineProducts_MagazineProductId",
                table: "OrderLines");

            migrationBuilder.DropTable(
                name: "DeliveryProducts");

            migrationBuilder.DropTable(
                name: "MagazineProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_MagazineProductId",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "MagazineProductId",
                table: "OrderLines");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "date", nullable: false),
                    Special = table.Column<bool>(type: "bit", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    PalletId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Pallets_PalletId",
                        column: x => x.PalletId,
                        principalTable: "Pallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ProductId",
                table: "OrderLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PalletId",
                table: "Products",
                column: "PalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Products_ProductId",
                table: "Locations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Products_ProductId",
                table: "OrderLines",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Products_ProductId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Products_ProductId",
                table: "OrderLines");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_ProductId",
                table: "OrderLines");

            migrationBuilder.AddColumn<int>(
                name: "MagazineProductId",
                table: "OrderLines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DeliveryProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "date", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PalletId = table.Column<int>(type: "int", nullable: true),
                    Special = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryProducts_Pallets_PalletId",
                        column: x => x.PalletId,
                        principalTable: "Pallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MagazineProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "date", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Special = table.Column<bool>(type: "bit", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagazineProducts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_MagazineProductId",
                table: "OrderLines",
                column: "MagazineProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryProducts_PalletId",
                table: "DeliveryProducts",
                column: "PalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_DeliveryProducts_ProductId",
                table: "Locations",
                column: "ProductId",
                principalTable: "DeliveryProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_MagazineProducts_ProductId",
                table: "Locations",
                column: "ProductId",
                principalTable: "MagazineProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_MagazineProducts_MagazineProductId",
                table: "OrderLines",
                column: "MagazineProductId",
                principalTable: "MagazineProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
