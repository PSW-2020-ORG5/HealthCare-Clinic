using Model.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Health_Clinic_Web_App.DTO
{
    public class SurveyResponseDTO
    {
        public String Quality;
        public String Security;
        public String Kindness;
        public String Professionalism;
        public String Comment;
        public bool Anonymous;
        public bool Publishable;

        public SurveyResponseDTO()
        {
        }
    }
}
