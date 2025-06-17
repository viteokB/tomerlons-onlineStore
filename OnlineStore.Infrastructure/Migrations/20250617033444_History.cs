using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Repository.Migrations
{
    /// <inheritdoc />
    public partial class History : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DatabaseOrderHistory_DatabaseOrderHistory_OrderHistoryId",
                table: "DatabaseOrderHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_DatabaseOrderHistory_address_DeliveryAddressId",
                table: "DatabaseOrderHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_DatabaseOrderHistory_delivery_status_DeliveryStatusId",
                table: "DatabaseOrderHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_DatabaseOrderHistory_products_ProductId",
                table: "DatabaseOrderHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_DatabaseOrderHistory_types_TypeId",
                table: "DatabaseOrderHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_DatabaseOrderHistory_users_ChangedByUserId",
                table: "DatabaseOrderHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_DatabaseOrderHistory_users_UserId",
                table: "DatabaseOrderHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_DatabaseOrderHistory_wharehouse_WharehouseId",
                table: "DatabaseOrderHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsHistory_brands_BrandId",
                table: "ProductsHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsHistory_country_CountryId",
                table: "ProductsHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsHistory_products_ProductId",
                table: "ProductsHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsHistory_types_TypeId",
                table: "ProductsHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsHistory_users_ChangedById",
                table: "ProductsHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_products_products_product_id",
                table: "warehouse_products");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_products_wharehouse_WharehouseId",
                table: "warehouse_products");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehousesProductsHistory_products_ProductId",
                table: "WarehousesProductsHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehousesProductsHistory_users_ChangedById",
                table: "WarehousesProductsHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehousesProductsHistory_warehouse_products_WharehouseId",
                table: "WarehousesProductsHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehousesProductsHistory_warehouse_products_WharehouseProductsId",
                table: "WarehousesProductsHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WarehousesProductsHistory",
                table: "WarehousesProductsHistory");

            migrationBuilder.DropIndex(
                name: "IX_WarehousesProductsHistory_WharehouseProductsId",
                table: "WarehousesProductsHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsHistory",
                table: "ProductsHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DatabaseOrderHistory",
                table: "DatabaseOrderHistory");

            migrationBuilder.DropIndex(
                name: "IX_DatabaseOrderHistory_ChangedByUserId",
                table: "DatabaseOrderHistory");

            migrationBuilder.DropIndex(
                name: "IX_DatabaseOrderHistory_OrderHistoryId",
                table: "DatabaseOrderHistory");

            migrationBuilder.DropIndex(
                name: "IX_DatabaseOrderHistory_TypeId",
                table: "DatabaseOrderHistory");

            migrationBuilder.DropColumn(
                name: "WharehouseProductsId",
                table: "WarehousesProductsHistory");

            migrationBuilder.DropColumn(
                name: "ChangedByUserId",
                table: "DatabaseOrderHistory");

            migrationBuilder.DropColumn(
                name: "OrderHistoryId",
                table: "DatabaseOrderHistory");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "DatabaseOrderHistory");

            migrationBuilder.RenameTable(
                name: "WarehousesProductsHistory",
                newName: "warehouse_products_history");

            migrationBuilder.RenameTable(
                name: "ProductsHistory",
                newName: "products_history");

            migrationBuilder.RenameTable(
                name: "DatabaseOrderHistory",
                newName: "order_history");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "warehouse_products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "WharehouseId",
                table: "warehouse_products",
                newName: "warehouse_id");

            migrationBuilder.RenameIndex(
                name: "IX_warehouse_products_WharehouseId",
                table: "warehouse_products",
                newName: "IX_warehouse_products_warehouse_id");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "warehouse_products_history",
                newName: "count");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "warehouse_products_history",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "WharehouseId",
                table: "warehouse_products_history",
                newName: "warehouse_id");

            migrationBuilder.RenameColumn(
                name: "WarehouseProdId",
                table: "warehouse_products_history",
                newName: "warehouse_prod_id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "warehouse_products_history",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "ChangedById",
                table: "warehouse_products_history",
                newName: "changed_by");

            migrationBuilder.RenameColumn(
                name: "ChangedAt",
                table: "warehouse_products_history",
                newName: "changed_at");

            migrationBuilder.RenameIndex(
                name: "IX_WarehousesProductsHistory_WharehouseId",
                table: "warehouse_products_history",
                newName: "IX_warehouse_products_history_warehouse_id");

            migrationBuilder.RenameIndex(
                name: "IX_WarehousesProductsHistory_ProductId",
                table: "warehouse_products_history",
                newName: "IX_warehouse_products_history_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_WarehousesProductsHistory_ChangedById",
                table: "warehouse_products_history",
                newName: "IX_warehouse_products_history_changed_by");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "products_history",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "products_history",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "products_history",
                newName: "type_id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "products_history",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "products_history",
                newName: "photo_path");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "products_history",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "products_history",
                newName: "country_id");

            migrationBuilder.RenameColumn(
                name: "ChangedById",
                table: "products_history",
                newName: "changed_by");

            migrationBuilder.RenameColumn(
                name: "ChangedAt",
                table: "products_history",
                newName: "changed_at");

            migrationBuilder.RenameColumn(
                name: "CatalogNumber",
                table: "products_history",
                newName: "catalog_number");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "products_history",
                newName: "brand_id");

            migrationBuilder.RenameColumn(
                name: "BasePrice",
                table: "products_history",
                newName: "base_price");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsHistory_TypeId",
                table: "products_history",
                newName: "IX_products_history_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsHistory_ProductId",
                table: "products_history",
                newName: "IX_products_history_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsHistory_CountryId",
                table: "products_history",
                newName: "IX_products_history_country_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsHistory_ChangedById",
                table: "products_history",
                newName: "IX_products_history_changed_by");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsHistory_BrandId",
                table: "products_history",
                newName: "IX_products_history_brand_id");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "order_history",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "order_history",
                newName: "count");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "order_history",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "WharehouseId",
                table: "order_history",
                newName: "warehouse_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "order_history",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "order_history",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ProductPrice",
                table: "order_history",
                newName: "product_price");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "order_history",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "order_history",
                newName: "order_id");

            migrationBuilder.RenameColumn(
                name: "DeliveryStatusId",
                table: "order_history",
                newName: "delivery_status_id");

            migrationBuilder.RenameColumn(
                name: "DeliveryPrice",
                table: "order_history",
                newName: "delivery_price");

            migrationBuilder.RenameColumn(
                name: "DeliveryDays",
                table: "order_history",
                newName: "delivery_days");

            migrationBuilder.RenameColumn(
                name: "DeliveryAddressId",
                table: "order_history",
                newName: "delivery_address_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "order_history",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "ChangedById",
                table: "order_history",
                newName: "changed_by");

            migrationBuilder.RenameIndex(
                name: "IX_DatabaseOrderHistory_WharehouseId",
                table: "order_history",
                newName: "IX_order_history_warehouse_id");

            migrationBuilder.RenameIndex(
                name: "IX_DatabaseOrderHistory_UserId",
                table: "order_history",
                newName: "IX_order_history_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_DatabaseOrderHistory_ProductId",
                table: "order_history",
                newName: "IX_order_history_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_DatabaseOrderHistory_DeliveryStatusId",
                table: "order_history",
                newName: "IX_order_history_delivery_status_id");

            migrationBuilder.RenameIndex(
                name: "IX_DatabaseOrderHistory_DeliveryAddressId",
                table: "order_history",
                newName: "IX_order_history_delivery_address_id");

            migrationBuilder.AddColumn<int>(
                name: "DatabaseWharehouseProdHistoryId",
                table: "products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "changed_by",
                table: "warehouse_products_history",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "type_id",
                table: "products_history",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "photo_path",
                table: "products_history",
                type: "TEXT",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "country_id",
                table: "products_history",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "changed_by",
                table: "products_history",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "brand_id",
                table: "products_history",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "order_history",
                type: "nvarchar(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<float>(
                name: "product_price",
                table: "order_history",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<float>(
                name: "delivery_price",
                table: "order_history",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<int>(
                name: "changed_by",
                table: "order_history",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "DatabaseAddressId",
                table: "order_history",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_warehouse_products_history",
                table: "warehouse_products_history",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products_history",
                table: "products_history",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order_history",
                table: "order_history",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_products_DatabaseWharehouseProdHistoryId",
                table: "products",
                column: "DatabaseWharehouseProdHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_products_history_warehouse_prod_id",
                table: "warehouse_products_history",
                column: "warehouse_prod_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_history_changed_by",
                table: "order_history",
                column: "changed_by");

            migrationBuilder.CreateIndex(
                name: "IX_order_history_DatabaseAddressId",
                table: "order_history",
                column: "DatabaseAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_order_history_order_id",
                table: "order_history",
                column: "order_id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_history_address_DatabaseAddressId",
                table: "order_history",
                column: "DatabaseAddressId",
                principalTable: "address",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_history_address_delivery_address_id",
                table: "order_history",
                column: "delivery_address_id",
                principalTable: "address",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_history_delivery_status_delivery_status_id",
                table: "order_history",
                column: "delivery_status_id",
                principalTable: "delivery_status",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_history_order_order_id",
                table: "order_history",
                column: "order_id",
                principalTable: "order",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_history_products_product_id",
                table: "order_history",
                column: "product_id",
                principalTable: "products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_history_users_changed_by",
                table: "order_history",
                column: "changed_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_order_history_users_user_id",
                table: "order_history",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_order_history_wharehouse_warehouse_id",
                table: "order_history",
                column: "warehouse_id",
                principalTable: "wharehouse",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_warehouse_products_history_DatabaseWharehouseProdHistoryId",
                table: "products",
                column: "DatabaseWharehouseProdHistoryId",
                principalTable: "warehouse_products_history",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_history_brands_brand_id",
                table: "products_history",
                column: "brand_id",
                principalTable: "brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_products_history_country_country_id",
                table: "products_history",
                column: "country_id",
                principalTable: "country",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_products_history_products_product_id",
                table: "products_history",
                column: "product_id",
                principalTable: "products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_history_types_type_id",
                table: "products_history",
                column: "type_id",
                principalTable: "types",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_products_history_users_changed_by",
                table: "products_history",
                column: "changed_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_products_products_product_id",
                table: "warehouse_products",
                column: "product_id",
                principalTable: "products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_products_wharehouse_warehouse_id",
                table: "warehouse_products",
                column: "warehouse_id",
                principalTable: "wharehouse",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_products_history_products_product_id",
                table: "warehouse_products_history",
                column: "product_id",
                principalTable: "products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_products_history_users_changed_by",
                table: "warehouse_products_history",
                column: "changed_by",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_products_history_warehouse_products_warehouse_id",
                table: "warehouse_products_history",
                column: "warehouse_id",
                principalTable: "warehouse_products",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_products_history_warehouse_products_warehouse_prod_id",
                table: "warehouse_products_history",
                column: "warehouse_prod_id",
                principalTable: "warehouse_products",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_history_address_DatabaseAddressId",
                table: "order_history");

            migrationBuilder.DropForeignKey(
                name: "FK_order_history_address_delivery_address_id",
                table: "order_history");

            migrationBuilder.DropForeignKey(
                name: "FK_order_history_delivery_status_delivery_status_id",
                table: "order_history");

            migrationBuilder.DropForeignKey(
                name: "FK_order_history_order_order_id",
                table: "order_history");

            migrationBuilder.DropForeignKey(
                name: "FK_order_history_products_product_id",
                table: "order_history");

            migrationBuilder.DropForeignKey(
                name: "FK_order_history_users_changed_by",
                table: "order_history");

            migrationBuilder.DropForeignKey(
                name: "FK_order_history_users_user_id",
                table: "order_history");

            migrationBuilder.DropForeignKey(
                name: "FK_order_history_wharehouse_warehouse_id",
                table: "order_history");

            migrationBuilder.DropForeignKey(
                name: "FK_products_warehouse_products_history_DatabaseWharehouseProdHistoryId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_history_brands_brand_id",
                table: "products_history");

            migrationBuilder.DropForeignKey(
                name: "FK_products_history_country_country_id",
                table: "products_history");

            migrationBuilder.DropForeignKey(
                name: "FK_products_history_products_product_id",
                table: "products_history");

            migrationBuilder.DropForeignKey(
                name: "FK_products_history_types_type_id",
                table: "products_history");

            migrationBuilder.DropForeignKey(
                name: "FK_products_history_users_changed_by",
                table: "products_history");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_products_products_product_id",
                table: "warehouse_products");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_products_wharehouse_warehouse_id",
                table: "warehouse_products");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_products_history_products_product_id",
                table: "warehouse_products_history");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_products_history_users_changed_by",
                table: "warehouse_products_history");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_products_history_warehouse_products_warehouse_id",
                table: "warehouse_products_history");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_products_history_warehouse_products_warehouse_prod_id",
                table: "warehouse_products_history");

            migrationBuilder.DropIndex(
                name: "IX_products_DatabaseWharehouseProdHistoryId",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_warehouse_products_history",
                table: "warehouse_products_history");

            migrationBuilder.DropIndex(
                name: "IX_warehouse_products_history_warehouse_prod_id",
                table: "warehouse_products_history");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products_history",
                table: "products_history");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order_history",
                table: "order_history");

            migrationBuilder.DropIndex(
                name: "IX_order_history_changed_by",
                table: "order_history");

            migrationBuilder.DropIndex(
                name: "IX_order_history_DatabaseAddressId",
                table: "order_history");

            migrationBuilder.DropIndex(
                name: "IX_order_history_order_id",
                table: "order_history");

            migrationBuilder.DropColumn(
                name: "DatabaseWharehouseProdHistoryId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "DatabaseAddressId",
                table: "order_history");

            migrationBuilder.RenameTable(
                name: "warehouse_products_history",
                newName: "WarehousesProductsHistory");

            migrationBuilder.RenameTable(
                name: "products_history",
                newName: "ProductsHistory");

            migrationBuilder.RenameTable(
                name: "order_history",
                newName: "DatabaseOrderHistory");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "warehouse_products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "warehouse_id",
                table: "warehouse_products",
                newName: "WharehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_warehouse_products_warehouse_id",
                table: "warehouse_products",
                newName: "IX_warehouse_products_WharehouseId");

            migrationBuilder.RenameColumn(
                name: "count",
                table: "WarehousesProductsHistory",
                newName: "Count");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "WarehousesProductsHistory",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "warehouse_prod_id",
                table: "WarehousesProductsHistory",
                newName: "WarehouseProdId");

            migrationBuilder.RenameColumn(
                name: "warehouse_id",
                table: "WarehousesProductsHistory",
                newName: "WharehouseId");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "WarehousesProductsHistory",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "changed_by",
                table: "WarehousesProductsHistory",
                newName: "ChangedById");

            migrationBuilder.RenameColumn(
                name: "changed_at",
                table: "WarehousesProductsHistory",
                newName: "ChangedAt");

            migrationBuilder.RenameIndex(
                name: "IX_warehouse_products_history_warehouse_id",
                table: "WarehousesProductsHistory",
                newName: "IX_WarehousesProductsHistory_WharehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_warehouse_products_history_product_id",
                table: "WarehousesProductsHistory",
                newName: "IX_WarehousesProductsHistory_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_warehouse_products_history_changed_by",
                table: "WarehousesProductsHistory",
                newName: "IX_WarehousesProductsHistory_ChangedById");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ProductsHistory",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ProductsHistory",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "type_id",
                table: "ProductsHistory",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "ProductsHistory",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "photo_path",
                table: "ProductsHistory",
                newName: "PhotoPath");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "ProductsHistory",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "country_id",
                table: "ProductsHistory",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "changed_by",
                table: "ProductsHistory",
                newName: "ChangedById");

            migrationBuilder.RenameColumn(
                name: "changed_at",
                table: "ProductsHistory",
                newName: "ChangedAt");

            migrationBuilder.RenameColumn(
                name: "catalog_number",
                table: "ProductsHistory",
                newName: "CatalogNumber");

            migrationBuilder.RenameColumn(
                name: "brand_id",
                table: "ProductsHistory",
                newName: "BrandId");

            migrationBuilder.RenameColumn(
                name: "base_price",
                table: "ProductsHistory",
                newName: "BasePrice");

            migrationBuilder.RenameIndex(
                name: "IX_products_history_type_id",
                table: "ProductsHistory",
                newName: "IX_ProductsHistory_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_products_history_product_id",
                table: "ProductsHistory",
                newName: "IX_ProductsHistory_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_products_history_country_id",
                table: "ProductsHistory",
                newName: "IX_ProductsHistory_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_products_history_changed_by",
                table: "ProductsHistory",
                newName: "IX_ProductsHistory_ChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_products_history_brand_id",
                table: "ProductsHistory",
                newName: "IX_ProductsHistory_BrandId");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "DatabaseOrderHistory",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "count",
                table: "DatabaseOrderHistory",
                newName: "Count");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "DatabaseOrderHistory",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "warehouse_id",
                table: "DatabaseOrderHistory",
                newName: "WharehouseId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "DatabaseOrderHistory",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "DatabaseOrderHistory",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "product_price",
                table: "DatabaseOrderHistory",
                newName: "ProductPrice");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "DatabaseOrderHistory",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "order_id",
                table: "DatabaseOrderHistory",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "delivery_status_id",
                table: "DatabaseOrderHistory",
                newName: "DeliveryStatusId");

            migrationBuilder.RenameColumn(
                name: "delivery_price",
                table: "DatabaseOrderHistory",
                newName: "DeliveryPrice");

            migrationBuilder.RenameColumn(
                name: "delivery_days",
                table: "DatabaseOrderHistory",
                newName: "DeliveryDays");

            migrationBuilder.RenameColumn(
                name: "delivery_address_id",
                table: "DatabaseOrderHistory",
                newName: "DeliveryAddressId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "DatabaseOrderHistory",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "changed_by",
                table: "DatabaseOrderHistory",
                newName: "ChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_order_history_warehouse_id",
                table: "DatabaseOrderHistory",
                newName: "IX_DatabaseOrderHistory_WharehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_order_history_user_id",
                table: "DatabaseOrderHistory",
                newName: "IX_DatabaseOrderHistory_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_order_history_product_id",
                table: "DatabaseOrderHistory",
                newName: "IX_DatabaseOrderHistory_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_order_history_delivery_status_id",
                table: "DatabaseOrderHistory",
                newName: "IX_DatabaseOrderHistory_DeliveryStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_order_history_delivery_address_id",
                table: "DatabaseOrderHistory",
                newName: "IX_DatabaseOrderHistory_DeliveryAddressId");

            migrationBuilder.AlterColumn<int>(
                name: "ChangedById",
                table: "WarehousesProductsHistory",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WharehouseProductsId",
                table: "WarehousesProductsHistory",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "ProductsHistory",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhotoPath",
                table: "ProductsHistory",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "ProductsHistory",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChangedById",
                table: "ProductsHistory",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "ProductsHistory",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "DatabaseOrderHistory",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "ProductPrice",
                table: "DatabaseOrderHistory",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "DeliveryPrice",
                table: "DatabaseOrderHistory",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "ChangedById",
                table: "DatabaseOrderHistory",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChangedByUserId",
                table: "DatabaseOrderHistory",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderHistoryId",
                table: "DatabaseOrderHistory",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "DatabaseOrderHistory",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarehousesProductsHistory",
                table: "WarehousesProductsHistory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsHistory",
                table: "ProductsHistory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DatabaseOrderHistory",
                table: "DatabaseOrderHistory",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WarehousesProductsHistory_WharehouseProductsId",
                table: "WarehousesProductsHistory",
                column: "WharehouseProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_DatabaseOrderHistory_ChangedByUserId",
                table: "DatabaseOrderHistory",
                column: "ChangedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DatabaseOrderHistory_OrderHistoryId",
                table: "DatabaseOrderHistory",
                column: "OrderHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DatabaseOrderHistory_TypeId",
                table: "DatabaseOrderHistory",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DatabaseOrderHistory_DatabaseOrderHistory_OrderHistoryId",
                table: "DatabaseOrderHistory",
                column: "OrderHistoryId",
                principalTable: "DatabaseOrderHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DatabaseOrderHistory_address_DeliveryAddressId",
                table: "DatabaseOrderHistory",
                column: "DeliveryAddressId",
                principalTable: "address",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DatabaseOrderHistory_delivery_status_DeliveryStatusId",
                table: "DatabaseOrderHistory",
                column: "DeliveryStatusId",
                principalTable: "delivery_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DatabaseOrderHistory_products_ProductId",
                table: "DatabaseOrderHistory",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DatabaseOrderHistory_types_TypeId",
                table: "DatabaseOrderHistory",
                column: "TypeId",
                principalTable: "types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DatabaseOrderHistory_users_ChangedByUserId",
                table: "DatabaseOrderHistory",
                column: "ChangedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DatabaseOrderHistory_users_UserId",
                table: "DatabaseOrderHistory",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_DatabaseOrderHistory_wharehouse_WharehouseId",
                table: "DatabaseOrderHistory",
                column: "WharehouseId",
                principalTable: "wharehouse",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsHistory_brands_BrandId",
                table: "ProductsHistory",
                column: "BrandId",
                principalTable: "brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsHistory_country_CountryId",
                table: "ProductsHistory",
                column: "CountryId",
                principalTable: "country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsHistory_products_ProductId",
                table: "ProductsHistory",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsHistory_types_TypeId",
                table: "ProductsHistory",
                column: "TypeId",
                principalTable: "types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsHistory_users_ChangedById",
                table: "ProductsHistory",
                column: "ChangedById",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_products_products_product_id",
                table: "warehouse_products",
                column: "product_id",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_products_wharehouse_WharehouseId",
                table: "warehouse_products",
                column: "WharehouseId",
                principalTable: "wharehouse",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehousesProductsHistory_products_ProductId",
                table: "WarehousesProductsHistory",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehousesProductsHistory_users_ChangedById",
                table: "WarehousesProductsHistory",
                column: "ChangedById",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehousesProductsHistory_warehouse_products_WharehouseId",
                table: "WarehousesProductsHistory",
                column: "WharehouseId",
                principalTable: "warehouse_products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehousesProductsHistory_warehouse_products_WharehouseProductsId",
                table: "WarehousesProductsHistory",
                column: "WharehouseProductsId",
                principalTable: "warehouse_products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
