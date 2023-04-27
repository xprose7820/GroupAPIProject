﻿// <auto-generated />
using System;
using GroupAPIProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GroupAPIProject.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GroupAPIProject.Data.Entities.CustomerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("GroupAPIProject.Data.Entities.InventoryItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PurchaseOrderId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("PurchaseOrderId");

                    b.ToTable("InventoryItems");
                });

            modelBuilder.Entity("GroupAPIProject.Data.Entities.LocationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RetailerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RetailerId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("GroupAPIProject.Data.Entities.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("GroupAPIProject.Data.Entities.PurchaseOrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("OrderDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("RetailerId")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RetailerId");

                    b.HasIndex("SupplierId");

                    b.ToTable("PurchaseOrders");
                });

            modelBuilder.Entity("GroupAPIProject.Data.Entities.PurchaseOrderItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseOrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PurchaseOrderId");

                    b.ToTable("PurchaseOrderItems");
                });

            modelBuilder.Entity("GroupAPIProject.Data.Entities.SalesOrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CusomterId")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("OrderDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("RetailerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CusomterId");

                    b.HasIndex("LocationId");

                    b.HasIndex("RetailerId");

                    b.ToTable("SalesOrders");
                });

            modelBuilder.Entity("GroupAPIProject.Data.Entities.SalesOrderItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SalesOrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SalesOrderId");

                    b.ToTable("SalesOrderItems");
                });

            modelBuilder.Entity("GroupAPIProject.Data.Entities.SupplierEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("GroupAPIProject.Data.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("UserType").HasValue("UserEntity");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("GroupAPIProject.Data.Entities.AdminEntity", b =>
                {
                    b.HasBaseType("GroupAPIProject.Data.Entities.UserEntity");

                    b.HasDiscriminator().HasValue("AdminEntity");
                });

            modelBuilder.Entity("GroupAPIProject.Data.Entities.RetailerEntity", b =>
                {
                    b.HasBaseType("GroupAPIProject.Data.Entities.UserEntity");

                    b.HasDiscriminator().HasValue("RetailerEntity");
                });

            modelBuilder.Entity("GroupAPIProject.Data.Entities.InventoryItemEntity", b =>
                {
                    b.HasOne("GroupAPIProject.Data.Entities.LocationEntity", "Location")
                        .WithMany("ListOfInventoryItems")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupAPIProject.Data.Entities.PurchaseOrderEntity", "PurchaseOrder")
                        .WithMany("ListOfInventoryItems")
                        .HasForeignKey("PurchaseOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("PurchaseOrder");
                });

            modelBuilder.Entity("GroupAPIProject.Data.Entities.LocationEntity", b =>
                {
                    b.HasOne("GroupAPIProject.Data.Entities.RetailerEntity", "Retailer")
                        .WithMany("Locations")
                        .HasForeignKey("RetailerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Retailer");
                });

            modelBuilder.Entity("GroupAPIProject.Data.Entities.ProductEntity", b =>
                {
                    b.HasOne("GroupAPIProject.Data.Entities.SupplierEntity", "Supplier")
                        .WithMany("ListOfProducts")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("GroupAPIProject.Data.Entities.PurchaseOrderEntity", b =>
                {
                    b.HasOne("GroupAPIProject.Data.Entities.RetailerEntity", "Retailer")
                        .WithMany("PurchaseOrders")
                        .HasForeignKey("RetailerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupAPIProject.Data.Entities.SupplierEntity", "Supplier")
                        .WithMany("ListOfPurchaseOrders")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Retailer");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("GroupAPIProject.Data.Entities.PurchaseOrderItemEntity", b =>
                {
                    b.HasOne("GroupAPIProject.Data.Entities.PurchaseOrderEntity", "PurchaseOrder")
                        .WithMany("ListOfPurchaseOrderItems")
                        .HasForeignKey("PurchaseOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PurchaseOrder");
                });

            modelBuilder.Entity("GroupAPIProject.Data.Entities.SalesOrderEntity", b =>
                {
                    b.HasOne("GroupAPIProject.Data.Entities.CustomerEntity", "Customer")
                        .WithMany("ListOfSalesOrders")
                        .HasForeignKey("CusomterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GroupAPIProject.Data.Entities.LocationEntity", "Location")
                        .WithMany("ListOfSalesOrders")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GroupAPIProject.Data.Entities.RetailerEntity", "Retailer")
                        .WithMany("SalesOrders")
                        .HasForeignKey("RetailerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Location");

                    b.Navigation("Retailer");
                });

            modelBuilder.Entity("GroupAPIProject.Data.Entities.SalesOrderItemEntity", b =>
                {
                    b.HasOne("GroupAPIProject.Data.Entities.SalesOrderEntity", "SalesOrder")
                        .WithMany("ListOfSalesOrderItems")
                        .HasForeignKey("SalesOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SalesOrder");
                });

            modelBuilder.Entity("GroupAPIProject.Data.Entities.CustomerEntity", b =>
                {
                    b.Navigation("ListOfSalesOrders");
                });

            modelBuilder.Entity("GroupAPIProject.Data.Entities.LocationEntity", b =>
                {
                    b.Navigation("ListOfInventoryItems");

                    b.Navigation("ListOfSalesOrders");
                });

            modelBuilder.Entity("GroupAPIProject.Data.Entities.PurchaseOrderEntity", b =>
                {
                    b.Navigation("ListOfInventoryItems");

                    b.Navigation("ListOfPurchaseOrderItems");
                });

            modelBuilder.Entity("GroupAPIProject.Data.Entities.SalesOrderEntity", b =>
                {
                    b.Navigation("ListOfSalesOrderItems");
                });

            modelBuilder.Entity("GroupAPIProject.Data.Entities.SupplierEntity", b =>
                {
                    b.Navigation("ListOfProducts");

                    b.Navigation("ListOfPurchaseOrders");
                });

            modelBuilder.Entity("GroupAPIProject.Data.Entities.RetailerEntity", b =>
                {
                    b.Navigation("Locations");

                    b.Navigation("PurchaseOrders");

                    b.Navigation("SalesOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
