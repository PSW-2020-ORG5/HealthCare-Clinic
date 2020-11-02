// File:    SurveyResponse.cs
// Author:  Vaxi
// Created: Wednesday, April 29, 2020 6:50:06 PM
// Purpose: Definition of Class SurveyResponse

using HealthClinic.Utilities;
using Model.Users;
using System;
using System.Collections.ObjectModel;

namespace Model.Survey
{
    public class SurveyResponse : ObservableObject
    {
        private int id;
        private Rate quality;
        private Rate security;
        private Rate kindness;
        private Rate professionalism;
        private int mark; 
        private string comment;
        private int doctorId;
        private int patientId;
        private bool anonymous;
        private bool publishable;

        public SurveyResponse()
        {
        }

        public SurveyResponse(String quality,String security, String kindness, String professionalism, String comment, bool anonymous, bool publishable)
        {
            this.id = -1; // smisliti nacin da se implementira survey id, i doctor i patient id

            this.doctorId = -1;

            this.patientId = -1;


            if (quality.ToLower().Equals("terrible"))
                this.Quality = Rate.Terrible;
            else if (quality.ToLower().Equals("bad"))
                this.Quality = Rate.Bad;
            else if (quality.ToLower().Equals("good"))
                this.Quality = Rate.Good;
            else if (quality.ToLower().Equals("great"))
                this.Quality = Rate.Great;
            else if (quality.ToLower().Equals("excelent"))
                this.Quality = Rate.Excellent;

            if (security.ToLower().Equals("terrible"))
                this.Security = Rate.Terrible;
            else if (security.ToLower().Equals("bad"))
                this.Security = Rate.Bad;
            else if (security.ToLower().Equals("good"))
                this.Security = Rate.Good;
            else if (security.ToLower().Equals("great"))
                this.Security = Rate.Great;
            else if (security.ToLower().Equals("excelent"))
                this.Security = Rate.Excellent;

            if (kindness.ToLower().Equals("terrible"))
                this.Kindness = Rate.Terrible;
            else if (kindness.ToLower().Equals("bad"))
                this.Kindness = Rate.Bad;
            else if (kindness.ToLower().Equals("good"))
                this.Kindness = Rate.Good;
            else if (kindness.ToLower().Equals("great"))
                this.Kindness = Rate.Great;
            else if (kindness.ToLower().Equals("excelent"))
                this.Kindness = Rate.Excellent;

            if (professionalism.ToLower().Equals("terrible"))
                this.Professionalism = Rate.Terrible;
            else if (professionalism.ToLower().Equals("bad"))
                this.Professionalism = Rate.Bad;
            else if (professionalism.ToLower().Equals("good"))
                this.Professionalism = Rate.Good;
            else if (professionalism.ToLower().Equals("great"))
                this.Professionalism = Rate.Great;
            else if (professionalism.ToLower().Equals("excelent"))
                this.Professionalism = Rate.Excellent;

            this.comment = comment;

            this.anonymous = anonymous;

            this.publishable = publishable;

        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Mark
        {
            get
            {
                return mark;
            }
            set
            {
                this.mark = value;
                OnPropertyChanged("Mark");
            }
        }

        public Rate Quality
        {
            get
            {
                return quality;
            }
            set
            {
                this.quality = value;
                OnPropertyChanged("Quality");
            }
        }
        public Rate Security
        {
            get
            {
                return security;
            }
            set
            {
                this.security = value;
                OnPropertyChanged("Security");
            }
        }
        public Rate Kindness
        {
            get
            {
                return kindness;
            }
            set
            {
                this.kindness = value;
                OnPropertyChanged("Kindness");
            }
        }
        public Rate Professionalism
        {
            get
            {
                return professionalism;
            }
            set
            {
                this.professionalism = value;
                OnPropertyChanged("Professionalism");
            }
        }
        public string Comment
        {
            get
            {
                return comment;
            }
            set
            {
                this.comment = value;
                OnPropertyChanged("Comment");
            }
        }
        public int PatientId
        {
            get
            {
                return patientId;
            }
            set
            {
                this.patientId = value;
                OnPropertyChanged("PatientId");
            }
        }


        public int DoctorId
        { 
            get 
            { 
                return doctorId; 
            } 
            set 
            { 
                doctorId = value; 
                OnPropertyChanged("DoctorId"); 
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