using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class PropertiesChangesInInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceReceiptDate",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "InvoiceDate",
                table: "Invoices",
                newName: "ReceiptDateTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Invoices",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "ReceiptDateTime",
                table: "Invoices",
                newName: "InvoiceDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "InvoiceReceiptDate",
                table: "Invoices",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
