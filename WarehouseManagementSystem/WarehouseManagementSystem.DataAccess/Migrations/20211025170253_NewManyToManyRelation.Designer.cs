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
    [Migration("20211025170253_NewManyToManyRelation")]
    partial class NewManyToManyRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccess.Entities.Delivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Arrival")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("CompanyName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("DataAccess.Entities.DeliveryProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("DeliveryProducts");
                });

            modelBuilder.Entity("DataAccess.Entities.DeliveryProductPalletLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeliveryProductId")
                        .HasColumnType("int");

                    b.Property<int>("PalletId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryProductId");

                    b.HasIndex("PalletId");

                    b.ToTable("DeliveryProductPalletLines");
                });

            modelBuilder.Entity("DataAccess.Entities.Departure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Departures");
                });

            modelBuilder.Entity("DataAccess.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DataAccess.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentAmount")
                        .HasColumnType("int");

                    b.Property<int?>("DeliveryProductId")
                        .HasColumnType("int");

                    b.Property<int?>("MagazineProductId")
                        .HasColumnType("int");

                    b.Property<int>("MaxAmount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryProductId");

                    b.HasIndex("MagazineProductId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("DataAccess.Entities.MagazineProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.ToTable("MagazineProducts");
                });

            modelBuilder.Entity("DataAccess.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("PickingEnd")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime?>("PickingStart")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DataAccess.Entities.OrderLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("MagazineProductId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("MagazineProductId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("DataAccess.Entities.Pallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("DeliveryId")
                        .HasColumnType("int");

                    b.Property<int?>("DepartureId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryId");

                    b.HasIndex("DepartureId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("OrderId");

                    b.ToTable("Pallets");
                });

            modelBuilder.Entity("DataAccess.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DataAccess.Entities.Seniority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EmploymentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EmploymentDuration")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Seniorities");
                });

            modelBuilder.Entity("DataAccess.Entities.DeliveryProductPalletLine", b =>
                {
                    b.HasOne("DataAccess.Entities.DeliveryProduct", "DeliveryProduct")
                        .WithMany("DeliveryProductPalletLines")
                        .HasForeignKey("DeliveryProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Entities.Pallet", "Pallet")
                        .WithMany("DeliveryProductPalletLines")
                        .HasForeignKey("PalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryProduct");

                    b.Navigation("Pallet");
                });

            modelBuilder.Entity("DataAccess.Entities.Employee", b =>
                {
                    b.HasOne("DataAccess.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DataAccess.Entities.Location", b =>
                {
                    b.HasOne("DataAccess.Entities.DeliveryProduct", "DeliveryProduct")
                        .WithMany("Locations")
                        .HasForeignKey("DeliveryProductId");

                    b.HasOne("DataAccess.Entities.MagazineProduct", "MagazineProduct")
                        .WithMany("Locations")
                        .HasForeignKey("MagazineProductId");

                    b.Navigation("DeliveryProduct");

                    b.Navigation("MagazineProduct");
                });

            modelBuilder.Entity("DataAccess.Entities.OrderLine", b =>
                {
                    b.HasOne("DataAccess.Entities.MagazineProduct", "MagazineProduct")
                        .WithMany("OrderLines")
                        .HasForeignKey("MagazineProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Entities.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MagazineProduct");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("DataAccess.Entities.Pallet", b =>
                {
                    b.HasOne("DataAccess.Entities.Delivery", "Delivery")
                        .WithMany("Pallets")
                        .HasForeignKey("DeliveryId");

                    b.HasOne("DataAccess.Entities.Departure", "Departure")
                        .WithMany("Pallets")
                        .HasForeignKey("DepartureId");

                    b.HasOne("DataAccess.Entities.Employee", "Employee")
                        .WithMany("Pallets")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("DataAccess.Entities.Order", "Order")
                        .WithMany("Pallets")
                        .HasForeignKey("OrderId");

                    b.Navigation("Delivery");

                    b.Navigation("Departure");

                    b.Navigation("Employee");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("DataAccess.Entities.Seniority", b =>
                {
                    b.HasOne("DataAccess.Entities.Employee", null)
                        .WithOne("Seniority")
                        .HasForeignKey("DataAccess.Entities.Seniority", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccess.Entities.Delivery", b =>
                {
                    b.Navigation("Pallets");
                });

            modelBuilder.Entity("DataAccess.Entities.DeliveryProduct", b =>
                {
                    b.Navigation("DeliveryProductPalletLines");

                    b.Navigation("Locations");
                });

            modelBuilder.Entity("DataAccess.Entities.Departure", b =>
                {
                    b.Navigation("Pallets");
                });

            modelBuilder.Entity("DataAccess.Entities.Employee", b =>
                {
                    b.Navigation("Pallets");

                    b.Navigation("Seniority");
                });

            modelBuilder.Entity("DataAccess.Entities.MagazineProduct", b =>
                {
                    b.Navigation("Locations");

                    b.Navigation("OrderLines");
                });

            modelBuilder.Entity("DataAccess.Entities.Order", b =>
                {
                    b.Navigation("OrderLines");

                    b.Navigation("Pallets");
                });

            modelBuilder.Entity("DataAccess.Entities.Pallet", b =>
                {
                    b.Navigation("DeliveryProductPalletLines");
                });
#pragma warning restore 612, 618
        }
    }
}
