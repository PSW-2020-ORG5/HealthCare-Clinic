﻿// <auto-generated />
using Health_Clinic_Web_App.Model.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Health_Clinic_Web_App.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20201110223558_FourthMigration_SimplifiedAppReviewModel")]
    partial class FourthMigration_SimplifiedAppReviewModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Model.Survey.AppReview", b =>
                {
                    b.Property<int>("AppReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Anonymous")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<bool>("Publishable")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Published")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ReviewText")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("AppReviewId");

                    b.ToTable("AppReviews");
                });
#pragma warning restore 612, 618
        }
    }
}