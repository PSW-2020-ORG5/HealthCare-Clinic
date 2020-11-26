using IntegrationAdapters.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Factories
{
    public class ApiFactory
    {
        private Dictionary<string, IApiAdapter> apis { get; set; }
        private static ApiFactory instance = new ApiFactory();

        public ApiFactory()
        {
            apis = new Dictionary<string, IApiAdapter>();
            // poslati http get zahtev na /api/api koji vraca listu api-a i kesirati u hashmapu - problem sa async task-om kako ga pozvati odavde        

        }

        public static ApiFactory getInstance()
        {
            return instance;
        }

        public IApiAdapter getApi(string apiKey)
        {
            return apis[apiKey];
        }
        

    }
}
