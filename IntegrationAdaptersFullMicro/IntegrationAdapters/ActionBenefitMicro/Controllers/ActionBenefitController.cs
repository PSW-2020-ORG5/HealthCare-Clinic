using Health_Clinic_Integration.Models;
using Health_Clinic_Integration.Services.RabbitMqService;
using IntegrationAdapters.Repositories.DbContexts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionBenefitController : ControllerBase
    {
        private readonly ActionBenefitService actionBenefitService;

        public ActionBenefitController(MyActionBenefitContext dbContext)
        {
            this.actionBenefitService = new ActionBenefitService(dbContext);
        }

        [HttpGet] // GET /api/actionbenefit
        public IActionResult Get()
        {
            List<ActionBenefit> result = actionBenefitService.GetAll();
            return Ok(result);
        }
    }
}
