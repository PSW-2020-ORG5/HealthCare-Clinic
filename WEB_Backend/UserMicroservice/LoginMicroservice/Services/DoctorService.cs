using LoginMicroservice.Repository;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.Repository;

namespace UserMicroservice.Services
{
    public class DoctorService
    {
        private readonly DoctorRepository repository;
        public DoctorService(UserDbContext dbContext)
        {
            this.repository = new DoctorRepository(dbContext);
        }

        public List<Doctor> GetAll()
        {
            return (List<Doctor>)repository.GetAll();
        }

        public List<Doctor> GetBySpecialty(int type)
        {
            return repository.GetDoctorsBySpecialty(type);
        }
    }
}
