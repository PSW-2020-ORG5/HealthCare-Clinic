using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginMicroservice.Repository
{
    public class RegistredUserRepository: IRegistredUsers
    {
        private readonly UserDbContext dbContext;

        public RegistredUserRepository(UserDbContext context)
        {
            this.dbContext = context;
        }

        public IEnumerable<RegisteredUser> GetAll()
        {
            return dbContext.RegisteredUsers.ToList();
        }

        public RegisteredUser GetById(int id)
        {
            return dbContext.RegisteredUsers.Find(id);
        }
    }
}
