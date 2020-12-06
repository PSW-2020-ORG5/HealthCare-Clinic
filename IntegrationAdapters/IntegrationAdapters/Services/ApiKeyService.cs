using IntegrationAdapters.Models;
using IntegrationAdapters.Repositories.DbContexts;
using System.Collections.Generic;
using System.Linq;

namespace IntegrationAdapters.Services
{
    public class ApiKeyService
    {
        private readonly MyDbContext dbContext;

        public ApiKeyService(MyDbContext context)
        {
            this.dbContext = context;
        }

        public List<Api> GetAll()
        {
            List<Api> result = new List<Api>();
            dbContext.Apis.ToList().ForEach(api => result.Add(api));

            return result;
        }

        public Api GetById(string id)
        {
            List<Api> result = new List<Api>();
            dbContext.Apis.ToList().ForEach(api => result.Add(api));
            foreach (Api api in result)
            {
                if (api.name == id) return api;
            }

            return null;
        }

        public void Save(Api api)
        {
            dbContext.Apis.Add(api);
            dbContext.SaveChanges();
        }
    }
}
