// File:    Doctor.cs
// Author:  Vaxi
// Created: Wednesday, April 1, 2020 9:43:20 PM
// Purpose: Definition of Class Doctor

using Model.BusinessHours;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Model.Users
{
    public class Doctor : Employee
    {


        public SpecialtyType SpecialtyType { get; set; }

        public bool AbleToValidateMedicines { get; set; }

        public bool AbleToPrescribeTreatments { get; set; }
        
    }
}