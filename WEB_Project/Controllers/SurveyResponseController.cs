using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Survey;
//using ReactASPCrud.Services;
using Service.SurveyResponseServ;

namespace Health_Clinic_Web_App.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("ReactPolicy")]
    public class SurveyResponseController : ControllerBase
    {
        private readonly SurveyResponseService surveyResponseService;
        public SurveyResponseController(SurveyResponseService surveyResponseService)
        {
            this.surveyResponseService = surveyResponseService;
        }

        [HttpGet]
        public IEnumerable<SurveyResponse> Get()
        {
            return surveyResponseService.GetAllSurveyResponses();
        }
    }
}
