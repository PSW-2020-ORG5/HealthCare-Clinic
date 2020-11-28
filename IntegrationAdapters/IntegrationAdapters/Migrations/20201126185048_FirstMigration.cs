using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationAdapters.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apis",
                columns: table => new
                {
                    api_key = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apis", x => x.api_key);
                });

            migrationBuilder.InsertData(
                table: "Apis",
                columns: new[] { "api_key", "name" },
                values: new object[] { "zegin_key", "Zegin" });

            migrationBuilder.InsertData(
                table: "Apis",
                columns: new[] { "api_key", "name" },
                values: new object[] { "benu_key", "Benu" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apis");
        }
    }
}
