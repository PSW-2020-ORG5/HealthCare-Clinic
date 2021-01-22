using Appointments.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointments.Repository
{
    public class EventRepository : IRepository<SchedulingEvent, String>
    {

        private readonly AppointmentsDbContext dbContext;

        public EventRepository (AppointmentsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SchedulingEvent> FindAll()
        {
            return dbContext.Events.ToList();
        }

        public SchedulingEvent FindById(string id)
        {
            throw new NotImplementedException();
        }

        public void Save(SchedulingEvent entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
        }

        public void SaveAll(IEnumerable<SchedulingEvent> entities)
        {
            throw new NotImplementedException();
        }

        public List<String> GetAllSessionIds()
        {
            return (List<string>)dbContext.Events.Select(e => e.SessionId).Distinct().ToList();
        }
    }
}
