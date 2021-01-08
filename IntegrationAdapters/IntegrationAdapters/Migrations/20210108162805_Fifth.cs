using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationAdapters.Migrations
{
    public partial class Fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TenderOffers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PharmacyName = table.Column<string>(nullable: false),
                    Endpoint = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderOffers", x => new { x.Id, x.PharmacyName });
                });

            migrationBuilder.CreateTable(
                name: "MedicineOfferDto",
                columns: table => new
                {
                    PharmacyName = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    PricePerUnit = table.Column<int>(nullable: false),
                    TenderOfferDtoId = table.Column<string>(nullable: true),
                    TenderOfferDtoPharmacyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineOfferDto", x => new { x.PharmacyName, x.Name });
                    table.ForeignKey(
                        name: "FK_MedicineOfferDto_TenderOffers_TenderOfferDtoId_TenderOfferDt~",
                        columns: x => new { x.TenderOfferDtoId, x.TenderOfferDtoPharmacyName },
                        principalTable: "TenderOffers",
                        principalColumns: new[] { "Id", "PharmacyName" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicineOfferDto_TenderOfferDtoId_TenderOfferDtoPharmacyName",
                table: "MedicineOfferDto",
                columns: new[] { "TenderOfferDtoId", "TenderOfferDtoPharmacyName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineOfferDto");

            migrationBuilder.DropTable(
                name: "TenderOffers");
        }
    }
}
