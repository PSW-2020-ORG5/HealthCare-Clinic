using IntegrationAdapters.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Dtos
{
    public class TenderOfferDto : Entity
    {
        public string Id { get; set; }
        public string PharmacyName { get; set; }
        public string Endpoint { get; set; }

        public virtual List<MedicineOfferDto> OfferedMedicine { get; set; }

        public TenderOfferDto()
        {
        }

        public TenderOfferDto(string id, string pharmacyName, string endpoint, List<MedicineOfferDto> offeredMedicine)
        {
            Id = id;
            PharmacyName = pharmacyName;
            Endpoint = endpoint;
            OfferedMedicine = offeredMedicine;
        }

        protected override void Validate()
        {
            if (PharmacyName == "" || Id == "")
            {
                throw new Exception("Error, empty strings!");
            }
        }
    }
}
