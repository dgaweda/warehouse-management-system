using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryProduct_Pallets_PalletId",
                table: "DeliveryProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_DeliveryProduct_DeliveryProductId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_MagazineProduct_MagazineProductId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLine_MagazineProduct_MagazineProductId",
                table: "OrderLine");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLine_Order_OrderId",
                table: "OrderLine");

            migrationBuilder.DropForeignKey(
                name: "FK_Pallets_Order_OrderId",
                table: "Pallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderLine",
                table: "OrderLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MagazineProduct",
                table: "MagazineProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryProduct",
                table: "DeliveryProduct");

            migrationBuilder.RenameTable(
                name: "OrderLine",
                newName: "OrderLines");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "MagazineProduct",
                newName: "MagazineProducts");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.RenameTable(
                name: "DeliveryProduct",
                newName: "DeliveryProducts");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLine_OrderId",
                table: "OrderLines",
                newName: "IX_OrderLines_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLine_MagazineProductId",
                table: "OrderLines",
                newName: "IX_OrderLines_MagazineProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Location_MagazineProductId",
                table: "Locations",
                newName: "IX_Locations_MagazineProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Location_DeliveryProductId",
                table: "Locations",
                newName: "IX_Locations_DeliveryProductId");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryProduct_PalletId",
                table: "DeliveryProducts",
                newName: "IX_DeliveryProducts_PalletId");

            migrationBuilder.AddColumn<bool>(
                name: "Special",
                table: "Locations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderLines",
                table: "OrderLines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MagazineProducts",
                table: "MagazineProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryProducts",
                table: "DeliveryProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryProducts_Pallets_PalletId",
                table: "DeliveryProducts",
                column: "PalletId",
                principalTable: "Pallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Orders_OrderId",
                table: "OrderLines",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pallets_Orders_OrderId",
                table: "Pallets",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryProducts_Pallets_PalletId",
                table: "DeliveryProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_DeliveryProducts_DeliveryProductId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_MagazineProducts_MagazineProductId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_MagazineProducts_MagazineProductId",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Orders_OrderId",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Pallets_Orders_OrderId",
                table: "Pallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderLines",
                table: "OrderLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MagazineProducts",
                table: "MagazineProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryProducts",
                table: "DeliveryProducts");

            migrationBuilder.DropColumn(
                name: "Special",
                table: "Locations");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "OrderLines",
                newName: "OrderLine");

            migrationBuilder.RenameTable(
                name: "MagazineProducts",
                newName: "MagazineProduct");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.RenameTable(
                name: "DeliveryProducts",
                newName: "DeliveryProduct");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLine",
                newName: "IX_OrderLine_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLines_MagazineProductId",
                table: "OrderLine",
                newName: "IX_OrderLine_MagazineProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_MagazineProductId",
                table: "Location",
                newName: "IX_Location_MagazineProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_DeliveryProductId",
                table: "Location",
                newName: "IX_Location_DeliveryProductId");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryProducts_PalletId",
                table: "DeliveryProduct",
                newName: "IX_DeliveryProduct_PalletId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderLine",
                table: "OrderLine",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MagazineProduct",
                table: "MagazineProduct",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryProduct",
                table: "DeliveryProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryProduct_Pallets_PalletId",
                table: "DeliveryProduct",
                column: "PalletId",
                principalTable: "Pallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_DeliveryProduct_DeliveryProductId",
                table: "Location",
                column: "DeliveryProductId",
                principalTable: "DeliveryProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_MagazineProduct_MagazineProductId",
                table: "Location",
                column: "MagazineProductId",
                principalTable: "MagazineProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLine_MagazineProduct_MagazineProductId",
                table: "OrderLine",
                column: "MagazineProductId",
                principalTable: "MagazineProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLine_Order_OrderId",
                table: "OrderLine",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pallets_Order_OrderId",
                table: "Pallets",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
