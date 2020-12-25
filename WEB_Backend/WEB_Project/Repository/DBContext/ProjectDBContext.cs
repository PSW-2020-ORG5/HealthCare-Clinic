using Microsoft.EntityFrameworkCore;
using Model.BusinessHours;
using Model.Survey;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Health_Clinic_Web_App.Repository.DBContext
{
    public class ProjectDBContext : DbContext
    {
        public DbSet<AppReview> AppReviews { get; set; }
        //public DbSet<BusinessHoursModel> BusinessHoursModels { get; set; }
        //public DbSet<Doctor> Doctors { get; set; }

        public ProjectDBContext() : base() { }
        public ProjectDBContext(DbContextOptions<ProjectDBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
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
            modelBuilder.Entity<AppReview>().HasData(
                new AppReview { PatientId = 1, Anonymous = false, AppReviewId = 1, Publishable = true, Published = true, ReviewText = "lose" }
            );
        }
    }
}
