using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Appointments.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SessionId = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    User = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    MedicalRecordId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoctorId = table.Column<int>(nullable: true),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.MedicalRecordId);
                });

            migrationBuilder.CreateTable(
                name: "ReferralToSpecialist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ValidFromDate = table.Column<DateTime>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    MedicalRecordId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferralToSpecialist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferralToSpecialist_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "MedicalRecordId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatientsReport = table.Column<string>(nullable: true),
                    DoctorsRemark = table.Column<string>(nullable: true),
                    TermId = table.Column<int>(nullable: false),
                    MedicalRecordId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Report_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "MedicalRecordId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    TermId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MedicalRecordId = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    DoctorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms", x => x.TermId);
                    table.ForeignKey(
                        name: "FK_Terms_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "MedicalRecordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateTimeStart = table.Column<DateTime>(nullable: false),
                    DateTimeEnd = table.Column<DateTime>(nullable: false),
                    Instructions = table.Column<string>(nullable: true),
                    MedicalRecordId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatment_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "MedicalRecordId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MedicineName = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    MedicineStatus = table.Column<int>(nullable: false),
                    MedicineType = table.Column<string>(nullable: true),
                    SideEffects = table.Column<string>(nullable: true),
                    TreatmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicine_Treatment_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alergen",
                columns: table => new
                {
                    AlergenId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AlergenCode = table.Column<string>(nullable: true),
                    AlergenName = table.Column<string>(nullable: true),
                    MedicineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alergen", x => x.AlergenId);
                    table.ForeignKey(
                        name: "FK_Alergen_Medicine_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    IngredientId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IngredientCode = table.Column<string>(nullable: true),
                    IngredientName = table.Column<string>(nullable: true),
                    MedicineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.IngredientId);
                    table.ForeignKey(
                        name: "FK_Ingredient_Medicine_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "TermId", "Discriminator", "EndTime", "MedicalRecordId", "StartTime", "DoctorId" },
                values: new object[,]
                {
                    { 1, "Checkup", new DateTime(2021, 1, 15, 7, 30, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 1, 15, 7, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 2, "Checkup", new DateTime(2021, 1, 18, 7, 30, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 1, 18, 7, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 3, "Checkup", new DateTime(2021, 1, 18, 8, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 1, 18, 7, 30, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 4, "Checkup", new DateTime(2021, 1, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 1, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 5, "Checkup", new DateTime(2021, 1, 19, 7, 30, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2021, 1, 19, 7, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 6, "Checkup", new DateTime(2021, 1, 19, 8, 30, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2021, 1, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 7, "Checkup", new DateTime(2021, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(2021, 1, 19, 8, 30, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 8, "Checkup", new DateTime(2021, 1, 19, 9, 30, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2021, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 9, "Checkup", new DateTime(2021, 1, 20, 7, 30, 0, 0, DateTimeKind.Unspecified), 9, new DateTime(2021, 1, 20, 7, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 10, "Checkup", new DateTime(2021, 1, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2021, 1, 20, 7, 30, 0, 0, DateTimeKind.Unspecified), 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alergen_MedicineId",
                table: "Alergen",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_MedicineId",
                table: "Ingredient",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_TreatmentId",
                table: "Medicine",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferralToSpecialist_MedicalRecordId",
                table: "ReferralToSpecialist",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_MedicalRecordId",
                table: "Report",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Terms_MedicalRecordId",
                table: "Terms",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_MedicalRecordId",
                table: "Treatment",
                column: "MedicalRecordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alergen");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "ReferralToSpecialist");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Terms");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.DropTable(
                name: "MedicalRecords");
        }
    }
}
