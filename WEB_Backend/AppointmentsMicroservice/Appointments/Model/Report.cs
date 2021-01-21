using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointments.Model
{
    public class Report
    {
        public int Id { get; set; }
        public string PatientsReport { get; set; }
        public string DoctorsRemark { get; set; }
        /*public List<string> CommonMedicalConditions { get; set; }
        public List<string> Observations { get; set; }*/
        public int TermId { get; set; }

        public Report() { }
    }
}
