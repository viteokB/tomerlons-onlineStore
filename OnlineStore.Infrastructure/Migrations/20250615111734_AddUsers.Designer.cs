﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineStore.Repository;

#nullable disable

namespace OnlineStore.Repository.Migrations
{
    [DbContext(typeof(OnlineStoreDbContext))]
    [Migration("20250615111734_AddUsers")]
    partial class AddUsers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.6");

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("ApartmentNumber")
                        .HasColumnType("varchar(10)")
                        .HasColumnName("apartment_number");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("country");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasColumnName("house_number");

                    b.Property<double>("Latitude")
                        .HasColumnType("REAL")
                        .HasColumnName("latitude");

                    b.Property<double>("Longitude")
                        .HasColumnType("REAL")
                        .HasColumnName("longitude");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("street");

                    b.HasKey("Id");

                    b.ToTable("address", (string)null);
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("Name")
                        .HasDatabaseName("ix_brands_name");

                    b.ToTable("brands", (string)null);
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseCountry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(3)")
                        .HasColumnName("code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .HasDatabaseName("ix_country_name");

                    b.ToTable("country", (string)null);
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseDeliveryStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("delivery_status", (string)null);
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseDeliveryZones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("DeliveryDays")
                        .HasColumnType("INTEGER")
                        .HasColumnName("delivery_days");

                    b.Property<float>("DeliveryPrice")
                        .HasColumnType("REAL")
                        .HasColumnName("delivery_price");

                    b.Property<string>("MaxDistance")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("max_distance");

                    b.Property<string>("MinDistance")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("min_distance");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<int>("WharehouseId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("wharehouse_id");

                    b.HasKey("Id");

                    b.HasIndex("WharehouseId");

                    b.ToTable("delivery_zones", (string)null);
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseDeliveryZonesHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeliveryDays")
                        .HasColumnType("INTEGER");

                    b.Property<float>("DeliveryPrice")
                        .HasColumnType("REAL");

                    b.Property<int>("DeliveryZoneId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MaxDistance")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MinDistance")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("WharehouseId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryZoneId");

                    b.HasIndex("WharehouseId");

                    b.ToTable("DeliveryZonesHistory");
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int?>("ChangedById")
                        .HasColumnType("INTEGER")
                        .HasColumnName("changed_by");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER")
                        .HasColumnName("count");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<int>("DeliveryAddressId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("delivery_address_id");

                    b.Property<int>("DeliveryDays")
                        .HasColumnType("INTEGER")
                        .HasColumnName("delivery_days");

                    b.Property<float>("DeliveryPrice")
                        .HasColumnType("REAL")
                        .HasColumnName("delivery_price");

                    b.Property<int>("DeliveryStatusId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("delivery_status_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("product_id");

                    b.Property<float>("ProductPrice")
                        .HasColumnType("REAL")
                        .HasColumnName("product_price");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("user_id");

                    b.Property<int>("WharehouseId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("wharehouse_id");

                    b.HasKey("Id");

                    b.HasIndex("ChangedById");

                    b.HasIndex("DeliveryAddressId");

                    b.HasIndex("DeliveryStatusId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.HasIndex("WharehouseId");

                    b.ToTable("order", (string)null);
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseOrderHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChangedById")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChangedByUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("DeliveryAddressId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeliveryDays")
                        .HasColumnType("INTEGER");

                    b.Property<float>("DeliveryPrice")
                        .HasColumnType("REAL");

                    b.Property<int>("DeliveryStatusId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderHistoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("ProductPrice")
                        .HasColumnType("REAL");

                    b.Property<int>("TypeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WharehouseId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ChangedByUserId");

                    b.HasIndex("DeliveryAddressId");

                    b.HasIndex("DeliveryStatusId");

                    b.HasIndex("OrderHistoryId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserId");

                    b.HasIndex("WharehouseId");

                    b.ToTable("DatabaseOrderHistory");
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("BasePrice")
                        .HasColumnType("base_price");

                    b.Property<int?>("BrandId")
                        .HasColumnType("brand_id");

                    b.Property<string>("CatalogNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ChangedAt")
                        .HasColumnType("changed_at");

                    b.Property<int?>("ChangedById")
                        .HasColumnType("changed_by");

                    b.Property<int?>("CountryId")
                        .HasColumnType("country_id");

                    b.Property<bool>("IsActive")
                        .HasColumnType("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("TypeId")
                        .HasColumnType("type_id");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ChangedById");

                    b.HasIndex("CountryId");

                    b.HasIndex("TypeId");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseProductHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("BasePrice")
                        .HasColumnType("REAL");

                    b.Property<int>("BrandId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CatalogNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ChangedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("ChangedById")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ChangedById");

                    b.HasIndex("CountryId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TypeId");

                    b.ToTable("ProductsHistory");
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .HasDatabaseName("ix_role_name");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("types", (string)null);
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("varchar(64)")
                        .HasColumnName("hashed_password");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_user_email");

                    b.HasIndex("HashedPassword")
                        .HasDatabaseName("ix_hashed_password");

                    b.HasIndex("RoleId");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseWharehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("address_id");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_acitve");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("wharehouse", (string)null);
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseWharehouseProdHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ChangedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("ChangedById")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WarehouseProdId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WharehouseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WharehouseProductsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ChangedById");

                    b.HasIndex("ProductId");

                    b.HasIndex("WharehouseId");

                    b.HasIndex("WharehouseProductsId");

                    b.ToTable("WarehousesProductsHistory");
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseWharehouseProducts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ChangedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("changed_at");

                    b.Property<int?>("ChangedById")
                        .HasColumnType("INTEGER")
                        .HasColumnName("changed_by");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER")
                        .HasColumnName("count");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("product_id");

                    b.Property<int>("WharehouseId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ChangedById");

                    b.HasIndex("ProductId");

                    b.HasIndex("WharehouseId");

                    b.ToTable("warehouse_products", (string)null);
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseBrand", b =>
                {
                    b.HasOne("OnlineStore.Repository.Models.DatabaseCountry", "Country")
                        .WithMany("Brands")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseDeliveryZones", b =>
                {
                    b.HasOne("OnlineStore.Repository.Models.DatabaseWharehouse", "Wharehouse")
                        .WithMany()
                        .HasForeignKey("WharehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wharehouse");
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseDeliveryZonesHistory", b =>
                {
                    b.HasOne("OnlineStore.Repository.Models.DatabaseDeliveryZones", "DeliveryZone")
                        .WithMany()
                        .HasForeignKey("DeliveryZoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineStore.Repository.Models.DatabaseWharehouse", "Wharehouse")
                        .WithMany()
                        .HasForeignKey("WharehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryZone");

                    b.Navigation("Wharehouse");
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseOrder", b =>
                {
                    b.HasOne("OnlineStore.Repository.Models.DatabaseUser", "ChangedByUser")
                        .WithMany()
                        .HasForeignKey("ChangedById")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("OnlineStore.Repository.Models.DatabaseAddress", "DeliveryAddress")
                        .WithMany()
                        .HasForeignKey("DeliveryAddressId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OnlineStore.Repository.Models.DatabaseDeliveryStatus", "DeliveryStatus")
                        .WithMany("Orders")
                        .HasForeignKey("DeliveryStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OnlineStore.Repository.Models.DatabaseProduct", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OnlineStore.Repository.Models.DatabaseUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("OnlineStore.Repository.Models.DatabaseWharehouse", "Wharehouse")
                        .WithMany("WhOrders")
                        .HasForeignKey("WharehouseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ChangedByUser");

                    b.Navigation("DeliveryAddress");

                    b.Navigation("DeliveryStatus");

                    b.Navigation("Product");

                    b.Navigation("User");

                    b.Navigation("Wharehouse");
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseOrderHistory", b =>
                {
                    b.HasOne("OnlineStore.Repository.Models.DatabaseUser", "ChangedByUser")
                        .WithMany()
                        .HasForeignKey("ChangedByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineStore.Repository.Models.DatabaseAddress", "DeliveryAddress")
                        .WithMany("Orders")
                        .HasForeignKey("DeliveryAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineStore.Repository.Models.DatabaseDeliveryStatus", "DeliveryStatus")
                        .WithMany()
                        .HasForeignKey("DeliveryStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineStore.Repository.Models.DatabaseOrderHistory", "OrderHistory")
                        .WithMany()
                        .HasForeignKey("OrderHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineStore.Repository.Models.DatabaseProduct", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineStore.Repository.Models.DatabaseType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineStore.Repository.Models.DatabaseUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("OnlineStore.Repository.Models.DatabaseWharehouse", "Wharehouse")
                        .WithMany()
                        .HasForeignKey("WharehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChangedByUser");

                    b.Navigation("DeliveryAddress");

                    b.Navigation("DeliveryStatus");

                    b.Navigation("OrderHistory");

                    b.Navigation("Product");

                    b.Navigation("Type");

                    b.Navigation("User");

                    b.Navigation("Wharehouse");
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseProduct", b =>
                {
                    b.HasOne("OnlineStore.Repository.Models.DatabaseBrand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("OnlineStore.Repository.Models.DatabaseUser", "ChangedBy")
                        .WithMany()
                        .HasForeignKey("ChangedById")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("OnlineStore.Repository.Models.DatabaseCountry", "Country")
                        .WithMany("Products")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("OnlineStore.Repository.Models.DatabaseType", "Type")
                        .WithMany("Products")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Brand");

                    b.Navigation("ChangedBy");

                    b.Navigation("Country");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseProductHistory", b =>
                {
                    b.HasOne("OnlineStore.Repository.Models.DatabaseBrand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineStore.Repository.Models.DatabaseUser", "ChangedBy")
                        .WithMany()
                        .HasForeignKey("ChangedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineStore.Repository.Models.DatabaseCountry", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineStore.Repository.Models.DatabaseProduct", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineStore.Repository.Models.DatabaseType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("ChangedBy");

                    b.Navigation("Country");

                    b.Navigation("Product");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseUser", b =>
                {
                    b.HasOne("OnlineStore.Repository.Models.DatabaseRole", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseWharehouse", b =>
                {
                    b.HasOne("OnlineStore.Repository.Models.DatabaseAddress", "Address")
                        .WithMany("Wharehouses")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseWharehouseProdHistory", b =>
                {
                    b.HasOne("OnlineStore.Repository.Models.DatabaseUser", "ChangedBy")
                        .WithMany()
                        .HasForeignKey("ChangedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineStore.Repository.Models.DatabaseProduct", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineStore.Repository.Models.DatabaseWharehouseProducts", "Wharehouse")
                        .WithMany()
                        .HasForeignKey("WharehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineStore.Repository.Models.DatabaseWharehouseProducts", "WharehouseProducts")
                        .WithMany()
                        .HasForeignKey("WharehouseProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChangedBy");

                    b.Navigation("Product");

                    b.Navigation("Wharehouse");

                    b.Navigation("WharehouseProducts");
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseWharehouseProducts", b =>
                {
                    b.HasOne("OnlineStore.Repository.Models.DatabaseUser", "ChangedBy")
                        .WithMany()
                        .HasForeignKey("ChangedById")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("OnlineStore.Repository.Models.DatabaseProduct", "Product")
                        .WithMany("WhProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineStore.Repository.Models.DatabaseWharehouse", "Wharehouse")
                        .WithMany("WhProducts")
                        .HasForeignKey("WharehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChangedBy");

                    b.Navigation("Product");

                    b.Navigation("Wharehouse");
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseAddress", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Wharehouses");
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseBrand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseCountry", b =>
                {
                    b.Navigation("Brands");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseDeliveryStatus", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseProduct", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("WhProducts");
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseRole", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseType", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("OnlineStore.Repository.Models.DatabaseWharehouse", b =>
                {
                    b.Navigation("WhOrders");

                    b.Navigation("WhProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
