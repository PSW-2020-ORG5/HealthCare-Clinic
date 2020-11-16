using Microsoft.EntityFrameworkCore.Migrations;

namespace Health_Clinic_Web_App.Migrations
{
    public partial class ThirdMigration_AddedPublishedAndForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
/*            migrationBuilder.DropForeignKey(
                name: "FK_AppReviews_PatientModel_PatientId1",
                table: "AppReviews");

            migrationBuilder.DropIndex(
                name: "IX_AppReviews_PatientId1",
                table: "AppReviews");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "AppReviews");
*/
            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "AppReviews",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "AppReviews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_AppReviews_PatientId",
                table: "AppReviews",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppReviews_PatientModel_PatientId",
                table: "AppReviews",
                column: "PatientId",
                principalTable: "PatientModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppReviews_PatientModel_PatientId",
                table: "AppReviews");

            migrationBuilder.DropIndex(
                name: "IX_AppReviews_PatientId",
                table: "AppReviews");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "AppReviews");

            migrationBuilder.AlterColumn<long>(
                name: "PatientId",
                table: "AppReviews",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));

/*            migrationBuilder.AddColumn<int>(
                name: "PatientId1",
                table: "AppReviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppReviews_PatientId1",
                table: "AppReviews",
                column: "PatientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AppReviews_PatientModel_PatientId1",
                table: "AppReviews",
                column: "PatientId1",
                principalTable: "PatientModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);*/
        }
    }
}
