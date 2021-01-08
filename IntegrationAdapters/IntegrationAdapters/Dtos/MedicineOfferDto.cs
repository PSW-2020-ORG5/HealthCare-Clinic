using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Dtos
{
    public class MedicineOfferDto
    {

        public string PharmacyName { get; set; }
  
        public string Name { get; set; }
        public int Amount { get; set; }

        public int PricePerUnit { get; set; }

        public MedicineOfferDto(string pharmacyName, string name, int amount, int pricePerUnit)
        {
            PharmacyName = pharmacyName;
            Name = name;
            Amount = amount;
            PricePerUnit = pricePerUnit;
        }
    }
}
