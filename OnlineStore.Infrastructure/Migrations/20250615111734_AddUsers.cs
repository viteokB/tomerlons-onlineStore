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
            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "name" },
                values: new object[,]
                {
                    {
                        "админ"
                    },
                    {
                        "клиент"
                    }
                });
            
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
            
            // Вставка типов
            migrationBuilder.InsertData(
                table: "types",
                columns: new[] { "id", "name", "description" },
                values: new object[] 
                {
                    1,
                    "диски легковые", 
                    "Диски для легкового авто",
                });
            
            migrationBuilder.InsertData(
                table: "types",
                columns: new[] { "id", "name", "description" },
                values: new object[] 
                {
                    2,
                    "покрышки легковые", 
                    "Покрышки для легкового авто",
                });

            // Вставка стран
            migrationBuilder.InsertData(
                table: "country",
                columns: new[] { "Id", "name", "code" },
                values: new object[] 
                {
                    1,
                    "россия", 
                    "RUS",
                });
            
            migrationBuilder.InsertData(
                table: "country",
                columns: new[] { "Id", "name", "code" },
                values: new object[] 
                {
                    2,
                    "германия", 
                    "DEU"
                });

            // Вставка брендов
            migrationBuilder.InsertData(
                table: "brands",
                columns: new[] { "Id", "CountryId", "name" },
                values: new object[] 
                {
                    1,
                    1, 
                    "lada"
                });
            
            migrationBuilder.InsertData(
                table: "brands",
                columns: new[] { "Id", "CountryId", "name" },
                values: new object[] 
                {
                    2,
                    2, 
                    "bmw"
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Удаляем добавленного пользователя
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "email",
                keyValue: "admin@example.com");
            
            migrationBuilder.DeleteData(
                table: "brands",
                keyColumn: "Id",
                keyValue: 1);
            
            migrationBuilder.DeleteData(
                table: "brands",
                keyColumn: "Id",
                keyValue: 2);

            // Страны
            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 1);
            
            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 2);

            // Типы
            migrationBuilder.DeleteData(
                table: "types",
                keyColumn: "id",
                keyValue: 1);
            
            migrationBuilder.DeleteData(
                table: "types",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
