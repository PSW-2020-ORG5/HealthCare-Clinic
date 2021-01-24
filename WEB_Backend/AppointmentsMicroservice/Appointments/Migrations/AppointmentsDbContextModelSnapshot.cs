﻿// <auto-generated />
using System;
using Appointments.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Appointments.Migrations
{
    [DbContext(typeof(AppointmentsDbContext))]
    partial class AppointmentsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Appointments.Model.Alergen", b =>
                {
                    b.Property<int>("AlergenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AlergenCode")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("AlergenName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("MedicineId")
                        .HasColumnType("int");

                    b.HasKey("AlergenId");

                    b.HasIndex("MedicineId");

                    b.ToTable("Alergen");
                });

            modelBuilder.Entity("Appointments.Model.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("IngredientCode")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("IngredientName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("MedicineId")
                        .HasColumnType("int");

                    b.HasKey("IngredientId");

                    b.HasIndex("MedicineId");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("Appointments.Model.MedicalRecord", b =>
                {
                    b.Property<int>("MedicalRecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("MedicalRecordId");

                    b.ToTable("MedicalRecords");
                });

            modelBuilder.Entity("Appointments.Model.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("MedicineName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("MedicineStatus")
                        .HasColumnType("int");

                    b.Property<string>("MedicineType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SideEffects")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("TreatmentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TreatmentId");

                    b.ToTable("Medicine");
                });

            modelBuilder.Entity("Appointments.Model.ReferralToSpecialist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int?>("MedicalRecordId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ValidFromDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("MedicalRecordId");

                    b.ToTable("ReferralToSpecialist");
                });

            modelBuilder.Entity("Appointments.Model.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DoctorsRemark")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("MedicalRecordId")
                        .HasColumnType("int");

                    b.Property<string>("PatientsReport")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("TermId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicalRecordId");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("Appointments.Model.SchedulingEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("SessionId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("User")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Appointments.Model.Term", b =>
                {
                    b.Property<int>("TermId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MedicalRecordId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("TermId");

                    b.ToTable("Terms");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Term");
                });

            modelBuilder.Entity("Appointments.Model.Treatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTimeEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateTimeStart")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Instructions")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("MedicalRecordId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicalRecordId");

                    b.ToTable("Treatment");
                });

            modelBuilder.Entity("Appointments.Model.Checkup", b =>
                {
                    b.HasBaseType("Appointments.Model.Term");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.HasIndex("MedicalRecordId");

                    b.HasDiscriminator().HasValue("Checkup");

                    b.HasData(
                        new
                        {
                            TermId = 1,
                            EndTime = new DateTime(2021, 1, 15, 7, 30, 0, 0, DateTimeKind.Unspecified),
                            MedicalRecordId = 2,
                            StartTime = new DateTime(2021, 1, 15, 7, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 5
                        },
                        new
                        {
                            TermId = 2,
                            EndTime = new DateTime(2021, 1, 18, 7, 30, 0, 0, DateTimeKind.Unspecified),
                            MedicalRecordId = 1,
                            StartTime = new DateTime(2021, 1, 18, 7, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 4
                        },
                        new
                        {
                            TermId = 3,
                            EndTime = new DateTime(2021, 1, 18, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            MedicalRecordId = 3,
                            StartTime = new DateTime(2021, 1, 18, 7, 30, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 4
                        },
                        new
                        {
                            TermId = 4,
                            EndTime = new DateTime(2021, 1, 18, 10, 30, 0, 0, DateTimeKind.Unspecified),
                            MedicalRecordId = 4,
                            StartTime = new DateTime(2021, 1, 18, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 6
                        },
                        new
                        {
                            TermId = 5,
                            EndTime = new DateTime(2021, 1, 19, 7, 30, 0, 0, DateTimeKind.Unspecified),
                            MedicalRecordId = 5,
                            StartTime = new DateTime(2021, 1, 19, 7, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 10
                        },
                        new
                        {
                            TermId = 6,
                            EndTime = new DateTime(2021, 1, 19, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            MedicalRecordId = 6,
                            StartTime = new DateTime(2021, 1, 19, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 10
                        },
                        new
                        {
                            TermId = 7,
                            EndTime = new DateTime(2021, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            MedicalRecordId = 7,
                            StartTime = new DateTime(2021, 1, 19, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 9
                        },
                        new
                        {
                            TermId = 8,
                            EndTime = new DateTime(2021, 1, 19, 9, 30, 0, 0, DateTimeKind.Unspecified),
                            MedicalRecordId = 8,
                            StartTime = new DateTime(2021, 1, 19, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 11
                        },
                        new
                        {
                            TermId = 9,
                            EndTime = new DateTime(2021, 1, 20, 7, 30, 0, 0, DateTimeKind.Unspecified),
                            MedicalRecordId = 9,
                            StartTime = new DateTime(2021, 1, 20, 7, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 12
                        },
                        new
                        {
                            TermId = 10,
                            EndTime = new DateTime(2021, 1, 20, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            MedicalRecordId = 10,
                            StartTime = new DateTime(2021, 1, 20, 7, 30, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 12
                        });
                });

            modelBuilder.Entity("Appointments.Model.Alergen", b =>
                {
                    b.HasOne("Appointments.Model.Medicine", null)
                        .WithMany("Alergen")
                        .HasForeignKey("MedicineId");
                });

            modelBuilder.Entity("Appointments.Model.Ingredient", b =>
                {
                    b.HasOne("Appointments.Model.Medicine", null)
                        .WithMany("Ingredient")
                        .HasForeignKey("MedicineId");
                });

            modelBuilder.Entity("Appointments.Model.Medicine", b =>
                {
                    b.HasOne("Appointments.Model.Treatment", null)
                        .WithMany("Medicines")
                        .HasForeignKey("TreatmentId");
                });

            modelBuilder.Entity("Appointments.Model.ReferralToSpecialist", b =>
                {
                    b.HasOne("Appointments.Model.MedicalRecord", null)
                        .WithMany("RferralToSpecialist")
                        .HasForeignKey("MedicalRecordId");
                });

            modelBuilder.Entity("Appointments.Model.Report", b =>
                {
                    b.HasOne("Appointments.Model.MedicalRecord", null)
                        .WithMany("Reports")
                        .HasForeignKey("MedicalRecordId");
                });

            modelBuilder.Entity("Appointments.Model.Treatment", b =>
                {
                    b.HasOne("Appointments.Model.MedicalRecord", null)
                        .WithMany("Treatments")
                        .HasForeignKey("MedicalRecordId");
                });

            modelBuilder.Entity("Appointments.Model.Checkup", b =>
                {
                    b.HasOne("Appointments.Model.MedicalRecord", null)
                        .WithMany("Checkups")
                        .HasForeignKey("MedicalRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
