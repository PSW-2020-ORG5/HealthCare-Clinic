using IntegrationAdapters.Adapters;
using System.Collections.Generic;


namespace IntegrationAdapters.Factories
{
    public class ApiFactory
    {
        private Dictionary<string, IApiAdapter> apis { get; set; }
        private static ApiFactory instance = new ApiFactory();

        public ApiFactory()
        {
            apis = new Dictionary<string, IApiAdapter>();      
            // TODO: Send http request from here to lh:port/api/api to get list of apis and cache them into the dictionary, talk to PO about this issue
            
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
