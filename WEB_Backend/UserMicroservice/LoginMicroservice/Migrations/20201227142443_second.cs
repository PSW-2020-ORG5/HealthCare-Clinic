using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginMicroservice.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AbleToPrescribeTreatments",
                table: "RegisteredUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AbleToValidateMedicines",
                table: "RegisteredUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BusinessHoursId",
                table: "RegisteredUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialtyType",
                table: "RegisteredUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicalRecordId",
                table: "RegisteredUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "RegisteredUsers",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "RegisteredUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BusinessHoursModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    FromHour = table.Column<DateTime>(nullable: false),
                    ToHour = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessHoursModel", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "RegisteredUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Discriminator", "Role" },
                values: new object[] { "RegisteredUser", 1 });

            migrationBuilder.InsertData(
                table: "RegisteredUsers",
                columns: new[] { "Id", "Adress", "Biography", "Birthday", "Discriminator", "Email", "Gender", "Jmbg", "Name", "ParentsName", "Password", "PhoneNumber", "Role", "Surname", "Username" },
                values: new object[] { 2, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RegisteredUser", "marko1@gmail.com", null, null, "Marko", null, "marko1", null, 0, "Markovic", "marko1" });

            migrationBuilder.InsertData(
                table: "RegisteredUsers",
                columns: new[] { "Id", "Adress", "Biography", "Birthday", "Discriminator", "Email", "Gender", "Jmbg", "Name", "ParentsName", "Password", "PhoneNumber", "Role", "Surname", "Username", "AbleToPrescribeTreatments", "AbleToValidateMedicines", "BusinessHoursId", "SpecialtyType" },
                values: new object[] { 4, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "nnikolic@gmail.com", null, null, "Nikola", null, "nikola02", null, 0, "Nikolic", "nikola01", false, false, null, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredUsers_BusinessHoursId",
                table: "RegisteredUsers",
                column: "BusinessHoursId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredUsers_BusinessHoursModel_BusinessHoursId",
                table: "RegisteredUsers",
                column: "BusinessHoursId",
                principalTable: "BusinessHoursModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredUsers_BusinessHoursModel_BusinessHoursId",
                table: "RegisteredUsers");

            migrationBuilder.DropTable(
                name: "BusinessHoursModel");

            migrationBuilder.DropIndex(
                name: "IX_RegisteredUsers_BusinessHoursId",
                table: "RegisteredUsers");

            migrationBuilder.DeleteData(
                table: "RegisteredUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RegisteredUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "AbleToPrescribeTreatments",
                table: "RegisteredUsers");

            migrationBuilder.DropColumn(
                name: "AbleToValidateMedicines",
                table: "RegisteredUsers");

            migrationBuilder.DropColumn(
                name: "BusinessHoursId",
                table: "RegisteredUsers");

            migrationBuilder.DropColumn(
                name: "SpecialtyType",
                table: "RegisteredUsers");

            migrationBuilder.DropColumn(
                name: "MedicalRecordId",
                table: "RegisteredUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "RegisteredUsers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "RegisteredUsers");
        }
    }
}
