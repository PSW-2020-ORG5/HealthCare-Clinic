using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Health_Clinic_Web_App.Adapters;
using Health_Clinic_Web_App.DTO;
using Health_Clinic_Web_App.Model.DatabaseContext;
using HealthClinic.Service.AppReviewServ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Survey;

namespace Health_Clinic_Web_App.Controllers
{
    [Produces("application/json")]
    [Route("appreviewfeedback")]
    [ApiController]
    public class AppReviewController : ControllerBase
    {
        private readonly AppReviewService appReviewService;

        public AppReviewController(MyDbContext dbContext)
        {
            this.appReviewService = new AppReviewService(dbContext);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<AppReviewDTO> result = new List<AppReviewDTO>();
            appReviewService.GetAllAppReviews().ForEach(appReview => result.Add(AppReviewAdapter.AppReviewToDto(appReview)));
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AppReviewDTO appreviewfeedback)
        {
            AppReview appReview = AppReviewAdapter.DtoToAppReview(appreviewfeedback);
            appReviewService.AddAppReview(appReview);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetPublishable()
        {
            List<AppReviewDTO> result = new List<AppReviewDTO>();
            appReviewService.GetPublishableAppReviews().ForEach(appReview => result.Add(AppReviewAdapter.AppReviewToDto(appReview)));
            return Ok(result);
        }
    }
}
