using System;
using System.ComponentModel.DataAnnotations;

namespace IntegrationAdapters.Models
{
    public class ApiKey 
    {      
        public string name { get; set; }
        [Key]
        public string api_key { get; set; }

        public string baseUrl { get; set; }

        public string email { get; set; }

        public string grpcPort { get; set; }

        public bool isUsingFtp { get; set; }

        public ApiKey()
        {
        }

        public ApiKey(string name, string api_key)
        {
            this.name = name;
            this.api_key = api_key;
        }

        public ApiKey(string name, string api_key, string baseUrl) : this(name, api_key)
        {
            this.baseUrl = baseUrl;
        }

        public ApiKey(string name, string api_key, string baseUrl, string email, string grpcPort, bool isUsingFtp) : this(name, api_key, baseUrl)
        {
            this.email = email;
            this.grpcPort = grpcPort;
            this.isUsingFtp = isUsingFtp;
        }
    }




}
