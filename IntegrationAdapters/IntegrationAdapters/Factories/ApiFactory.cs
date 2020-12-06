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
            // TODO: Send http request from here to lh:port/api/api to get list of apis and cache them into the dictionary, talk to PO about this issue   
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
