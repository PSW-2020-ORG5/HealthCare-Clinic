
using IntegrationAdapters.Dtos;
using IntegrationAdapters.Models;
using Microsoft.EntityFrameworkCore;


namespace IntegrationAdapters.Repositories.DbContexts
{
    public class MyTenderContext : DbContext
    {
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<TenderOfferDto> TenderOffers { get; set; }

        public MyTenderContext(DbContextOptions<MyTenderContext> options) : base(options)
        {
        }

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Api>().HasData(
           //     new Api { name = "Zegin", api_key = "zegin_key"},
           //     new Api { name = "Benu", api_key = "benu_key"}
           //);

            modelBuilder.Entity<TenderOfferDto>().HasKey(t => new { t.Id, t.PharmacyName});
            modelBuilder.Entity<MedicineOfferDto>().HasKey(t => new { t.PharmacyName, t.Name});
        }
    }
}
