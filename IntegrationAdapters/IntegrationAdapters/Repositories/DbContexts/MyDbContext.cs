using IntegrationAdapters.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Repositories.DbContexts
{
    public class MyDbContext : DbContext
    {
        public DbSet<Api> Apis { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        // testing purposes 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Api>().HasData(
                new Api { name = "Zegin", api_key = "zegin_key"},
                new Api { name = "Benu", api_key = "benu_key"}
           );

        }

    }
}
