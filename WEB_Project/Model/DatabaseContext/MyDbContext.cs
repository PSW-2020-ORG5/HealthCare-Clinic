﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Survey;

namespace Health_Clinic_Web_App.Model.DatabaseContext
{
    public class MyDbContext : DbContext
    {
        public DbSet<AppReview> AppReviews { get; set; }
        
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    }
}
