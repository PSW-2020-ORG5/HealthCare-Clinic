using Health_Clinic_Web_App.Model.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Model.Survey;
using Repository.AppReviewRepo;
using Repository.SurveyResponseRepo;
using System.Collections.Generic;


namespace HealthClinic.Service.AppReviewServ
{
    public class AppReviewService
    {
        private readonly AppReviewDataBaseRepository appRepo;
        private readonly MyDbContext context;

        public AppReviewService(MyDbContext context)
        {
            this.appRepo = new AppReviewDataBaseRepository(context);
            this.context = context;
        }

        public List<AppReview> GetAllAppReviews()
        {
            List<AppReview> appReviews = new List<AppReview>();
            appReviews = (List<AppReview>)appRepo.FindAll();

            return appReviews;
        }

        public List<AppReview> GetPublishableAppReviews()
        {
            List<AppReview> appReviews = new List<AppReview>();
            appReviews = (List<AppReview>)appRepo.FindAll();
            foreach(AppReview appReview in appReviews)
            {
                if(appReview.Anonymous == true)
                {
                    appReviews.Remove(appReview);
                }
            }
            return appReviews;
        }

        public void AddAppReviews(List<AppReview> appReviewsToSave)
        {
            appRepo.SaveAll(appReviewsToSave);
        }

        public void AddAppReview(AppReview appReviewToSave)
        {
            appRepo.Save(appReviewToSave);
        }
    }
}
