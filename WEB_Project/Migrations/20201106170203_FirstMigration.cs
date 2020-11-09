using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Health_Clinic_Web_App.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Jmbg = table.Column<string>(nullable: true),
                    ParentsName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    Biography = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    MedicalRecordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppReviews",
                columns: table => new
                {
                    AppReviewId = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatientId1 = table.Column<int>(nullable: true),
                    PatientId = table.Column<long>(nullable: false),
                    ReviewText = table.Column<string>(nullable: true),
                    Anonymous = table.Column<bool>(nullable: false),
                    Publishable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppReviews", x => x.AppReviewId);
                    table.ForeignKey(
                        name: "FK_AppReviews_PatientModel_PatientId1",
                        column: x => x.PatientId1,
                        principalTable: "PatientModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyResponse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Mark = table.Column<int>(nullable: false),
                    Quality = table.Column<int>(nullable: false),
                    Security = table.Column<int>(nullable: false),
                    Kindness = table.Column<int>(nullable: false),
                    Professionalism = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    PatientModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyResponse_PatientModel_PatientModelId",
                        column: x => x.PatientModelId,
                        principalTable: "PatientModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppReviews_PatientId1",
                table: "AppReviews",
                column: "PatientId1");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResponse_PatientModelId",
                table: "SurveyResponse",
                column: "PatientModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppReviews");

            migrationBuilder.DropTable(
                name: "SurveyResponse");

            migrationBuilder.DropTable(
                name: "PatientModel");
        }
    }
}
