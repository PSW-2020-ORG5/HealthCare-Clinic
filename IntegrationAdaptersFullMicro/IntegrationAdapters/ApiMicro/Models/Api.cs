using System;
using System.ComponentModel.DataAnnotations;

namespace IntegrationAdapters.Models
{
    public class Api : Entity
    {      
        public string name { get; set; }
        [Key]
        public string api_key { get; set; }

        public string baseUrl { get; set; }

        public string email { get; set; }

        public string grpcPort { get; set; }

        public bool isUsingFtp { get; set; }

        public Api()
        {
        }

        public Api(string name, string api_key)
        {
            this.name = name;
            this.api_key = api_key;
            Validate();
        }

        public Api(string name, string api_key, string baseUrl) : this(name, api_key)
        {
            this.baseUrl = baseUrl;
            Validate();
        }

        public Api(string name, string api_key, string baseUrl, string email, string grpcPort, bool isUsingFtp) : this(name, api_key, baseUrl)
        {
            this.email = email;
            this.grpcPort = grpcPort;
            this.isUsingFtp = isUsingFtp;
        }

        protected override void Validate()
        {
            if (name == "" || api_key == "")
            {
                throw new Exception("Error, empty strings!");
            }

            

        }

    }




}
