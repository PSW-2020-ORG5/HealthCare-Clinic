using Microsoft.EntityFrameworkCore;
using Model.BusinessHours;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.Events;

namespace LoginMicroservice.Repository
{
    public class UserDbContext : DbContext
    {
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<LoginEvent> Events { get; set; }

        //public DbSet<BusinessHoursModel> BusinessHours {get;set;}
        public DbSet<PatientModel> Patients { get; set; }

        public UserDbContext() : base() { }
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                Console.WriteLine(CreateConnectionStringFromEnvironment());
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
            modelBuilder.Entity<RegisteredUser>().HasData(
                new RegisteredUser { Username="marko1" ,Password="marko1" , Name="Marko", Surname="Markovic",Id=1 ,Email="marko1@gmail.com",Role=UserRole.patient},
                new RegisteredUser { Username = "marko2", Password = "marko2", Name = "Marko", Surname = "Markovic", Id = 2, Email = "marko1@gmail.com",Role=UserRole.admin});

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id=4 ,Name="Nikola",Surname="Nikolic",Email="nnikolic@gmail.com",Username="nikola01",Password="nikola02"}
                );
        }

    }
}
