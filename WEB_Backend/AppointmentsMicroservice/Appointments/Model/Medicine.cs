using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointments.Model
{
    public class Medicine
    {
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public string Manufacturer { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public MedicineStatus MedicineStatus { get; set; }
        public List<Alergen> Alergen { get; set; }
        public List<Ingredient> Ingredient { get; set; }
        public string MedicineType { get; set; }
        public string SideEffects { get; set; }

        public Medicine() { }
    }
}

public enum MedicineStatus
{
    validated,
    rejected,
    waiting,
    missing
}