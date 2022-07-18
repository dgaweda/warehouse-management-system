using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class IdenttiyChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "ProductPalletLines");

            migrationBuilder.DropTable(
                name: "Seniorities");

            migrationBuilder.DropTable(
                name: "Pallets");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Departures");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "Roles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dataigodzinaprzyjazdudostawy = table.Column<DateTime>(name: "Data i godzina przyjazdu dostawy", type: "smalldatetime", nullable: false),
                    Nazwadostawcy = table.Column<string>(name: "Nazwa dostawcy", type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Czaszamknięciawyjazdu = table.Column<DateTime>(name: "Czas zamknięcia wyjazdu", type: "smalldatetime", nullable: true),
                    Nazwawyjazdu = table.Column<string>(name: "Nazwa wyjazdu", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Czasotworzeniawyjazdu = table.Column<DateTime>(name: "Czas otworzenia wyjazdu", type: "smalldatetime", nullable: false),
                    Statuswyjazdu = table.Column<int>(name: "Status wyjazdu", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kodkreskowy = table.Column<string>(name: "Kod kreskowy", type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Stanzamówienia = table.Column<int>(name: "Stan zamówienia", type: "int", nullable: false),
                    Czaszakończeniazamówienia = table.Column<DateTime>(name: "Czas zakończenia zamówienia", type: "smalldatetime", nullable: true),
                    Czasrozpoczęciazamówienia = table.Column<DateTime>(name: "Czas rozpoczęcia zamówienia", type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kodkreskowy = table.Column<string>(name: "Kod kreskowy", type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Dataważności = table.Column<DateTime>(name: "Data ważności", type: "date", nullable: false),
                    Nazwaproduktu = table.Column<string>(name: "Nazwa produktu", type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opisroli = table.Column<string>(name: "Opis roli", type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Nazwaroli = table.Column<string>(name: "Nazwa roli", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Wynagrodzenie = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dataigodzinastworzeniafaktury = table.Column<DateTime>(name: "Data i godzina stworzenia faktury", type: "date", nullable: false),
                    DeliveryId = table.Column<int>(type: "int", nullable: false),
                    Numerfaktury = table.Column<string>(name: "Numer faktury", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwadostawcy = table.Column<string>(name: "Nazwa dostawcy", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Dataigodzinapodpisaniafaktury = table.Column<DateTime>(name: "Data i godzina podpisania faktury", type: "smalldatetime", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aktualnailość = table.Column<int>(name: "Aktualna ilość", type: "int", nullable: false),
                    Typlokalizacji = table.Column<int>(name: "Typ lokalizacji", type: "int", nullable: false),
                    Maksymalnailość = table.Column<int>(name: "Maksymalna ilość", type: "int", nullable: false),
                    Nazwalokalizacji = table.Column<string>(name: "Nazwa lokalizacji", type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ilość = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wiek = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Imię = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PESEL = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Hasło = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Nazwaużytkownika = table.Column<string>(name: "Nazwa użytkownika", type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kodkreskowy = table.Column<string>(name: "Kod kreskowy", type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DepartureId = table.Column<int>(type: "int", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    Aktualnystatuspalety = table.Column<int>(name: "Aktualny status palety", type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pallets_Departures_DepartureId",
                        column: x => x.DepartureId,
                        principalTable: "Departures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pallets_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pallets_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pallets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seniorities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datazatrudnienia = table.Column<DateTime>(name: "Data zatrudnienia", type: "date", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seniorities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seniorities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPalletLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PalletId = table.Column<int>(type: "int", nullable: false),
                    Ilośćdanegoproduktunapalecie = table.Column<int>(name: "Ilość danego produktu na palecie", type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Invoices_DeliveryId",
                table: "Invoices",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ProductId",
                table: "Locations",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ProductId",
                table: "OrderLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Pallets_DepartureId",
                table: "Pallets",
                column: "DepartureId");

            migrationBuilder.CreateIndex(
                name: "IX_Pallets_InvoiceId",
                table: "Pallets",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Pallets_OrderId",
                table: "Pallets",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pallets_UserId",
                table: "Pallets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPalletLines_PalletId",
                table: "ProductPalletLines",
                column: "PalletId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPalletLines_ProductId",
                table: "ProductPalletLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Seniorities_UserId",
                table: "Seniorities",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }
    }
}
