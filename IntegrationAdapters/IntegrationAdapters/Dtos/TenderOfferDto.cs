using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Dtos
{
    public class TenderOfferDto
    {
        public string Id { get; set; }
        public string PharmacyName { get; set; }
        public string Endpoint { get; set; }

        public virtual List<MedicineOfferDto> OfferedMedicine { get; set; }

    }
}
