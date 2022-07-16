﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(WMSDatabaseContext))]
    [Migration("20220716195849_AddRankIdToRole")]
    partial class AddRankIdToRole
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccess.Entities.Delivery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Arrival")
                        .HasColumnType("smalldatetime")
                        .HasColumnName("Data i godzina przyjazdu dostawy");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nazwa dostawcy");

                    b.HasKey("Id");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("DataAccess.Entities.Departure", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CloseTime")
                        .HasColumnType("smalldatetime")
                        .HasColumnName("Czas zamknięcia wyjazdu");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nazwa wyjazdu");

                    b.Property<DateTime>("OpeningTime")
                        .HasColumnType("smalldatetime")
                        .HasColumnName("Czas otworzenia wyjazdu");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnName("Status wyjazdu");

                    b.HasKey("Id");

                    b.ToTable("Departures");
                });

            modelBuilder.Entity("DataAccess.Entities.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("date")
                        .HasColumnName("Data i godzina stworzenia faktury");

                    b.Property<Guid>("DeliveryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Numer faktury");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nazwa dostawcy");

                    b.Property<DateTime>("ReceiptDateTime")
                        .HasColumnType("smalldatetime")
                        .HasColumnName("Data i godzina podpisania faktury");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("DataAccess.Entities.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CurrentAmount")
                        .HasColumnType("int")
                        .HasColumnName("Aktualna ilość");

                    b.Property<int>("LocationType")
                        .HasColumnType("int")
                        .HasColumnName("Typ lokalizacji");

                    b.Property<int>("MaxAmount")
                        .HasColumnType("int")
                        .HasColumnName("Maksymalna ilość");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Nazwa lokalizacji");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("DataAccess.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Kod kreskowy");

                    b.Property<int>("OrderState")
                        .HasColumnType("int")
                        .HasColumnName("Stan zamówienia");

                    b.Property<DateTime?>("PickingEnd")
                        .HasColumnType("smalldatetime")
                        .HasColumnName("Czas zakończenia zamówienia");

                    b.Property<DateTime?>("PickingStart")
                        .HasColumnType("smalldatetime")
                        .HasColumnName("Czas rozpoczęcia zamówienia");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DataAccess.Entities.OrderLine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("Ilość");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("Cena");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("DataAccess.Entities.Pallet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Kod kreskowy");

                    b.Property<Guid?>("DepartureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("InvoiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PalletStatus")
                        .HasColumnType("int")
                        .HasColumnName("Aktualny status palety");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DepartureId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Pallets");
                });

            modelBuilder.Entity("DataAccess.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Kod kreskowy");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("date")
                        .HasColumnName("Data ważności");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nazwa produktu");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DataAccess.Entities.ProductPalletLine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PalletId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ProductAmount")
                        .HasColumnType("int")
                        .HasColumnName("Ilość danego produktu na palecie");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PalletId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPalletLines");
                });

            modelBuilder.Entity("DataAccess.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DataAccess.Entities.Seniority", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EmploymentDate")
                        .HasColumnType("date")
                        .HasColumnName("Data zatrudnienia");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Seniorities");
                });

            modelBuilder.Entity("DataAccess.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasColumnName("Wiek");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nazwisko");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Imię");

                    b.Property<string>("PESEL")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Hasło");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Nazwa użytkownika");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataAccess.Entities.Invoice", b =>
                {
                    b.HasOne("DataAccess.Entities.Delivery", "Delivery")
                        .WithMany("Invoices")
                        .HasForeignKey("DeliveryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Delivery");
                });

            modelBuilder.Entity("DataAccess.Entities.Location", b =>
                {
                    b.HasOne("DataAccess.Entities.Product", "Product")
                        .WithMany("Locations")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DataAccess.Entities.OrderLine", b =>
                {
                    b.HasOne("DataAccess.Entities.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DataAccess.Entities.Pallet", b =>
                {
                    b.HasOne("DataAccess.Entities.Departure", "Departure")
                        .WithMany("Pallets")
                        .HasForeignKey("DepartureId");

                    b.HasOne("DataAccess.Entities.Invoice", "Invoice")
                        .WithMany("Pallets")
                        .HasForeignKey("InvoiceId");

                    b.HasOne("DataAccess.Entities.Order", "Order")
                        .WithMany("Pallets")
                        .HasForeignKey("OrderId");

                    b.HasOne("DataAccess.Entities.User", "User")
                        .WithMany("Pallets")
                        .HasForeignKey("UserId");

                    b.Navigation("Departure");

                    b.Navigation("Invoice");

                    b.Navigation("Order");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.Entities.ProductPalletLine", b =>
                {
                    b.HasOne("DataAccess.Entities.Pallet", "Pallet")
                        .WithMany("PalletsProducts")
                        .HasForeignKey("PalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Entities.Product", "Product")
                        .WithMany("PalletLines")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pallet");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DataAccess.Entities.Seniority", b =>
                {
                    b.HasOne("DataAccess.Entities.User", "User")
                        .WithOne("Seniority")
                        .HasForeignKey("DataAccess.Entities.Seniority", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.Entities.User", b =>
                {
                    b.HasOne("DataAccess.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DataAccess.Entities.Delivery", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("DataAccess.Entities.Departure", b =>
                {
                    b.Navigation("Pallets");
                });

            modelBuilder.Entity("DataAccess.Entities.Invoice", b =>
                {
                    b.Navigation("Pallets");
                });

            modelBuilder.Entity("DataAccess.Entities.Order", b =>
                {
                    b.Navigation("OrderLines");

                    b.Navigation("Pallets");
                });

            modelBuilder.Entity("DataAccess.Entities.Pallet", b =>
                {
                    b.Navigation("PalletsProducts");
                });

            modelBuilder.Entity("DataAccess.Entities.Product", b =>
                {
                    b.Navigation("Locations");

                    b.Navigation("PalletLines");
                });

            modelBuilder.Entity("DataAccess.Entities.User", b =>
                {
                    b.Navigation("Pallets");

                    b.Navigation("Seniority");
                });
#pragma warning restore 612, 618
        }
    }
}
