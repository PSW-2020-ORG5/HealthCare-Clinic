using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointments.Model
{
    public class MedicalRecord
    {
        public int MedicalRecordId { get; set; }
        public List<Treatment> Treatments { get; set; }
        public int? DoctorId { get; set; }
        public List<Checkup> Checkups { get; set; }
        public List<ReferralToSpecialist> RferralToSpecialist { get; set; }
        public int PatientId { get; set; }
        public List<Report> Reports { get; set; }

        public MedicalRecord() { }
    }
}
