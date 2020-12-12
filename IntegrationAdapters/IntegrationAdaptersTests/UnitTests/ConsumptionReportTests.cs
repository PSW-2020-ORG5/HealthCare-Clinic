﻿using IntegrationAdapters.Dtos;
using IntegrationAdapters.Services.TestServices;
using Moq;
using Shouldly;
using System.IO;
using Xunit;

namespace IntegrationAdaptersTests.UnitTests
{
    public class ConsumptionReportTests
    {
        [Fact]
        public void Upload_Consumption_Report_Successfully()
        {
            Mock<IConsumptionReport> consReport = new Mock<IConsumptionReport>();

            consReport.Setup(t => t.UploadFileToServer()).Returns(ServerCredentialsDto.GetInstance().ServerFolder + Path.DirectorySeparatorChar + "abc.txt");


            ReportServiceTest repServTest = new ReportServiceTest();
            repServTest.UploadFileAndCheckIfItExists(consReport.Object).ShouldBe(true);
        }

        [Fact]
        public void Upload_Consumption_Report_Unsuccessfully()
        {
            Mock<IConsumptionReport> consReport = new Mock<IConsumptionReport>();

            consReport.Setup(t => t.UploadFileToServer()).Returns(ServerCredentialsDto.GetInstance().ServerFolder + Path.DirectorySeparatorChar + "abcddd.txt");

            ReportServiceTest repServTest = new ReportServiceTest();
            repServTest.UploadFileAndCheckIfItExists(consReport.Object).ShouldBe(false);
        }
    }
}
