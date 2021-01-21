
using Appointments.Model;
using Appointments.Repository;
using System;
using System.Collections.Generic;

namespace Appointments.Services
{
    public class CheckupService
    {
        private readonly CheckupRepository checkupRepository;
        private readonly DoctorCheckupService doctorService;
        private readonly MedicalRecordService medicalRecordService;
        public CheckupService(AppointmentsDbContext dbContext)
        {
            checkupRepository = new CheckupRepository(dbContext);
            doctorService = new DoctorCheckupService();
            medicalRecordService = new MedicalRecordService(dbContext);
        }

        public void CancelCheckup(Checkup checkup)
        {
            checkupRepository.DeleteById(checkup.TermId);
        }

        public bool CancelCheckup(int id)
        {
            return checkupRepository.DeleteById(id);
        }

        public void EditCheckup(Checkup checkup)
        {
            List<Checkup> allCheckups = (List<Checkup>)checkupRepository.FindAll();
            Checkup checkupForEdit = new Checkup();
            
            foreach(Checkup c in allCheckups)
            {
                if(c.TermId == checkup.TermId)
                {
                    checkupForEdit = c;
                    break;
                }
            }

            CancelCheckup(checkupForEdit);
            //ScheduleCheckup(checkup);


        }

        public bool ScheduleCheckup(DoctorCheckupDTO dto)
        {   
            MedicalRecord medicalRecord = medicalRecordService.GetByPatientId(dto.PatientId);
            if (medicalRecord == null)
            {
                medicalRecord = new MedicalRecord();
                medicalRecord.PatientId = dto.PatientId;
                medicalRecordService.Add(medicalRecord);

            }

            var checkup = new Checkup();
            checkup.DoctorId = dto.DoctorId;
            checkup.StartTime = dto.CheckupStartTime;
            checkup.EndTime = dto.CheckupEndTime;
            checkup.MedicalRecordId = medicalRecord.MedicalRecordId;
            if (medicalRecord.Checkups == null)
            {
                medicalRecord.Checkups = new List<Checkup>();
            }

            if (checkup.StartTime.Date >= dto.FromDate && checkup.StartTime <= dto.ToDate)
            {
                medicalRecord.Checkups.Add(checkup);
                medicalRecordService.Update(medicalRecord);

                checkupRepository.Save(checkup);
                return true;
            }

            return false;
        }


        public List<Checkup> getAllCheckups()
        {
            return (List<Checkup>)checkupRepository.FindAll();
        }

        public List<Checkup> GetAllCheckupsForPatient(int patientId)
        {
            
            List<Checkup> allCheckups = (List<Checkup>)checkupRepository.FindAll();
            List<Checkup> result = new List<Checkup>();
            var medicalRecord = medicalRecordService.GetByPatientId(patientId);
            if (medicalRecord != null)
            {
                foreach (Checkup checkup in allCheckups)
                {
                    if (checkup.MedicalRecordId == medicalRecord.MedicalRecordId)
                    {
                        result.Add(checkup);
                    }
                }
            }
            return result;
        }

        public Term FindById(int id)
        {
            return checkupRepository.FindById(id);
        }

        public List<Checkup> GetAllCheckupsForDoctor(int doctorId)
        {
            List<Checkup> allCheckups = (List<Checkup>)checkupRepository.FindAll();
            List<Checkup> result = new List<Checkup>();
            foreach (Checkup checkup in allCheckups)
            {
                Console.WriteLine(checkup.DoctorId);
                if (checkup.DoctorId == doctorId)
                {
                    result.Add(checkup);
                }
            }
            Console.WriteLine(doctorId);
            Console.WriteLine(result.Count);
            return result;
        }

        public List<Checkup> FreeCheckupsForDoctorOnDate(DoctorCheckupDTO dto,DateTime date) {
            var freeList = new List<Checkup>();
            if (doctorService.IsDoctorWorking(dto, date)){
                var startTime = new DateTime(date.Year, date.Month, date.Day, dto.FromHour.Hour, 0, 0);
                var endTime = new DateTime(date.Year, date.Month, date.Day, dto.ToHour.Hour, 0, 0);
                while (startTime < endTime)
                {
                    var checkup = new Checkup();
                    checkup.DoctorId = dto.DoctorId;
                    checkup.StartTime = startTime;
                    checkup.EndTime = startTime.AddMinutes(30);
                    startTime = startTime.AddMinutes(30);
                    if (IsDoctorCheckupFree(checkup))
                    {
                        freeList.Add(checkup);
                    }
                }
            }
            return freeList;
        }

        public bool IsDoctorCheckupFree(Checkup checkupP)
        {
            List<Checkup> checkups = GetAllCheckupsForDoctor(checkupP.DoctorId);
            foreach (Checkup checkup in checkups)
            {
                if (checkup.StartTime == checkupP.StartTime) return false;
                if (checkup.EndTime == checkupP.EndTime) return false;

                if (checkup.StartTime < checkupP.StartTime)
                {
                    if (checkup.EndTime > checkupP.StartTime && checkup.EndTime < checkupP.EndTime)
                        return false; // Condition 1

                    if (checkup.EndTime > checkupP.EndTime)
                        return false; // Condition 3
                }
                else
                {
                    if (checkupP.EndTime > checkup.StartTime && checkupP.EndTime < checkup.EndTime)
                        return false; // Condition 2

                    if (checkupP.EndTime > checkup.EndTime)
                        return false; // Condition 4
                }
            }
            return true;
        }
    }
}