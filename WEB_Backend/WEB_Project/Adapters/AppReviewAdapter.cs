using Health_Clinic_Web_App.DTO;
using Model.Survey;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Health_Clinic_Web_App.Adapters
{
    public class AppReviewAdapter
    {
        public static AppReview DtoToAppReview(AppReviewDTO dto)
        {
            
            AppReview appReview = new AppReview();
            appReview.Anonymous = dto.anonymous;
            appReview.Publishable = dto.publishable;
            appReview.ReviewText = dto.reviewText;
            appReview.Published = dto.published;
            appReview.PatientId = 123123123;   // ubaciti nakon implementacije identifikacije korisnika
            return appReview;
        }

        public static AppReviewDTO AppReviewToDto(AppReview appReview)
        {
            AppReviewDTO dto = new AppReviewDTO();
            dto.anonymous = appReview.Anonymous;
            dto.publishable = appReview.Publishable;
            dto.reviewText = appReview.ReviewText;
            dto.published = appReview.Published;
            dto.appReviewId = appReview.AppReviewId;
            return dto;
        }

    }
}
