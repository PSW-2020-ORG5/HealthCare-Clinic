using Health_Clinic_Integration.Models;
using IntegrationAdapters.Dtos;
using IntegrationAdapters.Models;
using System.Collections.Generic;

namespace IntegrationAdapters.Services.TestServices
{
    public interface IMyDbContext
    {
        List<Api> GetApis();
        List<ActionBenefit> GetActionsBenefits();
        List<Tender> GetTenders();
        List<TenderOfferDto> GetTenderOffers();
    }
}
