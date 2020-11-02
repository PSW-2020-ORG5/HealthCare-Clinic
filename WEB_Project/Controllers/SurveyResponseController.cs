using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Health_Clinic_Web_App.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Survey;
//using ReactASPCrud.Services;
using Service.SurveyResponseServ;

namespace Health_Clinic_Web_App.Controllers
{
    [Produces("application/json")]
    [Route("surveys")]
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

        [HttpPost]
        public void Post([FromBody] SurveyResponseDTO surveyinfo)
        {
            System.Diagnostics.Debug.WriteLine("SURVEYINFO INFO:  " +surveyinfo.Quality + "" + surveyinfo.Security + "" + surveyinfo.Kindness + "" + surveyinfo.Professionalism + "" + surveyinfo.Comment + "" + surveyinfo.Anonymous + "" + surveyinfo.Publishable + "**********************************");
            SurveyResponse surveyResponse = new SurveyResponse(surveyinfo.Quality, surveyinfo.Security, surveyinfo.Kindness, surveyinfo.Professionalism, surveyinfo.Comment, surveyinfo.Anonymous, surveyinfo.Publishable);
            surveyResponseService.AddSurveyResponse(surveyResponse);
        }


    }
}
