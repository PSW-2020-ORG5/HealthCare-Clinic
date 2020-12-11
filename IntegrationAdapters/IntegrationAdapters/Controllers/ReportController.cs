using IntegrationAdapters.Dtos;
using IntegrationAdapters.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportService reportService;

        public ReportController()
        {
            this.reportService = new ReportService();
        }

        [HttpPost("ftp/{FileName}")]
        public IActionResult Upload(string FileName)
        {
            reportService.Upload(FileName);

            return Ok();
        }

        [HttpPost("ftp")]
        public IActionResult GenerateConsumptionReportBetweenTwoDates(PeriodDto periodDTO)
        {
            reportService.GenerateConsumptionReportBetweenTwoDates(periodDTO);

            return Ok();
        }
    }
}