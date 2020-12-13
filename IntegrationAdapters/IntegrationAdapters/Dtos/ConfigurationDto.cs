using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Dtos
{
    public class ConfigurationDto
    {
        public string myDbConnectionString { get; set; }

        private static ConfigurationDto instance = new ConfigurationDto();

        public static ConfigurationDto GetInstance()
        {
            return instance;
        }



    }
}
