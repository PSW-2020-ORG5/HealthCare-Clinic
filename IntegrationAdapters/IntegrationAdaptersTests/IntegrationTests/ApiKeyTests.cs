using IntegrationAdapters.Models;
using IntegrationAdapters.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace IntegrationAdaptersTests.IntegrationTests
{
    public class ApiKeyTests : IDisposable
    {

        readonly MyDbContext _context;

        public ApiKeyTests()
        {
            var serviceProvider = new Microsoft.Extensions.DependencyInjection.ServiceCollection()
            .AddEntityFrameworkMySql()
            .BuildServiceProvider();

        var builder = new DbContextOptionsBuilder<MyDbContext>();

        builder.UseMySql("server=localhost;port=3306;database=newmydb;user=root;password=1337")
                .UseInternalServiceProvider(serviceProvider);

        _context = new MyDbContext(builder.Options);
        _context.Database.Migrate();
        }

        [Fact]
        public void Find_all_existing_keys()
        {
            //Add some monsters before querying
            _context.Apis.Add(new Api { name = "lucyxz", api_key = "lucyxz_key"});
            _context.SaveChanges();

            List<Api> result = new List<Api>();
            _context.Apis.ToList().ForEach(api => result.Add(api));

            result.Count.ShouldBe(3);
        }
        
        [Fact]
        public void Remove_a_key_from_database()
        {
            //Add some monsters before querying
            _context.Apis.Add(new Api { name = "lucyxz", api_key = "lucyxz_key"});
            _context.SaveChanges();

            var found = _context.Apis.SingleOrDefault(item=>item.api_key == "lucyxz_key");

            if (found != null)
            {
                _context.Remove(found);
                _context.SaveChanges();
            }

            List<Api> result = new List<Api>();
            _context.Apis.ToList().ForEach(api => result.Add(api));

            result.Count.ShouldBe(2);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Database.EnsureDeleted();
            }
        }
    }
}
