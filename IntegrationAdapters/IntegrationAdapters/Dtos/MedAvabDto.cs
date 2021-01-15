using System;

namespace IntegrationAdapters.Dtos
{
    public class MedAvabDto
    {
        public String Pharmacy { get; set; }
        public String Location { get; set; }
        public Boolean IsAvab { get; set; }

        public MedAvabDto(string pharmacy, string location, bool isAvab)
        {
            Pharmacy = pharmacy;
            Location = location;
            IsAvab = isAvab;
        }
    }
}
