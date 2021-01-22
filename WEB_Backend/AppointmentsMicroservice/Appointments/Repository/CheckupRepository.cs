using Appointments.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointments.Repository
{
    public class CheckupRepository : IRepository<Checkup, Int32>
    {
        private readonly AppointmentsDbContext dbContext;

        public CheckupRepository(AppointmentsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool DeleteById(int id)
        {
            var checkup = dbContext.Checkups.SingleOrDefault(c => c.TermId == id);
            if(checkup != null)
            {
                dbContext.Remove(checkup);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Checkup> FindAll()
        {
            return dbContext.Checkups.ToList();
        }

        public Checkup FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Checkup entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
        }

        public void SaveAll(IEnumerable<Checkup> entities)
        {
            throw new NotImplementedException();
        }
    }
}
