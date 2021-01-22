using Appointments.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointments.Repository
{
    public class MedicalRecordRepository : IRepository<MedicalRecord, Int32>

    {
        private readonly AppointmentsDbContext dbContext;

        public MedicalRecordRepository(AppointmentsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MedicalRecord> FindAll()
        {
            return dbContext.MedicalRecords.ToList();
        }

        public MedicalRecord FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(MedicalRecord entity)
        {
             dbContext.Add(entity);
            dbContext.SaveChanges();
        }

        public void Update(MedicalRecord entity)
        {
            dbContext.Update(entity);
        }

        public void SaveAll(IEnumerable<MedicalRecord> entities)
        {
            throw new NotImplementedException();
        }
    }
}
