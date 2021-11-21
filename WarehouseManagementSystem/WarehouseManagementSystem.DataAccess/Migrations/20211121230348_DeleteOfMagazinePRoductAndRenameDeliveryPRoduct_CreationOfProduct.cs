using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class DeleteOfMagazinePRoductAndRenameDeliveryPRoduct_CreationOfProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_DeliveryProducts_DeliveryProductId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_MagazineProducts_MagazineProductId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_MagazineProducts_MagazineProductId",
                table: "OrderLines");

            migrationBuilder.DropTable(
                name: "DeliveryProductPalletLines");

            migrationBuilder.DropTable(
                name: "MagazineProducts");

            migrationBuilder.DropTable(
                name: "DeliveryProducts");

            migrationBuilder.DropIndex(
                name: "IX_Locations_DeliveryProductId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "DeliveryProductId",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "MagazineProductId",
                table: "OrderLines",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLines_MagazineProductId",
                table: "OrderLines",
                newName: "IX_OrderLines_ProductId");

            migrationBuilder.RenameColumn(
                name: "MagazineProductId",
                table: "Locations",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_MagazineProductId",
                table: "Locations",
                newName: "IX_Locations_ProductId");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpirationDate = table.Column<DateTime>(type: "date", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PalletLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PalletId = table.Column<int>(type: "int", nullable: false),
                    ProductAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PalletLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PalletLines_Pallets_PalletId",
                        column: x => x.PalletId,
                        principalTable: "Pallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PalletLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PalletLines_PalletId",
                table: "PalletLines",
                column: "PalletId");

            migrationBuilder.CreateIndex(
                name: "IX_PalletLines_ProductId",
                table: "PalletLines",
                column: "ProductId");

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
                name: "PalletLines");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderLines",
                newName: "MagazineProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLines_ProductId",
                table: "OrderLines",
                newName: "IX_OrderLines_MagazineProductId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Locations",
                newName: "MagazineProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_ProductId",
                table: "Locations",
                newName: "IX_Locations_MagazineProductId");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryProductId",
                table: "Locations",
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
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MagazineProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "date", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagazineProducts", x => x.Id);
                });

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
                name: "IX_Locations_DeliveryProductId",
                table: "Locations",
                column: "DeliveryProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryProductPalletLines_DeliveryProductId",
                table: "DeliveryProductPalletLines",
                column: "DeliveryProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryProductPalletLines_PalletId",
                table: "DeliveryProductPalletLines",
                column: "PalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_DeliveryProducts_DeliveryProductId",
                table: "Locations",
                column: "DeliveryProductId",
                principalTable: "DeliveryProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_MagazineProducts_MagazineProductId",
                table: "Locations",
                column: "MagazineProductId",
                principalTable: "MagazineProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_MagazineProducts_MagazineProductId",
                table: "OrderLines",
                column: "MagazineProductId",
                principalTable: "MagazineProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
