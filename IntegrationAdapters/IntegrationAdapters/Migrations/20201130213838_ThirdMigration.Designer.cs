﻿// <auto-generated />
using IntegrationAdapters.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IntegrationAdapters.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20201130213838_ThirdMigration")]
    partial class ThirdMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Health_Clinic_Integration.Models.ActionBenefit", b =>
                {
                    b.Property<string>("message")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("pharmacy")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("message");

                    b.ToTable("ActionsBenefits");
                });

            modelBuilder.Entity("IntegrationAdapters.Models.Api", b =>
                {
                    b.Property<string>("api_key")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("api_key");

                    b.ToTable("Apis");

                    b.HasData(
                        new
                        {
                            api_key = "zegin_key",
                            name = "Zegin"
                        },
                        new
                        {
                            api_key = "benu_key",
                            name = "Benu"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
