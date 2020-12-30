using IntegrationAdapters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Services.TestServices
{
    public class TenderServiceTest
    {
        public int GetNumberOfTenders(IMyDbContext myDbContext)
        {
            return myDbContext.GetTenders().Count;
        }

        public int SaveTender(IMyDbContext myDbContext, Tender tender)
        {
            myDbContext.GetTenders().Add(tender);
            return myDbContext.GetTenders().Count;
        }
    }
}
