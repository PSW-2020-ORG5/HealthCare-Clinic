using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointments.Model
{
    public class DoctorCheckupDTO
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime FromHour { get; set; }
        public DateTime ToHour { get; set; }
        public DateTime CheckupStartTime { get; set;}
        public DateTime CheckupEndTime { get; set; }


        public DoctorCheckupDTO() { }
    }
}
