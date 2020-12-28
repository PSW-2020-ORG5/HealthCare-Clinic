using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationAdapters.Dtos;
using IntegrationAdapters.Models;
using IntegrationAdapters.Repositories.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private readonly MyDbContext dbContext;

        public TenderController(MyDbContext context)
        {
            this.dbContext = context;
        }

        [HttpPost("publish")]
        public IActionResult Publish(TenderDto tenderDto)
        {
            Console.WriteLine("**********************");
            Console.WriteLine(tenderDto.Name);
            Console.WriteLine(tenderDto.ClosingDate);
            
            foreach(var med in tenderDto.RequiredMedicine)
            {
                // do something with entry.Value or entry.Key
                Console.WriteLine(med.Name + ' ' + med.Amount);
            }

            try
            {
                dbContext.Tenders.Add(ObjectConversion.ConversionService.GetInstance().ConvertTenderDtoToTender(tenderDto));
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                Console.WriteLine("zzzzzzzzzzzzzzzz");
            }

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Tender> result = new List<Tender>();
            dbContext.Tenders.ToList().ForEach(tender => result.Add(tender));

            return Ok(result);
        }

    }
}