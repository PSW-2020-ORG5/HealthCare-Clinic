using IntegrationAdapters.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Models
{
    public class Tender
    {
        [Key]
        public string id { get; set; }
        public string Name { get; set; }
        public DateTime ClosingDate { get; set; }

        public virtual List<MedicineDto> RequiredMedicine { get; set; }

        public Tender()
        {

        }

        public Tender(string name, DateTime closingDate, List<MedicineDto> requiredMedicine)
        {
            Name = name;
            ClosingDate = closingDate;
            RequiredMedicine = requiredMedicine;
        }
    }
}
