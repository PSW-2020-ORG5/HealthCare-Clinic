using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointments.Model
{
    public class StatisticEventsDTO
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public double Avg { get; set; }
        public double Success { get; set; }

        public int AllSesions { get; set; }

        public List<double> AvgStepCount { get; set; }
        public List<double> AvgStepCountSucess { get; set; }
        public List<double> AvgStepCountNotSucess { get; set; }

        public int NoTermScheduled { get; set; }
        public int NoTermNotScheduled { get; set; }

    }
}
