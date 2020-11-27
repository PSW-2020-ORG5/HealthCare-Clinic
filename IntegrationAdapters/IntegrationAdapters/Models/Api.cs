using System.ComponentModel.DataAnnotations;

namespace IntegrationAdapters.Models
{
    public class Api
    {
        
        public string name { get; set; }

        [Key]
        public string api_key { get; set; }

    }
}
