using LoginMicroservice.Model;
using LoginMicroservice.Repository;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginMicroservice.Services
{
    public class RegistredUserService
    {
        private readonly RegistredUserRepository repository;

        public RegistredUserService(UserDbContext dbContext)
        {
            this.repository = new RegistredUserRepository(dbContext);
        }

        public List<RegisteredUser> GetAll()
        {
            return (List<RegisteredUser>)repository.GetAll();
        }

        public RegisteredUser AuthenticateUser(UserDTO user)
        { 
            List<RegisteredUser> allUsers = GetAll();
            foreach(RegisteredUser reg in allUsers)
            {
                if(reg.Username.Equals(user.Username) && reg.Password.Equals(user.Password))
                {
                    return reg;
                }
            }
            return null;
        }
        public RegisteredUser GetById(int id)
        {
            return repository.GetById(id);
        }
    }
}
