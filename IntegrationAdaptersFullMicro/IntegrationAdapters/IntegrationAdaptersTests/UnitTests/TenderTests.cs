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

        [Fact]
        public void Save_tender_fail()
        {
            Mock<IMyDbContext> mockDBContext = new Mock<IMyDbContext>();
            mockDBContext.Setup(t => t.GetTenders()).Returns(CreateTenders());

            TenderServiceTest service = new TenderServiceTest();
            service.SaveTender(mockDBContext.Object, new Tender() { id = "", Name = "tender111", ClosingDate = DateTime.Now.AddDays(2), RequiredMedicine = null }).ShouldBe(2);
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

        [Fact]
        private void RemoveTender()
        {
            Mock<IMyDbContext> mockDBContext = new Mock<IMyDbContext>();
            mockDBContext.Setup(t => t.GetTenders()).Returns(CreateTenders());

            TenderServiceTest.RemoveTender(mockDBContext.Object, "id1");
            TenderServiceTest tenderServiceTest = new TenderServiceTest();

            tenderServiceTest.GetNumberOfTenders(mockDBContext.Object).ShouldBe(1);
            
        }


        private List<TenderOfferDto> createTenderOffer()
        {
            List<MedicineOfferDto> medOffers1 = new List<MedicineOfferDto>();
            List<MedicineOfferDto> medOffers2 = new List<MedicineOfferDto>();
            List<TenderOfferDto> tenderOffers = new List<TenderOfferDto>();

            medOffers1.Add(new MedicineOfferDto("Benu", "Aspirin", 25, 250));
            medOffers1.Add(new MedicineOfferDto("Benu", "Brufen", 10, 120));
            medOffers2.Add(new MedicineOfferDto("Benu", "Bromazepan", 4, 354));
            medOffers2.Add(new MedicineOfferDto("Benu", "Hemomicin", 6, 123));

            tenderOffers.Add(new TenderOfferDto("id111", "Benu", "Endpoint1", medOffers1));
            tenderOffers.Add(new TenderOfferDto("id222", "Zegin", "Endpoint2", medOffers2));

            return tenderOffers;
        }

        [Fact]
        private void AddTenderOffer()
        {
            Mock<IMyDbContext> mockDBContext = new Mock<IMyDbContext>();
            mockDBContext.Setup(t => t.GetTenderOffers()).Returns(createTenderOffer());

            TenderServiceTest service = new TenderServiceTest();

            service.SaveTenderOffer(mockDBContext.Object, new TenderOfferDto("id111", "Benu", "Endpoint1",  null)).ShouldBe(3);
        }

        [Fact]
        private void AddTenderOfferFail()
        {
            Mock<IMyDbContext> mockDBContext = new Mock<IMyDbContext>();
            mockDBContext.Setup(t => t.GetTenderOffers()).Returns(createTenderOffer());

            TenderServiceTest service = new TenderServiceTest();

            service.SaveTenderOffer(mockDBContext.Object, new TenderOfferDto("", "Benu", "Endpoint1", null)).ShouldBe(2);
        }


    }
}
