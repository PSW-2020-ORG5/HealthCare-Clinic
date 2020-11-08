﻿using Health_Clinic_Web_App.Model.DatabaseContext;
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

        // get all feedbacks(appreviews) from patient
        public List<AppReview> GetAllAppReviews()
        {
            List<AppReview> appReviews = new List<AppReview>();
            appReviews = (List<AppReview>)appRepo.FindAll();

            return appReviews;
        }

        // get all published feedbacks(appreviews) from patient
        public List<AppReview> GetAllAppPublishedReviews()
        {
            List<AppReview> appReviews = new List<AppReview>();
            appReviews = (List<AppReview>)appRepo.FindAll();
            List<AppReview> result = new List<AppReview>();

            foreach (AppReview a in appReviews) {
                if (a.Publishable==true) {

                    result.Add(a);
                }
            }

            return result;
        }


        //save all list of feedbacks
        public void AddAppReviews(List<AppReview> appReviewsToSave)
        {
            appRepo.SaveAll(appReviewsToSave);
        }

        //save one feedback
        public void AddAppReview(AppReview appReviewToSave)
        {
            appRepo.Save(appReviewToSave);
        }
    }
}
