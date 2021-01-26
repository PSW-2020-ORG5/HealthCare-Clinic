using IntegrationAdapters.Dtos;
using IntegrationAdapters.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Models
{
    public class Tender : Entity
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

        public Tender(string id, string name, DateTime closingDate, List<MedicineDto> requiredMedicine)
        {
            this.id = id;
            Name = name;
            ClosingDate = closingDate;
            RequiredMedicine = requiredMedicine;
        }

        protected override void Validate()
        {
            if (Name == "" || id == "")
            {
                throw new Exception("Error, empty strings!");
            }

            if (ClosingDate == null)
            {
                throw new Exception("Error, ClosingDate is null!");
            }



        }

    }
}
