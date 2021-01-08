using IntegrationAdapters.Dtos;
using IntegrationAdapters.Models;
using IntegrationAdapters.Repositories.DbContexts;
using IntegrationAdapters.Services.TestServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntegrationAdapters.Services
{
    public class TenderService
    {
        private readonly MyDbContext dbContext;

        public TenderService(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void PublishTender(TenderDto tenderDto)
        {
            try
            {
                dbContext.Tenders.Add(ObjectConversion.ConversionService.GetInstance().ConvertTenderDtoToTender(tenderDto));
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public List<Tender> GetAll()
        {
            List<Tender> result = new List<Tender>();
            dbContext.Tenders.ToList().ForEach(tender => result.Add(tender));

            return result;
        }

        public List<TenderOfferDto> GetAllOffers()
        {
            List<TenderOfferDto> result = new List<TenderOfferDto>();
            dbContext.TenderOffers.ToList().ForEach(tender => result.Add(tender));

            return result;
        }

        public Tender GetById(string id)
        {
            List<Tender> result = new List<Tender>();
            dbContext.Tenders.ToList().ForEach(tender => result.Add(tender));
            foreach (Tender tender in result)
            {
                if (tender.id == id) return tender;
            }

            return null;
        }

        public void SendOffer(TenderOfferDto tenderOfferDto)
        {
            dbContext.TenderOffers.Add(tenderOfferDto);
            dbContext.SaveChanges();
        }
    }
}
