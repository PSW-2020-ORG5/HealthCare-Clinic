using Appointments.Model;
using Appointments.Repository;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Appointments.Services
{
    public class DoctorCheckupService
    {

        //treba provjeriti i da li doktor ima zakazane termine u tom periodu
        public bool IsDoctorWorking(DoctorCheckupDTO doctorDTO, DateTime date)
        {
            var dateStart = date;

            //Da li se taj termin nalazi unutar radnog vremena
            if (dateStart.Date >= doctorDTO.FromDate && dateStart <= doctorDTO.ToDate)
            {
                return true;
            }
            return false;
        }

    }
}