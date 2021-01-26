
using IntegrationAdapters.Dtos;
using IntegrationAdapters.Models;
using Microsoft.EntityFrameworkCore;


namespace IntegrationAdapters.Repositories.DbContexts
{
    public class MyReportContext : DbContext
    {
        //public DbSet<Api> Apis { get; set; }
        //public DbSet<ActionBenefit> ActionsBenefits { get; set; }
        //public DbSet<Tender> Tenders { get; set; }
        //public DbSet<MedicineOfferDto> MedicineOffers { get; set; }
        //public DbSet<TenderOfferDto> TenderOffers { get; set; }

        
        public MyReportContext(DbContextOptions<MyReportContext> options) : base(options)
        {
        }

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
          //  modelBuilder.Entity<TenderOfferDto>().HasKey(t => new { t.Id, t.PharmacyName});
          //  modelBuilder.Entity<MedicineOfferDto>().HasKey(t => new { t.PharmacyName, t.Name});
        }
    }
}
