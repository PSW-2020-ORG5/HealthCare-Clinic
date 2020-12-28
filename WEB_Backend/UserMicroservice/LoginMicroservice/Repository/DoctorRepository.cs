using LoginMicroservice.Repository;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.Repository
{
    public class DoctorRepository
    {
        private readonly UserDbContext dbContext;

        public DoctorRepository(UserDbContext context)
        {
            this.dbContext = context;
        }

        public List<Doctor> GetDoctorsBySpecialty(int type)
        {
            SpecialtyType specialtyType = (SpecialtyType)type;
            return this.dbContext.Doctors.Where(d => d.SpecialtyType == specialtyType).ToList<Doctor>();
        }

        public List<Doctor> GetAll()
        {
            return this.dbContext.Doctors.ToList();
        }
    }
}
