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
    [Route("reviews")]
    [ApiController]
    public class AppReviewController : ControllerBase
    {
        private readonly AppReviewService appReviewService;

        public AppReviewController(MyDbContext dbContext)
        {
            this.appReviewService = new AppReviewService(dbContext);
        }

        [HttpGet] // GET: reviews
        public IActionResult GetAll()
        {
            List<AppReviewDTO> result = appReviewService.GetAllAppReviews();
            return Ok(result);
        }

        [HttpPost] // POST: reviews
        public IActionResult Post([FromBody] AppReviewDTO appReviewDTO)
        {
            appReviewService.AddAppReview(appReviewDTO);
            return Ok();
        }

        //TODO: [HttpPut({appReviewId})] metoda koja ce menjati published sa false na true
        //
        //

        [HttpGet("published")] // GET: reviews/published
        public IActionResult GetAllPublished() // obican user vidi samo one gde published == true
        {
            List<AppReviewDTO> result = appReviewService.GetAllPublishedAppReviews();
            return Ok(result);
        }


    }
}
