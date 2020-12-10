using IntegrationAdapters.Adapters;
using System.Collections.Generic;


namespace IntegrationAdapters.Factories
{
    public class ApiFactory
    {
        private Dictionary<string, IApiAdapter> Apis { get; set; }
        private static readonly ApiFactory instance = new ApiFactory();

        public ApiFactory()
        {
            Apis = new Dictionary<string, IApiAdapter>();
        }

        public static ApiFactory GetInstance()
        {
            return instance;
        }

        public IApiAdapter GetApi(string apiKey)
        {
            return Apis[apiKey];
        }
    }
}
