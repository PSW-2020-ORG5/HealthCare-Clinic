using LoginMicroservice.JWTAuthentication;
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
        private readonly IJWTAuthenticationManager jWTAuthenticationManager;

        public RegistredUserService(UserDbContext dbContext, IJWTAuthenticationManager jWT)
        {
            this.repository = new RegistredUserRepository(dbContext);
            this.jWTAuthenticationManager = jWT;
        }

        public List<RegisteredUser> GetAll()
        {
            return (List<RegisteredUser>)repository.GetAll();
        }

        public RegisteredUser FindUser(UserDTO user)
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

        public UserDTO AuthenticateUser(UserDTO userDTO)
        {
            var user = FindUser(userDTO);
            if (user != null)
            {
                var token = jWTAuthenticationManager.Authenticate(user.Username, user.Password);
                userDTO.Token = token;
                userDTO.Role = user.Role;
                userDTO.Id = user.Id;
                repository.SaveEvent(userDTO.Username);
                return userDTO;
            }
            return null;
        }
        public RegisteredUser GetById(int id)
        {
            return repository.GetById(id);
        }
    }
}
