using System.ComponentModel.DataAnnotations;

namespace IntegrationAdapters.Models
{
    public class Api
    {      
        public string name { get; set; }
        [Key]
        public string api_key { get; set; }

        public Api()
        {
        }

        public Api(string name, string api_key)
        {
            this.name = name;
            this.api_key = api_key;
        }
    }
}
