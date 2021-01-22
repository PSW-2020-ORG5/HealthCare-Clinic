using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointments.Model
{
    public class Treatment
    {
        public int Id { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
        public String Instructions { get; set; }
        public List<Medicine> Medicines { get; set; }

        public Treatment() { }
    }
}
