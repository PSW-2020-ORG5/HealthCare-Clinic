using IntegrationAdapters.Models;
using System;

namespace IntegrationAdapters.Services.TestServices
{
    public class ApiKeyServiceTest
    {
        public int GetNumberOfApiKeys(IMyDbContext myDbContext)
        {
            return myDbContext.GetApis().Count;
        }

        public int SaveKey(IMyDbContext myDbContext, Api key)
        {           
            if (key.name == "") return myDbContext.GetApis().Count;
            myDbContext.GetApis().Add(key);

            return myDbContext.GetApis().Count;
        }

        public Api GetKey(IMyDbContext myDbContext, string name)
        {
            var retList = myDbContext.GetApis();
            foreach (Api key in retList)
            {
                if (key.name == name) return key;
            }

            return null;
        }
    }
}
