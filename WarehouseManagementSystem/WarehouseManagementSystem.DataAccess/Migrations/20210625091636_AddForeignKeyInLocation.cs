using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddForeignKeyInLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_DeliveryProducts_DeliveryProductId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_MagazineProducts_MagazineProductId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_DeliveryProductId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_MagazineProductId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "DeliveryProductId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "MagazineProductId",
                table: "Locations");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ProductId",
                table: "Locations",
                column: "ProductId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_DeliveryProducts_ProductId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_MagazineProducts_ProductId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_ProductId",
                table: "Locations");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryProductId",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MagazineProductId",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_DeliveryProductId",
                table: "Locations",
                column: "DeliveryProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_MagazineProductId",
                table: "Locations",
                column: "MagazineProductId");

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
        }
    }
}
