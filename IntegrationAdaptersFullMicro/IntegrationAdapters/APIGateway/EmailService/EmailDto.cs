using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.EmailService
{
    public class EmailDto
    {
        public string email { get; set; }

        public EmailDto(string email)
        {
            this.email = email;
        }

        public EmailDto()
        {
            
        }


    }

}
