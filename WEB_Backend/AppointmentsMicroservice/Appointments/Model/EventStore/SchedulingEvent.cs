using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointments.Model
{
    public class SchedulingEvent
    {
        public int Id { get; set; }
        public String SessionId { get; set; }
        public SchedulingEventType Type { get; set; }
    }
}
