using IntegrationAdapters.Dtos;
using IntegrationAdapters.Services.GrpcService;
using System;
using System.Collections.Generic;
using System.Text;
using Shouldly;
using Xunit;
using System.Threading;

namespace IntegrationAdaptersTests.IntegrationTests
{
    public class GrpcTests 
    {
        

        // uncomment when your client grpc server is running 
        /*
        [Fact]
        public void GetAvailableMedicine()
        {
            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if(env == "Production")
            {
                return;
            }

            MedicineDto med = new MedicineDto("Brufen", 2);
            ClientScheduledService clientSchedulesService = new ClientScheduledService();
            clientSchedulesService.SendMessage(med);

            Thread.Sleep(1000);
            
            bool flag = false;

            foreach(var pharm in ClientScheduledService.pharmacies)
            {
                if (pharm.IsAvab)
                {
                    flag = true;
                    break;
                }
            }

            flag.ShouldBe(true);
        }

        // uncomment when your client grpc server is running
        [Fact]
        public void GetUnAvailableMedicine()
        {
            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (env == "Production")
            {
                return;
            }

            MedicineDto med = new MedicineDto("Brufen", 500);
            ClientScheduledService clientSchedulesService = new ClientScheduledService();
            clientSchedulesService.SendMessage(med);

            Thread.Sleep(1000);
            bool flag = false;

            foreach (var pharm in ClientScheduledService.pharmacies)
            {
                if (pharm.IsAvab)
                {
                    flag = true;
                    break;
                }
            }

            flag.ShouldBe(false);
        }*/
        
    }
}
