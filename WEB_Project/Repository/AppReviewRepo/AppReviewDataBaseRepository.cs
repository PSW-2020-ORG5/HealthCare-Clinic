using Health_Clinic_Web_App.Model.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Model.Survey;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.AppReviewRepo
{
    public class AppReviewDataBaseRepository : AppReviewRepository
    {
        private readonly MyDbContext dbContext;

        public AppReviewDataBaseRepository(MyDbContext context)
        {
            this.dbContext = context;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(AppReview entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int identificator)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppReview> FindAll()
        {
            return dbContext.AppReviews.ToList();
        }

        public IEnumerable<AppReview> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public AppReview FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(AppReview entity)
        {
            dbContext.AppReviews.Add(entity);
            dbContext.SaveChanges();
        }

        public void SaveAll(IEnumerable<AppReview> entities)
        {
            throw new NotImplementedException();
        }
    }
}