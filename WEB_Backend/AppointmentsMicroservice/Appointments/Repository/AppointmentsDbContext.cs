using Appointments.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointments.Repository
{
    public class AppointmentsDbContext : DbContext
    {
        public DbSet<Checkup> Checkups { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<SchedulingEvent> Events { get; set; }

        public AppointmentsDbContext(): base() { }
        public AppointmentsDbContext(DbContextOptions<AppointmentsDbContext> options) : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(CreateConnectionStringFromEnvironment());
            }
        }

        private string CreateConnectionStringFromEnvironment()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "3306";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "HealthClinicDB";
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";
            string sslMode = Environment.GetEnvironmentVariable("DATABASE_SSL_MODE") ?? "None";
            return $"server={server};port={port};database={database};user={user};password={password};";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Checkup>().HasData(
                new Checkup { TermId = 1, MedicalRecordId = 2, StartTime = new DateTime(2021, 1, 15, 7, 00, 00), EndTime = new DateTime(2021, 1, 15, 7, 30, 00), DoctorId = 5 },
                new Checkup { TermId = 2, MedicalRecordId = 1, StartTime = new DateTime(2021, 1, 18, 7, 00, 00), EndTime = new DateTime(2021, 1, 18, 7, 30, 00), DoctorId = 4 },
                new Checkup { TermId = 3, MedicalRecordId = 3, StartTime = new DateTime(2021, 1, 18, 7, 30, 00), EndTime = new DateTime(2021, 1, 18, 8, 00, 00), DoctorId = 4 },
                new Checkup{ TermId = 4, MedicalRecordId = 4, StartTime = new DateTime(2021, 1, 18, 10, 00, 00), EndTime = new DateTime(2021, 1, 18, 10, 30, 00), DoctorId = 6 },
                new Checkup { TermId = 5, MedicalRecordId = 5, StartTime = new DateTime(2021, 1, 19, 7, 00, 00), EndTime = new DateTime(2021, 1, 19, 7, 30, 00), DoctorId = 10 },
                new Checkup { TermId = 6, MedicalRecordId = 6, StartTime = new DateTime(2021, 1, 19, 8, 00, 00), EndTime = new DateTime(2021, 1, 19, 8, 30, 00), DoctorId = 10 },
                new Checkup { TermId = 7, MedicalRecordId = 7, StartTime = new DateTime(2021, 1, 19, 8, 30, 00), EndTime = new DateTime(2021, 1, 19, 9, 00, 00), DoctorId = 9 },
                new Checkup { TermId = 8, MedicalRecordId = 8, StartTime = new DateTime(2021, 1, 19, 9, 00, 00), EndTime = new DateTime(2021, 1, 19, 9, 30, 00), DoctorId = 11 },
                new Checkup { TermId = 9, MedicalRecordId = 9, StartTime = new DateTime(2021, 1, 20, 7, 00, 00), EndTime = new DateTime(2021, 1, 20, 7, 30, 00), DoctorId = 12 },
                new Checkup { TermId = 10, MedicalRecordId = 10, StartTime = new DateTime(2021, 1, 20, 7, 30, 00), EndTime = new DateTime(2021, 1, 20, 8, 00, 00), DoctorId = 12 }
                );

   
        }

    }
}
