using IntegrationAdapters.Dtos;
using IntegrationAdapters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Services.TestServices
{
    public class TenderServiceTest
    {
        public int GetNumberOfTenders(IMyDbContext myDbContext)
        {
            return myDbContext.GetTenders().Count;
        }

        public int SaveTender(IMyDbContext myDbContext, Tender tender)
        {
            if(tender.id != "")
            {
                myDbContext.GetTenders().Add(tender);
            }

            return myDbContext.GetTenders().Count;
        }

        public static void RemoveTender(IMyDbContext myDbContext, string tender)
        {
            foreach(var tend in myDbContext.GetTenders())
            {
                if(tender == tend.id)
                {
                    myDbContext.GetTenders().Remove(tend);
                    break;
                }
            }

        }

        public int GetNumberOfTenderOffers(IMyDbContext myDbContext)
        {
            return myDbContext.GetTenderOffers().Count;
        }

        public int SaveTenderOffer(IMyDbContext myDbContext, TenderOfferDto tenderOffer)
        {
            if(tenderOffer.Id != "")
            {
                myDbContext.GetTenderOffers().Add(tenderOffer);
            }

            return myDbContext.GetTenderOffers().Count;
        }
    }
}
