using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace IntegrationAdapters.Dtos
{
    public class TenderDto
    {
        public string Name { get; set; }
        public string ClosingDate { get; set; }

        public List<MedicineDto> RequiredMedicine { get; set; }

    }
}
