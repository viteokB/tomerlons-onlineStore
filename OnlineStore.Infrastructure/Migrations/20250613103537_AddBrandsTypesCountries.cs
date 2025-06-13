using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddBrandsTypesCountries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    "Россия", 
                    "RUS",
                });
            
            migrationBuilder.InsertData(
                table: "country",
                columns: new[] { "Id", "name", "code" },
                values: new object[] 
                {
                    2,
                    "Германия", 
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
                    "Lada"
                });
            
            migrationBuilder.InsertData(
                table: "brands",
                columns: new[] { "Id", "CountryId", "name" },
                values: new object[] 
                {
                    2,
                    2, 
                    "BMW"
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Удаляем добавленные данные в обратном порядке
            
            // Бренды
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
