using LoginMicroservice.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.Services;

namespace UserMicroservice.Controllers
{
    [Produces("application/json")]
    [Route("doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService service;

        public DoctorController(UserDbContext dbContext)
        {
            this.service = new DoctorService(dbContext);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = service.GetAll();
            return Ok(result);
        }

        [HttpGet("spec/{type}")]
        public IActionResult GetBySpecialty(int type)
        {
            var result = service.GetBySpecialty(type);
            return Ok(result);
        }
    }
}
