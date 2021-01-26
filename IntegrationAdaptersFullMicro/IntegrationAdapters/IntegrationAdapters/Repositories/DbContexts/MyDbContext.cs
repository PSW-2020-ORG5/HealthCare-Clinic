
using Health_Clinic_Integration.Models;
using IntegrationAdapters.Dtos;
using IntegrationAdapters.Models;
using Microsoft.EntityFrameworkCore;


namespace IntegrationAdapters.Repositories.DbContexts
{
    public class MyDbContext : DbContext
    {
        public DbSet<ApiKey> Apis { get; set; }
        public DbSet<ActionBenefit> ActionsBenefits { get; set; }
        public DbSet<Tender> Tenders { get; set; }
       // public DbSet<MedicineOfferDto> MedicineOffers { get; set; }
        public DbSet<TenderOfferDto> TenderOffers { get; set; }

        
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ApiKey>().HasData(
                 new ApiKey { name = "Zegin", api_key = "zegin_key" },
                 new ApiKey { name = "Benu", api_key = "benu_key" }
            );

            modelBuilder.Entity<TenderOfferDto>().HasKey(t => new { t.Id, t.PharmacyName });
            modelBuilder.Entity<MedicineOfferDto>().HasKey(t => new { t.PharmacyName, t.Name });

        }
    }
}
