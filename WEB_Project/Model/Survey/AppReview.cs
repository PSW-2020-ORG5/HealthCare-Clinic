using HealthClinic.Utilities;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Survey
{
    public class AppReview : ObservableObject
    {
        private string reviewText;
        private PatientModel patient;
        private bool anonymous;
        private bool publishable;


        public PatientModel Patient
        {
            get { return patient; }
            set
            {
                patient = value;
                OnPropertyChanged("Patient");
            }
        }

        public string ReviewText
        {
            get { return reviewText; }
            set
            {
                reviewText = value;
                OnPropertyChanged("ReviewText");
            }
        }

        public bool Anonymous
        {
            get
            {
                return anonymous;
            }
            set
            {
                anonymous = value;
                OnPropertyChanged("Anonymous");
            }
        }

        public bool Publishable
        {
            get
            {
                return publishable;
            }
            set
            {
                publishable = value;
                OnPropertyChanged("Publishable");
            }
        }
    }
}
