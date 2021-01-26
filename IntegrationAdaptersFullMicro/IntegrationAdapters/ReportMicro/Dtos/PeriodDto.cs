using IntegrationAdapters.Models;
using System;
using System.Globalization;

namespace IntegrationAdapters.Dtos
{
    //vo
    public class PeriodDto : ValueObject
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public PeriodDto()
        {
        }

        public PeriodDto(string startDate, string endDate)
        {
           
            this.StartDate = startDate; // dd-mm-yyyy
            this.EndDate = endDate;

            Validate();
        }

        protected override void Validate()
        {
            if (StartDate == "" || EndDate == "")
            {
                throw new Exception("Error, empty strings!");
            }

            DateTime dtStart = DateTime.ParseExact(StartDate, "yyyy-mm-dd", CultureInfo.InvariantCulture);
            DateTime dtEnd = DateTime.ParseExact(EndDate, "yyyy-mm-dd", CultureInfo.InvariantCulture);

            if (dtStart > dtEnd)
            {
                throw new Exception("Error, EndDate cannot be before StartDate!");

            }
        }

        protected override bool EqualsValue(object o)
        {
            PeriodDto other = (PeriodDto)o; 

            return other.StartDate == this.StartDate && other.EndDate == this.EndDate;
        }

        protected override String PrintObject()
        {
            string ret = "Start date: " + StartDate + "\n";
            ret += "End date: " + EndDate;

            return ret;
        }
    }
}
