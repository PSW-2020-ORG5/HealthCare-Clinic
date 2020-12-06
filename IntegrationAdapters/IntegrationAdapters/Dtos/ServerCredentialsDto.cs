using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Dtos
{
    public class ServerCredentialsDto
    {
        public string SourceFolder { get; set; }
        public string ServerFolder { get; set; }
        public string Ip { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        private static readonly ServerCredentialsDto instance = JsonConvert.DeserializeObject<ServerCredentialsDto>(System.IO.File.ReadAllText("ftpsettings.json"));
        
        public static ServerCredentialsDto GetInstance()
        {
            return instance;
        }
    }
}
