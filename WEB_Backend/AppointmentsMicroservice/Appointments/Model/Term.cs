using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointments.Model
{
    public class Term
    {
        public int TermId { get; set; }
        public int MedicalRecordId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        public Term() { }
    }
}
