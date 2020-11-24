using HealthClinic.Utilities;
using Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Survey
{
    public class AppReview : ObservableObject
    {
        
        private string reviewText;
        private bool anonymous;
        private bool publishable;
        private bool published;
        private int patientId;
        private int appReviewId;

        /* private PatientModel patient;                      // izbaceno izmedju 3. i 4. migracije

                public virtual PatientModel Patient          
                {
                    get { return patient; }
                    set
                    {
                        patient = value;
                        OnPropertyChanged("Patient");
                    }
                }

                [ForeignKey("Patient")]*/
        public int PatientId
        {
            get { return patientId; }
            set
            {
                patientId = value;
                OnPropertyChanged("PatientId");
            }
        }

        [Key]
        public int AppReviewId
        {
            get { return appReviewId; }
            set
            {
                appReviewId = value;
                OnPropertyChanged("AppReviewId");
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

        public bool Published
        {
            get
            {
                return published;
            }
            set
            {
                published = value;
                OnPropertyChanged("Published");
            }
        }
    }
}
