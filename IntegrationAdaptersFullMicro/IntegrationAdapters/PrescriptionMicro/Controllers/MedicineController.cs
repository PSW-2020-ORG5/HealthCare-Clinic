using IntegrationAdapters.Dtos;
using IntegrationAdapters.Services.GrpcService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {

        [HttpPost("availability")]
        public IActionResult GetAvailability(MedicineDto medDto)
        {
            ClientScheduledService clientSchedulesService = new ClientScheduledService();
            clientSchedulesService.SendMessage(medDto);

            Thread.Sleep(1000);
            List<MedAvabDto> pharmacies = ClientScheduledService.pharmacies;

            return Ok(pharmacies);
        }
    }
}
