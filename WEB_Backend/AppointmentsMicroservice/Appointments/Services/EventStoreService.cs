using Appointments.Model;
using Appointments.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointments.Services
{
    public class EventStoreService
    {
        private readonly EventRepository repository;
        public StatisticEventsDTO eventsDTO = new StatisticEventsDTO();
        public int sessionsCount = 0;
        public Dictionary<String, List<int>> map {get;set;}

        public EventStoreService()
        {
            this.map = new Dictionary<string, List<int>>();
        }
        public EventStoreService(AppointmentsDbContext dbContext)
        {
            this.repository = new EventRepository(dbContext);
            this.map = new Dictionary<string, List<int>>();
            InitMap();
            this.sessionsCount = map.Keys.Count;
            CalculateSucess();
            GetMinMaxAvgSteps();
            AvgForEveryStep();
            CalculateNoTermFoundSucess();
        }

        public List<SchedulingEvent> GetAll()
        {
            return (List<SchedulingEvent>)this.repository.FindAll();
        }

        public void AddEvent(SchedulingEvent schedulingEvent)
        {
            repository.Save(schedulingEvent);
        }

        public List<String> GetAllSessions()
        {
            return repository.GetAllSessionIds();
        }



        public void GetMinMaxAvgSteps()
        {   
            var allSteps = GetStepsBySucessSession();
            eventsDTO.Avg = Math.Round(allSteps.Average(),2);
            eventsDTO.Max = allSteps.Max();
            eventsDTO.Min = allSteps.Min();
            eventsDTO.AllSesions = sessionsCount;
        }

        public int InitMap()
        {
            foreach (String id in GetAllSessions())
            {
                var sesionSteps = GetAll().Where(e => e.SessionId.Equals(id));
                int sucess = sesionSteps.Where(c => c.Type == SchedulingEventType.success).Count();
                int step1 = sesionSteps.Where(c => c.Type == SchedulingEventType.step1).Count();
                int step2 = sesionSteps.Where(c => c.Type == SchedulingEventType.step2).Count();
                int step3 = sesionSteps.Where(c => c.Type == SchedulingEventType.step3).Count();
                int step4 = sesionSteps.Where(c => c.Type == SchedulingEventType.step4).Count();
                int noTerm = sesionSteps.Where(c => c.Type == SchedulingEventType.noTerm).Count();
                var list = new List<int>();
                list.Add(step1);
                list.Add(step2);
                list.Add(step3);
                list.Add(step4);
                list.Add(sucess);
                list.Add(noTerm);
                map.Add(id, list);

            }
            return 1;
        }

        public void CalculateSucess()
        {
            int ret = 0;
            foreach(String id in map.Keys)
            {
                if (map[id][4] > 0)
                {
                    ret = ret + 1;
                }
            }
            this.eventsDTO.Success = ret;
        }

        public void AvgForEveryStep()
        {
            var list = new List<double>();
            var listS = new List<double>();
            var listNS = new List<double>();
            for(int i = 0; i < 4; i++)
            {
                list.Add(0);
                listS.Add(0);
                listNS.Add(0);

            }
            foreach (String id in map.Keys)
            {

                var listT = map[id];
                Console.WriteLine(id);
                Console.WriteLine(listT[4]);
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine(listT[i]);
                    list[i] = list[i]+ listT[i];
                    if (listT[4] > 0) {
                        listS[i] = listS[i]+ listT[i];
                    }
                    else
                    {
                       listNS[i] = listNS[i]+ listT[i];
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                list[i] =Math.Round(list[i] / sessionsCount,2);
                listS[i] = Math.Round(listS[i] / eventsDTO.Success,2);
                listNS[i] = Math.Round(listNS[i] / (sessionsCount- eventsDTO.Success),2);
            }
            this.eventsDTO.AvgStepCount = list;
            this.eventsDTO.AvgStepCountSucess = listS;
            this.eventsDTO.AvgStepCountNotSucess = listNS;
  
        }

        public void CalculateNoTermFoundSucess()
        {
            var sucess = 0;
            var notScheduled = 0;
            foreach(String id in map.Keys)
            {
                var list = map[id];
                if (list[5] > 0  && list[4]>0)
                {
                    sucess += 1;
                }
                if (list[5] > 0 && list[4] == 0)
                {
                    notScheduled += 1;
                }

            }
            this.eventsDTO.NoTermScheduled = sucess;
            this.eventsDTO.NoTermNotScheduled = notScheduled;
        }


        public List<int> GetStepsBySucessSession()
        {
             var steps = new List<int>();
             foreach(String id in map.Keys)
             {
                var list = map[id];
                if (list[4] > 0)
                {
                    int number = list[0] + list[1] + list[2] + list[3];
                    steps.Add(number);
                }
             }
             return steps;
        }
    }
}
