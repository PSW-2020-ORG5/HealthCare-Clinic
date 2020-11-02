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
        private string anonymous;
        private string publishable;

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

        public string Anonymous
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

        public string Publishable
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