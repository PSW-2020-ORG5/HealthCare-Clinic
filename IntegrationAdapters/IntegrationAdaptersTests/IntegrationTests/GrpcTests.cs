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
        /*
        // uncomment when your client grpc server is running 
        [Fact]
        public void GetAvailableMedicine()
        {
            MedicineDto med = new MedicineDto("Brufen", 2);
            ClientScheduledService clientSchedulesService = new ClientScheduledService();
            clientSchedulesService.SendMessage(med);

            Thread.Sleep(1000);
            ClientScheduledService.flag.ShouldBe(true);
        }

        // uncomment when your client grpc server is running
        [Fact]
        public void GetUnAvailableMedicine()
        {
            MedicineDto med = new MedicineDto("Brufen", 500);
            ClientScheduledService clientSchedulesService = new ClientScheduledService();
            clientSchedulesService.SendMessage(med);

            Thread.Sleep(1000);
            ClientScheduledService.flag.ShouldBe(false);
        }
        */
    }
}
