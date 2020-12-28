// File:    BusinessHoursModel.cs
// Author:  Vaxi
// Created: Tuesday, April 21, 2020 8:27:16 PM
// Purpose: Definition of Class BusinessHoursModel

using Model.Users;
using System;
using System.Collections;

namespace Model.BusinessHours
{
    public class BusinessHoursModel
    {

        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime FromHour { get; set; }
        
        public DateTime ToHour { get; set; }
       
    }
}