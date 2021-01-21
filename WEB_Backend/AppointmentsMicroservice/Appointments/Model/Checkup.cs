using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointments.Model
{
    public class Checkup : Term
    {
        public int DoctorId { get; set; }

        public Checkup() { }
    }
}
