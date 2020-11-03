using Health_Clinic_Web_App.DTO;
using Model.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Health_Clinic_Web_App.Adapters
{
    public class AppReviewAdapter
    {
        public static AppReview DtoToAppReview(AppReviewDTO dto)
        {
            AppReview appReview = new AppReview();
            
            // appreview field value assignment

            return appReview;
        }

        public static AppReviewDTO AppReviewToDto(AppReview appReview)
        {
            AppReviewDTO dto = new AppReviewDTO();
           
            // dto field value assignement

            return dto;
        }
    }
}
