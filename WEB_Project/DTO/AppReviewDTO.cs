using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Health_Clinic_Web_App.DTO
{
    public class AppReviewDTO // patient feedback (sprint 1)
    {
        [JsonProperty("reviewText")]
        public String reviewText { get; set; }


        [JsonProperty("anonymous")]
        public bool anonymous { get; set; }


        [JsonProperty("publishable")]
        public bool publishable { get; set; }

        public AppReviewDTO() { }
    }
}
