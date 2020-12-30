using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationAdapters.Migrations
{
    public partial class Forth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenders",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ClosingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineDto",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Tenderid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineDto", x => x.Name);
                    table.ForeignKey(
                        name: "FK_MedicineDto_Tenders_Tenderid",
                        column: x => x.Tenderid,
                        principalTable: "Tenders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicineDto_Tenderid",
                table: "MedicineDto",
                column: "Tenderid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineDto");

            migrationBuilder.DropTable(
                name: "Tenders");
        }
    }
}
