using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Models
{
    public class Api
    {
        
        public string name { get; set; }

        [Key]
        public string api_key { get; set; }

    }
}
