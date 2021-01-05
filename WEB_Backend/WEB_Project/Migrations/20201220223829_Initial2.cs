using Microsoft.EntityFrameworkCore.Migrations;

namespace Health_Clinic_Web_App.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppReviews",
                columns: new[] { "AppReviewId", "Anonymous", "PatientId", "Publishable", "Published", "ReviewText" },
                values: new object[] { 1, false, 1, true, true, "lose" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppReviews",
                keyColumn: "AppReviewId",
                keyValue: 1);
        }
    }
}
