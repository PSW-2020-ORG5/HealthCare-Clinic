using Appointments.Model;
using Appointments.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointments.Services
{
    public class MedicalRecordService
    {
        private readonly MedicalRecordRepository repository;

        public MedicalRecordService(AppointmentsDbContext dbContext)
        {
            this.repository = new MedicalRecordRepository(dbContext); 
        }

        public List<MedicalRecord> FindAll()
        {
            return (List<MedicalRecord>)repository.FindAll();
        }

        public MedicalRecord GetByPatientId(int id)
        {
            var medRecords = FindAll();
            foreach(MedicalRecord mr in medRecords)
            {
                if (mr.PatientId == id)
                {
                    return mr;
                }
            }
            return null;
        }

        public void Update(MedicalRecord medicalRecord)
        {
            repository.Update(medicalRecord);
        }

        public void Add(MedicalRecord medicalRecord)
        {
            repository.Save(medicalRecord);
        }



    }
}
