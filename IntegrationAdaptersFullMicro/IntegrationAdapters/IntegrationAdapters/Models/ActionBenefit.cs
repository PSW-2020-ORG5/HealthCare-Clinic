using System.ComponentModel.DataAnnotations;

namespace Health_Clinic_Integration.Models
{
    public class ActionBenefit 
    {
        public string pharmacy { get; set; }
        [Key]
        public string message { get; set; }

        public ActionBenefit()
        {
        }

        public ActionBenefit(string pharmacy, string message)
        {
            this.pharmacy = pharmacy;
            this.message = message;
        }
    }
}
