using Health_Clinic_Web_App.Adapters;
using Health_Clinic_Web_App.DTO;
using Health_Clinic_Web_App.Repository.DBContext;
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
        private readonly ProjectDBContext context;

        public AppReviewService(ProjectDBContext context)
        {
            this.appRepo = new AppReviewDataBaseRepository(context);
            this.context = context;
        }

        // Get all feedbacks (appreviews) from patient
        public List<AppReviewDTO> GetAllAppReviews()
        {
            List<AppReview> appReviews = new List<AppReview>();
            List<AppReviewDTO> appReviewDTOs = new List<AppReviewDTO>();

            appReviews = (List<AppReview>)appRepo.FindAll();
            appReviews.ForEach(appReview => appReviewDTOs.Add(AppReviewAdapter.AppReviewToDto(appReview)));

            return appReviewDTOs;
        }


        // Get all published feedbacks (appreviews) from patient
        public List<AppReviewDTO> GetAllPublishedAppReviews()
        {
            List<AppReviewDTO> appReviewDTOs = new List<AppReviewDTO>();
            List<AppReview> appReviews = new List<AppReview>();

            appReviews = (List<AppReview>)appRepo.FindAll();

            foreach (AppReview a in appReviews) {
                if (a.Published==true) {
                    appReviewDTOs.Add(AppReviewAdapter.AppReviewToDto(a));
                }
            }
            return appReviewDTOs;
        }

        // Save feedback
        public void AddAppReview(AppReviewDTO appReviewDTO)
        {
            AppReview appReview = AppReviewAdapter.DtoToAppReview(appReviewDTO);
            appRepo.Save(AppReviewAdapter.DtoToAppReview(appReviewDTO));
        }
    }
}
