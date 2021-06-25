using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class RemovedPriceInOrderLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_MagazineProducts_MagazineProductId",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderLines");

            migrationBuilder.AlterColumn<int>(
                name: "MagazineProductId",
                table: "OrderLines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_MagazineProducts_MagazineProductId",
                table: "OrderLines",
                column: "MagazineProductId",
                principalTable: "MagazineProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_MagazineProducts_MagazineProductId",
                table: "OrderLines");

            migrationBuilder.AlterColumn<int>(
                name: "MagazineProductId",
                table: "OrderLines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "OrderLines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "OrderLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
