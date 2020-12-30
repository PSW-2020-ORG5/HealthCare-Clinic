using IntegrationAdapters.Dtos;
using IntegrationAdapters.Models;
using IntegrationAdapters.Services;
using IntegrationAdapters.Services.TestServices;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntegrationAdaptersTests.UnitTests
{
    public class TenderTests
    {
        [Fact]
        public void Find_all_tenders()
        {
            Mock<IMyDbContext> mockDBContext = new Mock<IMyDbContext>();
            mockDBContext.Setup(t => t.GetTenders()).Returns(CreateTenders());

            TenderServiceTest service = new TenderServiceTest();
            service.GetNumberOfTenders(mockDBContext.Object).ShouldBe(2);
        }

        [Fact]
        public void Save_tender()
        {
            Mock<IMyDbContext> mockDBContext = new Mock<IMyDbContext>();
            mockDBContext.Setup(t => t.GetTenders()).Returns(CreateTenders());

            TenderServiceTest service = new TenderServiceTest();
            service.SaveTender(mockDBContext.Object, new Tender() { id = "id3", Name = "tender3", ClosingDate = DateTime.Now.AddDays(2), RequiredMedicine = null }).ShouldBe(3);
        }

        private List<Tender> CreateTenders()
        {
            List<Tender> tenders = new List<Tender>();
            List<MedicineDto> medicines1 = new List<MedicineDto>();
            medicines1.Add(new MedicineDto("Aspirin", 5));
            medicines1.Add(new MedicineDto("Brufen", 7));
            List<MedicineDto> medicines2 = new List<MedicineDto>();
            medicines2.Add(new MedicineDto("Hemomicin", 2));
            medicines2.Add(new MedicineDto("Brufen", 10));
            Tender tender1 = new Tender() { id = "id1", Name = "tender1", ClosingDate = DateTime.Now, RequiredMedicine = medicines1 };
            Tender tender2 = new Tender() { id = "id2", Name = "tender2", ClosingDate = DateTime.Now.AddDays(1), RequiredMedicine = medicines2 };
            tenders.Add(tender1);
            tenders.Add(tender2);

            return tenders;
        }
    }
}
