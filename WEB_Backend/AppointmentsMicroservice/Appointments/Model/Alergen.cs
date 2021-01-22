using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointments.Model
{
    public class Alergen
    {
        public int AlergenId { get; set; }
        public string AlergenCode { get; set; }
        public string AlergenName { get; set; }

        public Alergen() { }
    }
}
