using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.Events
{
    public class LoginEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        public string Data { get; set; }

        public LoginEvent(string Data)
        {
            this.Timestamp = new DateTime();
            this.Data = Data;
        }

    }
}
