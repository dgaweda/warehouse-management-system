using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ChangeNameOfProductAndPalletTableMANYtoMANY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PalletLines");

            migrationBuilder.CreateTable(
                name: "ProductPalletLines",
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
                    table.PrimaryKey("PK_ProductPalletLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPalletLines_Pallets_PalletId",
                        column: x => x.PalletId,
                        principalTable: "Pallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPalletLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPalletLines_PalletId",
                table: "ProductPalletLines",
                column: "PalletId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPalletLines_ProductId",
                table: "ProductPalletLines",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPalletLines");

            migrationBuilder.CreateTable(
                name: "PalletLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PalletId = table.Column<int>(type: "int", nullable: false),
                    ProductAmount = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
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
        }
    }
}
