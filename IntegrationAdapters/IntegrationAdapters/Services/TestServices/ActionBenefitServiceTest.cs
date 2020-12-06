using Health_Clinic_Integration.Models;
using System.Collections.Generic;
using System.Linq;

namespace IntegrationAdapters.Services.TestServices
{
    public class ActionBenefitServiceTest
    {
        public int GetNumberOfActionBenefits(IMyDbContext myDbContext)
        {
            return myDbContext.GetActionsBenefits().Count();
        }

        public int SaveActionBenefit(IMyDbContext myDbContext, ActionBenefit actionBenefit)
        {
            if (actionBenefit.message == "") return myDbContext.GetActionsBenefits().Count;
            myDbContext.GetActionsBenefits().Add(actionBenefit);

            return myDbContext.GetActionsBenefits().Count();
        }

        public string GetActionBenefit(IMyDbContext myDbContext, string pharmacy)
        {
            List<ActionBenefit> retList = myDbContext.GetActionsBenefits();
            foreach (var action in retList)
            {
                if (action.pharmacy == pharmacy) return action.message;
            }

            return null;
        }

        public string GetLastActionBenefit(IMyDbContext myDbContext)
        {
            List<ActionBenefit> retList = myDbContext.GetActionsBenefits();
            int count = myDbContext.GetActionsBenefits().Count();

            if (count != 0) return retList[count - 1].message;

            return null;
        }
    }
}
