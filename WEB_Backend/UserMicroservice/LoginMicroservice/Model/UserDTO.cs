using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginMicroservice.Model
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string Token { get; set; }
        
        public UserRole Role { get; set; }
    }
}
