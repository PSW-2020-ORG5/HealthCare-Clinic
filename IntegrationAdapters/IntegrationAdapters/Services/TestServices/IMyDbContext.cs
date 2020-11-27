using IntegrationAdapters.Models;
using System.Collections.Generic;

namespace IntegrationAdapters.Services.TestServices
{
    public interface IMyDbContext
    {
        List<Api> GetApis();
    }
}
