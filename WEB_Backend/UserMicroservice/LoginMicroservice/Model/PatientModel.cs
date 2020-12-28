// File:    Patient.cs
// Author:  Vaxi
// Created: Friday, March 20, 2020 4:32:04 PM
// Purpose: Definition of Class Patient

using Model.Patient;
using System;

namespace Model.Users
{
    public class PatientModel : RegisteredUser
    { 
          public int MedicalRecordId { get; set; }


    }

}