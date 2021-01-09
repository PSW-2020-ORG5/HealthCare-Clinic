using LoginMicroservice.JWTAuthentication;
using LoginMicroservice.Model;
using LoginMicroservice.Repository;
using LoginMicroservice.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginMicroservice.Controllers
{
    [Produces("application/json")]
    [Route("/api/users")]
    [ApiController]
    public class RegistredUserController : ControllerBase
    {
        private readonly RegistredUserService service;

        public RegistredUserController(UserDbContext dbContext, IJWTAuthenticationManager jWT)
        {
            this.service = new RegistredUserService(dbContext,jWT);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<RegisteredUser> result = service.GetAll();
            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDTO userDTO)
        {
            var user = service.AuthenticateUser(userDTO);
            if (user != null)
            {
                return Ok(userDTO);
            }
            return Unauthorized();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(service.GetById(id));
        } 
    }
}
