using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginMicroservice.Repository
{
    interface IRegistredUsers
    {
        public IEnumerable<RegisteredUser> GetAll();
    }
}
