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
        private readonly MyDbContext dbContext;

        public AppReviewController(AppReviewService appReviewService, MyDbContext dbContext)
        {
            this.appReviewService = appReviewService;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<AppReview> Get()
        {
            return appReviewService.GetAllAppReviews();
        }

        [HttpPost]
        public void Post([FromBody] AppReviewDTO appreviewfeedback)
        {
            Console.WriteLine("test");
            AppReview appReview = AppReviewAdapter.DtoToAppReview(appreviewfeedback);
            appReviewService.AddAppReview(appReview);
        }

    }
}
