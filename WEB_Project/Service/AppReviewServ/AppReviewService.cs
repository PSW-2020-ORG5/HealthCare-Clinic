using Model.Survey;
using Repository.AppReviewRepo;
using Repository.SurveyResponseRepo;
using System.Collections.Generic;


namespace HealthClinic.Service.AppReviewServ
{
    public class AppReviewService
    {
        public AppReviewRepositoryFactory appReviewRepositoryFactory;

        public List<AppReview> GetAllAppReviews()
        {
            AppReviewDataBaseRepository appRepo = new AppReviewDataBaseRepository();

            List<AppReview> appReviews = new List<AppReview>();
            appReviews = (List<AppReview>)appRepo.FindAll();

            return appReviews;
        }

        public void AddAppReviews(List<AppReview> appReviewsToSave)
        {
            AppReviewDataBaseRepository appRepo = new AppReviewDataBaseRepository();

            appRepo.SaveAll(appReviewsToSave);
        }

        public void AddAppReview(AppReview appReviewToSave)
        {
            AppReviewDataBaseRepository appRepo = new AppReviewDataBaseRepository();

            appRepo.Save(appReviewToSave);
        }
    }
}
