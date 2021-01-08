﻿// <auto-generated />
using System;
using IntegrationAdapters.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IntegrationAdapters.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("IntegrationAdapters.Dtos.MedicineDto", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Tenderid")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Name");

                    b.HasIndex("Tenderid");

                    b.ToTable("MedicineDto");
                });

            modelBuilder.Entity("IntegrationAdapters.Dtos.MedicineOfferDto", b =>
                {
                    b.Property<string>("PharmacyName")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("PricePerUnit")
                        .HasColumnType("int");

                    b.Property<string>("TenderOfferDtoId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("TenderOfferDtoPharmacyName")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("PharmacyName", "Name");

                    b.HasIndex("TenderOfferDtoId", "TenderOfferDtoPharmacyName");

                    b.ToTable("MedicineOfferDto");
                });

            modelBuilder.Entity("IntegrationAdapters.Dtos.TenderOfferDto", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("PharmacyName")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Endpoint")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id", "PharmacyName");

                    b.ToTable("TenderOffers");
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

            modelBuilder.Entity("IntegrationAdapters.Models.Tender", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("ClosingDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("Tenders");
                });

            modelBuilder.Entity("IntegrationAdapters.Dtos.MedicineDto", b =>
                {
                    b.HasOne("IntegrationAdapters.Models.Tender", null)
                        .WithMany("RequiredMedicine")
                        .HasForeignKey("Tenderid");
                });

            modelBuilder.Entity("IntegrationAdapters.Dtos.MedicineOfferDto", b =>
                {
                    b.HasOne("IntegrationAdapters.Dtos.TenderOfferDto", null)
                        .WithMany("OfferedMedicine")
                        .HasForeignKey("TenderOfferDtoId", "TenderOfferDtoPharmacyName");
                });
#pragma warning restore 612, 618
        }
    }
}
