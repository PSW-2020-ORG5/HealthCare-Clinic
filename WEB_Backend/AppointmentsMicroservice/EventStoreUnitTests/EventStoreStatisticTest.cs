using Appointments.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Shouldly;
namespace EventStoreUnitTests
{
    public class EventStoreStatisticTest
    {
        private EventStoreService service = new EventStoreService();
        public EventStoreStatisticTest()
        {
            initMap();

        }
        [Fact]
        public void CalculateSucessTest()
        {
            double result = 2;
            service.eventsDTO.Success.ShouldBeEquivalentTo(result);
        }
        [Fact]
        public void CalculateMin()
        {
            int result = 4;
            service.eventsDTO.Min.ShouldBeEquivalentTo(result);
        }
        [Fact]
        public void CalculateMax()
        {
            int result = 8;
            service.eventsDTO.Max.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public void CalculateAvg()
        {
            double result = 6;
            service.eventsDTO.Avg.ShouldBeEquivalentTo(result);
        }
        [Fact]
        public void CalculateAvgStepAllTest()
        {
            var list = new List<double>();
            list.Add(1.67);
            list.Add(1.33);
            list.Add(1.67);
            list.Add(2);
            service.eventsDTO.AvgStepCount.ShouldBeEquivalentTo(list);
        }
        [Fact]
        public void CalculateAvgStepSucessTest()
        {
            var list = new List<double>();
            list.Add(1.5);
            list.Add(1.5);
            list.Add(1.5);
            list.Add(1.5);
            service.eventsDTO.AvgStepCountSucess.ShouldBeEquivalentTo(list);
        }
        [Fact]
        public void CalculateAvgStepNotSucessTest()
        {
            var list = new List<double>();
            list.Add(2);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            service.eventsDTO.AvgStepCountNotSucess.ShouldBeEquivalentTo(list);
        }

        [Fact]
        public void NoTermScheculedTest()
        {
            service.eventsDTO.NoTermScheduled.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void NoTermNoScheculedTest()
        {
            service.eventsDTO.NoTermNotScheduled.ShouldBeEquivalentTo(1);
        }


        public void initMap()
        {
            var map = new Dictionary<String, List<int>>();
            var list1 = new List<int>();
            var list2 = new List<int>();
            var list3 = new List<int>();
            list1.Add(1);
            list1.Add(1);
            list1.Add(1);
            list1.Add(1);
            list1.Add(1);
            list1.Add(0);
            list2.Add(2);
            list2.Add(1);
            list2.Add(2);
            list2.Add(3);
            list2.Add(0);
            list2.Add(1);
            list3.Add(2);
            list3.Add(2);
            list3.Add(2);
            list3.Add(2);
            list3.Add(1);
            list3.Add(1);
            map.Add("1",list1);
            map.Add("2", list2);
            map.Add("3", list3);
            service.map = map;
            service.sessionsCount = map.Keys.Count;
            service.GetMinMaxAvgSteps();
            service.CalculateSucess();
            service.AvgForEveryStep();
            service.CalculateNoTermFoundSucess();

        }
    }
}
