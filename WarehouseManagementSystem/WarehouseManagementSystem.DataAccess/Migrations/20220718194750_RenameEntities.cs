using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class RenameEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderRow_Orders_OrderId",
                table: "OrderRow");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderRow_Products_ProductId",
                table: "OrderRow");

            migrationBuilder.DropForeignKey(
                name: "FK_PalletRow_Pallets_PalletId",
                table: "PalletRow");

            migrationBuilder.DropForeignKey(
                name: "FK_PalletRow_Products_ProductId",
                table: "PalletRow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PalletRow",
                table: "PalletRow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderRow",
                table: "OrderRow");

            migrationBuilder.RenameTable(
                name: "PalletRow",
                newName: "PalletRows");

            migrationBuilder.RenameTable(
                name: "OrderRow",
                newName: "OrderRows");

            migrationBuilder.RenameIndex(
                name: "IX_PalletRow_ProductId",
                table: "PalletRows",
                newName: "IX_PalletRows_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_PalletRow_PalletId",
                table: "PalletRows",
                newName: "IX_PalletRows_PalletId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderRow_ProductId",
                table: "OrderRows",
                newName: "IX_OrderRows_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderRow_OrderId",
                table: "OrderRows",
                newName: "IX_OrderRows_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PalletRows",
                table: "PalletRows",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderRows",
                table: "OrderRows",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Orders_OrderId",
                table: "OrderRows",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Products_ProductId",
                table: "OrderRows",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PalletRows_Pallets_PalletId",
                table: "PalletRows",
                column: "PalletId",
                principalTable: "Pallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PalletRows_Products_ProductId",
                table: "PalletRows",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Orders_OrderId",
                table: "OrderRows");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Products_ProductId",
                table: "OrderRows");

            migrationBuilder.DropForeignKey(
                name: "FK_PalletRows_Pallets_PalletId",
                table: "PalletRows");

            migrationBuilder.DropForeignKey(
                name: "FK_PalletRows_Products_ProductId",
                table: "PalletRows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PalletRows",
                table: "PalletRows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderRows",
                table: "OrderRows");

            migrationBuilder.RenameTable(
                name: "PalletRows",
                newName: "PalletRow");

            migrationBuilder.RenameTable(
                name: "OrderRows",
                newName: "OrderRow");

            migrationBuilder.RenameIndex(
                name: "IX_PalletRows_ProductId",
                table: "PalletRow",
                newName: "IX_PalletRow_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_PalletRows_PalletId",
                table: "PalletRow",
                newName: "IX_PalletRow_PalletId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderRows_ProductId",
                table: "OrderRow",
                newName: "IX_OrderRow_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderRows_OrderId",
                table: "OrderRow",
                newName: "IX_OrderRow_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PalletRow",
                table: "PalletRow",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderRow",
                table: "OrderRow",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRow_Orders_OrderId",
                table: "OrderRow",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRow_Products_ProductId",
                table: "OrderRow",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PalletRow_Pallets_PalletId",
                table: "PalletRow",
                column: "PalletId",
                principalTable: "Pallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PalletRow_Products_ProductId",
                table: "PalletRow",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
