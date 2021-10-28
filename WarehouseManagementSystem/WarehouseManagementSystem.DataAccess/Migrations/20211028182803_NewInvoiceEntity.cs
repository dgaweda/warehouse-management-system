using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class NewInvoiceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pallets_Deliveries_DeliveryId",
                table: "Pallets");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Deliveries");

            migrationBuilder.RenameColumn(
                name: "DeliveryId",
                table: "Pallets",
                newName: "InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Pallets_DeliveryId",
                table: "Pallets",
                newName: "IX_Pallets_InvoiceId");

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    From = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "date", nullable: false),
                    InvoiceReceiptDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    DeliveryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Deliveries_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Deliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_DeliveryId",
                table: "Invoices",
                column: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pallets_Invoices_InvoiceId",
                table: "Pallets",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pallets_Invoices_InvoiceId",
                table: "Pallets");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "Pallets",
                newName: "DeliveryId");

            migrationBuilder.RenameIndex(
                name: "IX_Pallets_InvoiceId",
                table: "Pallets",
                newName: "IX_Pallets_DeliveryId");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Deliveries",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pallets_Deliveries_DeliveryId",
                table: "Pallets",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
