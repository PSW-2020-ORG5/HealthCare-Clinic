using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationAdapters.Migrations
{
    public partial class migration8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Apis",
                columns: new[] { "api_key", "baseUrl", "name" },
                values: new object[] { "zegin_key", null, "Zegin" });

            migrationBuilder.InsertData(
                table: "Apis",
                columns: new[] { "api_key", "baseUrl", "name" },
                values: new object[] { "benu_key", null, "Benu" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Apis",
                keyColumn: "api_key",
                keyValue: "benu_key");

            migrationBuilder.DeleteData(
                table: "Apis",
                keyColumn: "api_key",
                keyValue: "zegin_key");
        }
    }
}
