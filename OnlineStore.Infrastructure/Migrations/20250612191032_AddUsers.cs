using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryZonesHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeliveryZoneId = table.Column<int>(type: "INTEGER", nullable: false),
                    WharehouseId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MinDistance = table.Column<string>(type: "TEXT", nullable: false),
                    MaxDistance = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryPrice = table.Column<float>(type: "REAL", nullable: false),
                    DeliveryDays = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryZonesHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryZonesHistory_delivery_zones_DeliveryZoneId",
                        column: x => x.DeliveryZoneId,
                        principalTable: "delivery_zones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryZonesHistory_wharehouse_WharehouseId",
                        column: x => x.WharehouseId,
                        principalTable: "wharehouse",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    CountryId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChangedById = table.Column<int>(type: "INTEGER", nullable: false),
                    BrandId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PhotoPath = table.Column<string>(type: "TEXT", nullable: false),
                    CatalogNumber = table.Column<string>(type: "TEXT", nullable: false),
                    BasePrice = table.Column<float>(type: "REAL", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsHistory_brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsHistory_country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsHistory_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsHistory_types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsHistory_users_ChangedById",
                        column: x => x.ChangedById,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WharehouseProductsHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WarehouseProdId = table.Column<int>(type: "INTEGER", nullable: false),
                    WharehouseProductsId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    WharehouseId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChangedById = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WharehouseProductsHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WharehouseProductsHistory_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WharehouseProductsHistory_users_ChangedById",
                        column: x => x.ChangedById,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WharehouseProductsHistory_warehouse_products_WharehouseId",
                        column: x => x.WharehouseId,
                        principalTable: "warehouse_products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WharehouseProductsHistory_warehouse_products_WharehouseProductsId",
                        column: x => x.WharehouseProductsId,
                        principalTable: "warehouse_products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryZonesHistory_DeliveryZoneId",
                table: "DeliveryZonesHistory",
                column: "DeliveryZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryZonesHistory_WharehouseId",
                table: "DeliveryZonesHistory",
                column: "WharehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsHistory_BrandId",
                table: "ProductsHistory",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsHistory_ChangedById",
                table: "ProductsHistory",
                column: "ChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsHistory_CountryId",
                table: "ProductsHistory",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsHistory_ProductId",
                table: "ProductsHistory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsHistory_TypeId",
                table: "ProductsHistory",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WharehouseProductsHistory_ChangedById",
                table: "WharehouseProductsHistory",
                column: "ChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_WharehouseProductsHistory_ProductId",
                table: "WharehouseProductsHistory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WharehouseProductsHistory_WharehouseId",
                table: "WharehouseProductsHistory",
                column: "WharehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_WharehouseProductsHistory_WharehouseProductsId",
                table: "WharehouseProductsHistory",
                column: "WharehouseProductsId");
            
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "role_id", "email", "hashed_password", "CreatedDate" },
                values: new object[] 
                {
                    1, // ID роли админа
                    "admin@root.com", 
                    "imaroot", // Замените на реальный хеш пароля
                    DateTime.UtcNow
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryZonesHistory");

            migrationBuilder.DropTable(
                name: "ProductsHistory");

            migrationBuilder.DropTable(
                name: "WharehouseProductsHistory");
            
            // Удаляем добавленного пользователя
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "email",
                keyValue: "admin@example.com");
        }
    }
}
