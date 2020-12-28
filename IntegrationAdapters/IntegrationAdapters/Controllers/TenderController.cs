using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationAdapters.Dtos;
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

            dbContext.Tenders.Add(ObjectConversion.ConversionService.GetInstance().ConvertTenderDtoToTender(tenderDto));
            dbContext.SaveChanges();

            return Ok();
        }

    }
}