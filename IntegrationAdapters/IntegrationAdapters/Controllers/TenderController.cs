using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationAdapters.Dtos;
using IntegrationAdapters.Models;
using IntegrationAdapters.Repositories.DbContexts;
using IntegrationAdapters.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private readonly TenderService tenderService;

        public TenderController(MyDbContext context)
        {
            this.tenderService = new TenderService(context);
        }

        [HttpPost("publish")]
        public IActionResult Publish(TenderDto tenderDto)
        {
            Console.WriteLine("we are here");
            tenderService.PublishTender(tenderDto);
            return Ok();
        }

        [HttpPost("offer")]
        public IActionResult Publish(TenderOfferDto tenderOfferDto)
        {
            Console.WriteLine("entered this00000000000000000000000000000000000000000000");
            tenderService.SendOffer(tenderOfferDto);
   

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Tender> result = tenderService.GetAll();
            return Ok(result);
        }

        [HttpGet("offers")]
        public IActionResult GetOffers()
        {
            return Ok(tenderService.GetAllOffers());
        }

        [HttpGet("{id?}")]
        public IActionResult Get(string id)
        {
            Tender tender = tenderService.GetById(id);
            if (tender == null) return NotFound();

            return Ok(tender);
        }
    }
}