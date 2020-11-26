using IntegrationAdapters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Services.TestServices
{
    public interface IMyDbContext
    {
        List<Api> GetApis();
    }
}
