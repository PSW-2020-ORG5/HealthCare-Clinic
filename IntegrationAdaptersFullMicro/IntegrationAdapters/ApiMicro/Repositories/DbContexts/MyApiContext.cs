
using IntegrationAdapters.Models;
using Microsoft.EntityFrameworkCore;


namespace IntegrationAdapters.Repositories.DbContexts
{
    public class MyApiContext : DbContext
    {
        public DbSet<Api> Apis { get; set; }
        
        public MyApiContext(DbContextOptions<MyApiContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Api>().HasData(
                new Api { name = "Zegin", api_key = "zegin_key" },
                new Api { name = "Benu", api_key = "benu_key" }
           );
        }
    }
}
