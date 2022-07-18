using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class RenameEntityColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Wiek",
                table: "Users",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "Nazwa użytkownika",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Hasło",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Data zatrudnienia",
                table: "Seniorities",
                newName: "EmploymentDate");

            migrationBuilder.RenameColumn(
                name: "Nazwa produktu",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Kod kreskowy",
                table: "Products",
                newName: "Barcode");

            migrationBuilder.RenameColumn(
                name: "Data ważności",
                table: "Products",
                newName: "ExpirationDate");

            migrationBuilder.RenameColumn(
                name: "Kod kreskowy",
                table: "Pallets",
                newName: "Barcode");

            migrationBuilder.RenameColumn(
                name: "Aktualny status palety",
                table: "Pallets",
                newName: "PalletStatus");

            migrationBuilder.RenameColumn(
                name: "Ilość danego produktu na palecie",
                table: "PalletRow",
                newName: "ProductAmount");

            migrationBuilder.RenameColumn(
                name: "Stan zamówienia",
                table: "Orders",
                newName: "OrderState");

            migrationBuilder.RenameColumn(
                name: "Kod kreskowy",
                table: "Orders",
                newName: "Barcode");

            migrationBuilder.RenameColumn(
                name: "Czas zakończenia zamówienia",
                table: "Orders",
                newName: "PickingEnd");

            migrationBuilder.RenameColumn(
                name: "Czas rozpoczęcia zamówienia",
                table: "Orders",
                newName: "PickingStart");

            migrationBuilder.RenameColumn(
                name: "Ilość",
                table: "OrderRow",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "Cena",
                table: "OrderRow",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Typ lokalizacji",
                table: "Locations",
                newName: "LocationType");

            migrationBuilder.RenameColumn(
                name: "Nazwa lokalizacji",
                table: "Locations",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Maksymalna ilość",
                table: "Locations",
                newName: "MaxAmount");

            migrationBuilder.RenameColumn(
                name: "Aktualna ilość",
                table: "Locations",
                newName: "CurrentAmount");

            migrationBuilder.RenameColumn(
                name: "Numer faktury",
                table: "Invoices",
                newName: "InvoiceNumber");

            migrationBuilder.RenameColumn(
                name: "Nazwa dostawcy",
                table: "Invoices",
                newName: "Provider");

            migrationBuilder.RenameColumn(
                name: "Data i godzina stworzenia faktury",
                table: "Invoices",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "Data i godzina podpisania faktury",
                table: "Invoices",
                newName: "ReceiptDateTime");

            migrationBuilder.RenameColumn(
                name: "Status wyjazdu",
                table: "Departures",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "Nazwa wyjazdu",
                table: "Departures",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Czas zamknięcia wyjazdu",
                table: "Departures",
                newName: "CloseTime");

            migrationBuilder.RenameColumn(
                name: "Czas otworzenia wyjazdu",
                table: "Departures",
                newName: "OpeningTime");

            migrationBuilder.RenameColumn(
                name: "Nazwa dostawcy",
                table: "Deliveries",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Data i godzina przyjazdu dostawy",
                table: "Deliveries",
                newName: "Arrival");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "Nazwa użytkownika");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "Hasło");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Users",
                newName: "Wiek");

            migrationBuilder.RenameColumn(
                name: "EmploymentDate",
                table: "Seniorities",
                newName: "Data zatrudnienia");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "Nazwa produktu");

            migrationBuilder.RenameColumn(
                name: "ExpirationDate",
                table: "Products",
                newName: "Data ważności");

            migrationBuilder.RenameColumn(
                name: "Barcode",
                table: "Products",
                newName: "Kod kreskowy");

            migrationBuilder.RenameColumn(
                name: "PalletStatus",
                table: "Pallets",
                newName: "Aktualny status palety");

            migrationBuilder.RenameColumn(
                name: "Barcode",
                table: "Pallets",
                newName: "Kod kreskowy");

            migrationBuilder.RenameColumn(
                name: "ProductAmount",
                table: "PalletRow",
                newName: "Ilość danego produktu na palecie");

            migrationBuilder.RenameColumn(
                name: "PickingStart",
                table: "Orders",
                newName: "Czas rozpoczęcia zamówienia");

            migrationBuilder.RenameColumn(
                name: "PickingEnd",
                table: "Orders",
                newName: "Czas zakończenia zamówienia");

            migrationBuilder.RenameColumn(
                name: "OrderState",
                table: "Orders",
                newName: "Stan zamówienia");

            migrationBuilder.RenameColumn(
                name: "Barcode",
                table: "Orders",
                newName: "Kod kreskowy");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "OrderRow",
                newName: "Cena");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "OrderRow",
                newName: "Ilość");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Locations",
                newName: "Nazwa lokalizacji");

            migrationBuilder.RenameColumn(
                name: "MaxAmount",
                table: "Locations",
                newName: "Maksymalna ilość");

            migrationBuilder.RenameColumn(
                name: "LocationType",
                table: "Locations",
                newName: "Typ lokalizacji");

            migrationBuilder.RenameColumn(
                name: "CurrentAmount",
                table: "Locations",
                newName: "Aktualna ilość");

            migrationBuilder.RenameColumn(
                name: "ReceiptDateTime",
                table: "Invoices",
                newName: "Data i godzina podpisania faktury");

            migrationBuilder.RenameColumn(
                name: "Provider",
                table: "Invoices",
                newName: "Nazwa dostawcy");

            migrationBuilder.RenameColumn(
                name: "InvoiceNumber",
                table: "Invoices",
                newName: "Numer faktury");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Invoices",
                newName: "Data i godzina stworzenia faktury");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Departures",
                newName: "Status wyjazdu");

            migrationBuilder.RenameColumn(
                name: "OpeningTime",
                table: "Departures",
                newName: "Czas otworzenia wyjazdu");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Departures",
                newName: "Nazwa wyjazdu");

            migrationBuilder.RenameColumn(
                name: "CloseTime",
                table: "Departures",
                newName: "Czas zamknięcia wyjazdu");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Deliveries",
                newName: "Nazwa dostawcy");

            migrationBuilder.RenameColumn(
                name: "Arrival",
                table: "Deliveries",
                newName: "Data i godzina przyjazdu dostawy");
        }
    }
}
