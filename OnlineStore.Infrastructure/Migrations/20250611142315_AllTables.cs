using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace OnlineStore.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Sqlite:InitSpatialMetaData", true);

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    country = table.Column<string>(type: "varchar(100)", nullable: false),
                    city = table.Column<string>(type: "varchar(100)", nullable: false),
                    street = table.Column<string>(type: "varchar(100)", nullable: false),
                    house_number = table.Column<string>(type: "varchar(10)", nullable: false),
                    apartment_number = table.Column<string>(type: "varchar(10)", nullable: true),
                    coordinate = table.Column<Point>(type: "POINT", nullable: false)
                        .Annotation("Sqlite:Srid", 4326)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "varchar(50)", nullable: false),
                    code = table.Column<string>(type: "varchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "delivery_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "types",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "varchar(50)", nullable: false),
                    description = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "wharehouse",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    address_id = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wharehouse", x => x.id);
                    table.ForeignKey(
                        name: "FK_wharehouse_address_address_id",
                        column: x => x.address_id,
                        principalTable: "address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CountryId = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_brands_country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "delivery_zones",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    wharehouse_id = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    min_distance = table.Column<string>(type: "TEXT", nullable: false),
                    max_distance = table.Column<string>(type: "TEXT", nullable: false),
                    delivery_price = table.Column<float>(type: "REAL", nullable: false),
                    delivery_days = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery_zones", x => x.id);
                    table.ForeignKey(
                        name: "FK_delivery_zones_wharehouse_wharehouse_id",
                        column: x => x.wharehouse_id,
                        principalTable: "wharehouse",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeId = table.Column<int>(type: "type_id", nullable: true),
                    CountryId = table.Column<int>(type: "country_id", nullable: true),
                    ChangedById = table.Column<int>(type: "changed_by", nullable: true),
                    BrandId = table.Column<int>(type: "brand_id", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    CatalogNumber = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    BasePrice = table.Column<float>(type: "base_price", nullable: false),
                    IsActive = table.Column<bool>(type: "is_active", nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "changed_at", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_products_country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_products_types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_products_users_ChangedById",
                        column: x => x.ChangedById,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DatabaseOrderHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderHistoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    DeliveryAddressId = table.Column<int>(type: "INTEGER", nullable: false),
                    TypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    DeliveryStatusId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    WharehouseId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChangedById = table.Column<int>(type: "INTEGER", nullable: false),
                    ChangedByUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductPrice = table.Column<float>(type: "REAL", nullable: false),
                    DeliveryPrice = table.Column<float>(type: "REAL", nullable: false),
                    DeliveryDays = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatabaseOrderHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatabaseOrderHistory_DatabaseOrderHistory_OrderHistoryId",
                        column: x => x.OrderHistoryId,
                        principalTable: "DatabaseOrderHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatabaseOrderHistory_address_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalTable: "address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatabaseOrderHistory_delivery_status_DeliveryStatusId",
                        column: x => x.DeliveryStatusId,
                        principalTable: "delivery_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatabaseOrderHistory_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatabaseOrderHistory_types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatabaseOrderHistory_users_ChangedByUserId",
                        column: x => x.ChangedByUserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatabaseOrderHistory_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_DatabaseOrderHistory_wharehouse_WharehouseId",
                        column: x => x.WharehouseId,
                        principalTable: "wharehouse",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_id = table.Column<int>(type: "INTEGER", nullable: true),
                    delivery_address_id = table.Column<int>(type: "INTEGER", nullable: false),
                    delivery_status_id = table.Column<int>(type: "INTEGER", nullable: false),
                    product_id = table.Column<int>(type: "INTEGER", nullable: false),
                    wharehouse_id = table.Column<int>(type: "INTEGER", nullable: false),
                    changed_by = table.Column<int>(type: "INTEGER", nullable: true),
                    count = table.Column<int>(type: "INTEGER", nullable: false),
                    product_price = table.Column<float>(type: "REAL", nullable: false),
                    delivery_price = table.Column<float>(type: "REAL", nullable: false),
                    delivery_days = table.Column<int>(type: "INTEGER", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_address_delivery_address_id",
                        column: x => x.delivery_address_id,
                        principalTable: "address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_delivery_status_delivery_status_id",
                        column: x => x.delivery_status_id,
                        principalTable: "delivery_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_users_changed_by",
                        column: x => x.changed_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_order_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_order_wharehouse_wharehouse_id",
                        column: x => x.wharehouse_id,
                        principalTable: "wharehouse",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "warehouse_products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    product_id = table.Column<int>(type: "INTEGER", nullable: false),
                    WharehouseId = table.Column<int>(type: "INTEGER", nullable: false),
                    changed_by = table.Column<int>(type: "INTEGER", nullable: true),
                    count = table.Column<int>(type: "INTEGER", nullable: false),
                    changed_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_warehouse_products_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_warehouse_products_users_changed_by",
                        column: x => x.changed_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_warehouse_products_wharehouse_WharehouseId",
                        column: x => x.WharehouseId,
                        principalTable: "wharehouse",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_brands_CountryId",
                table: "brands",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "ix_brands_name",
                table: "brands",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_country_name",
                table: "country",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_DatabaseOrderHistory_ChangedByUserId",
                table: "DatabaseOrderHistory",
                column: "ChangedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DatabaseOrderHistory_DeliveryAddressId",
                table: "DatabaseOrderHistory",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_DatabaseOrderHistory_DeliveryStatusId",
                table: "DatabaseOrderHistory",
                column: "DeliveryStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DatabaseOrderHistory_OrderHistoryId",
                table: "DatabaseOrderHistory",
                column: "OrderHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DatabaseOrderHistory_ProductId",
                table: "DatabaseOrderHistory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DatabaseOrderHistory_TypeId",
                table: "DatabaseOrderHistory",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DatabaseOrderHistory_UserId",
                table: "DatabaseOrderHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DatabaseOrderHistory_WharehouseId",
                table: "DatabaseOrderHistory",
                column: "WharehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_delivery_zones_wharehouse_id",
                table: "delivery_zones",
                column: "wharehouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_changed_by",
                table: "order",
                column: "changed_by");

            migrationBuilder.CreateIndex(
                name: "IX_order_delivery_address_id",
                table: "order",
                column: "delivery_address_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_delivery_status_id",
                table: "order",
                column: "delivery_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_product_id",
                table: "order",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_user_id",
                table: "order",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_wharehouse_id",
                table: "order",
                column: "wharehouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_BrandId",
                table: "products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_products_ChangedById",
                table: "products",
                column: "ChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_products_CountryId",
                table: "products",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_products_TypeId",
                table: "products",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_products_changed_by",
                table: "warehouse_products",
                column: "changed_by");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_products_product_id",
                table: "warehouse_products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_products_WharehouseId",
                table: "warehouse_products",
                column: "WharehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_wharehouse_address_id",
                table: "wharehouse",
                column: "address_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatabaseOrderHistory");

            migrationBuilder.DropTable(
                name: "delivery_zones");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "warehouse_products");

            migrationBuilder.DropTable(
                name: "delivery_status");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "wharehouse");

            migrationBuilder.DropTable(
                name: "brands");

            migrationBuilder.DropTable(
                name: "types");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Sqlite:InitSpatialMetaData", true);
        }
    }
}
