using IntegrationAdapters.Dtos;
using IntegrationAdapters.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {

        private readonly PrescriptionService prescriptionService;

        public PrescriptionController()
        {
            this.prescriptionService = new PrescriptionService();
        }

        [HttpPost("generate")]
        public IActionResult GeneratePrescription(PrescriptionDto prescriptionDto)
        {

            string fileName = prescriptionService.GeneratePrescription(prescriptionDto);

            return Ok(fileName);
        }


    }
}
