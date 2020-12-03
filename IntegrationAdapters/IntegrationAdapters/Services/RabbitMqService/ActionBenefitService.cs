using Health_Clinic_Integration.Models;
using IntegrationAdapters.Repositories.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Health_Clinic_Integration.Services.RabbitMqService
{
    public class ActionBenefitService
    {
        private readonly MyDbContext dbContext;

        public ActionBenefitService(MyDbContext context)
        {
            this.dbContext = context;
        }

        public List<ActionBenefit> GetAll()
        {
            List<ActionBenefit> result = new List<ActionBenefit>();
            dbContext.ActionsBenefits.ToList().ForEach(actionbenefit => result.Add(actionbenefit));

            return result;
        }    

        public void Save(ActionBenefit actionBenefit)
        {
            try
            {
                dbContext.ActionsBenefits.Add(actionBenefit);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
