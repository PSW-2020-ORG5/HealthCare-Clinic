using Health_Clinic_Integration.Models;
using IntegrationAdapters.Models;
using Microsoft.EntityFrameworkCore;


namespace IntegrationAdapters.Repositories.DbContexts
{
    public class MyDbContext : DbContext
    {
        public DbSet<Api> Apis { get; set; }
        public DbSet<ActionBenefit> ActionsBenefits { get; set; }
        public DbSet<Tender> Tenders { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Api>().HasData(
                new Api { name = "Zegin", api_key = "zegin_key"},
                new Api { name = "Benu", api_key = "benu_key"}
           );
        }
    }
}
