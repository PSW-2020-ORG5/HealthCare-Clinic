using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationAdapters.Migrations
{
    public partial class migration9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Apis",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "grpcPort",
                table: "Apis",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isUsingFtp",
                table: "Apis",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Apis");

            migrationBuilder.DropColumn(
                name: "grpcPort",
                table: "Apis");

            migrationBuilder.DropColumn(
                name: "isUsingFtp",
                table: "Apis");
        }
    }
}
