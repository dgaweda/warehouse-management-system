using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class IdentityChange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nazwadostawcy = table.Column<string>(name: "Nazwa dostawcy", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Dataigodzinaprzyjazdudostawy = table.Column<DateTime>(name: "Data i godzina przyjazdu dostawy", type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nazwawyjazdu = table.Column<string>(name: "Nazwa wyjazdu", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Statuswyjazdu = table.Column<int>(name: "Status wyjazdu", type: "int", nullable: false),
                    Czaszamknięciawyjazdu = table.Column<DateTime>(name: "Czas zamknięcia wyjazdu", type: "smalldatetime", nullable: true),
                    Czasotworzeniawyjazdu = table.Column<DateTime>(name: "Czas otworzenia wyjazdu", type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stanzamówienia = table.Column<int>(name: "Stan zamówienia", type: "int", nullable: false),
                    Kodkreskowy = table.Column<string>(name: "Kod kreskowy", type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Czasrozpoczęciazamówienia = table.Column<DateTime>(name: "Czas rozpoczęcia zamówienia", type: "smalldatetime", nullable: true),
                    Czaszakończeniazamówienia = table.Column<DateTime>(name: "Czas zakończenia zamówienia", type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dataważności = table.Column<DateTime>(name: "Data ważności", type: "date", nullable: false),
                    Nazwaproduktu = table.Column<string>(name: "Nazwa produktu", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Kodkreskowy = table.Column<string>(name: "Kod kreskowy", type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numerfaktury = table.Column<string>(name: "Numer faktury", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwadostawcy = table.Column<string>(name: "Nazwa dostawcy", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Dataigodzinastworzeniafaktury = table.Column<DateTime>(name: "Data i godzina stworzenia faktury", type: "date", nullable: false),
                    Dataigodzinapodpisaniafaktury = table.Column<DateTime>(name: "Data i godzina podpisania faktury", type: "smalldatetime", nullable: false),
                    DeliveryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Typlokalizacji = table.Column<int>(name: "Typ lokalizacji", type: "int", nullable: false),
                    Nazwalokalizacji = table.Column<string>(name: "Nazwa lokalizacji", type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Aktualnailość = table.Column<int>(name: "Aktualna ilość", type: "int", nullable: false),
                    Maksymalnailość = table.Column<int>(name: "Maksymalna ilość", type: "int", nullable: false)
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
                name: "OrderRow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ilość = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderRow_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderRow_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nazwaużytkownika = table.Column<string>(name: "Nazwa użytkownika", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Hasło = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Imię = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PESEL = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Wiek = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kodkreskowy = table.Column<string>(name: "Kod kreskowy", type: "nvarchar(10)", maxLength: 10, nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DepartureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Aktualnystatuspalety = table.Column<int>(name: "Aktualny status palety", type: "int", nullable: false)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Datazatrudnienia = table.Column<DateTime>(name: "Data zatrudnienia", type: "date", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "PalletRow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PalletId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ilośćdanegoproduktunapalecie = table.Column<int>(name: "Ilość danego produktu na palecie", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PalletRow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PalletRow_Pallets_PalletId",
                        column: x => x.PalletId,
                        principalTable: "Pallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PalletRow_Products_ProductId",
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
                name: "IX_OrderRow_OrderId",
                table: "OrderRow",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRow_ProductId",
                table: "OrderRow",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PalletRow_PalletId",
                table: "PalletRow",
                column: "PalletId");

            migrationBuilder.CreateIndex(
                name: "IX_PalletRow_ProductId",
                table: "PalletRow",
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
                name: "IX_Seniorities_UserId",
                table: "Seniorities",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "OrderRow");

            migrationBuilder.DropTable(
                name: "PalletRow");

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
    }
}
