using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointments.Model
{
    public class ReferralToSpecialist
    {
        public int Id { get; set; }
        public DateTime ValidFromDate { get; set; }
        public int DoctorId { get; set; }

        public ReferralToSpecialist() { }
    }
}
