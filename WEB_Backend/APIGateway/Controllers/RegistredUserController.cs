
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LoginMicroservice.Controllers
{
    [Route("/users")]
    [ApiController]
    public class RegistredUserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            string token = Request.Headers["Authorization"];
            string tokenS = token.Split(" ")[1];
            var validate = CheckValidation(tokenS);
            if (!validate)
            {
                return Unauthorized();
            }
            else
            {
                var client = new HttpClient();
                var response = client.GetAsync("https://localhost:44395/api/users");
                var content = response.Result.Content.ReadAsStringAsync().Result;
                switch (response.Result.StatusCode.ToString())
                {
                    case "OK":
                        return Ok(content);
                    case "Unauthorized":
                        return Unauthorized();
                    default:
                        return BadRequest();
                }
            }
      
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] JObject userDTO)
        {
            var client = new HttpClient();
            var response = client.PostAsync("https://localhost:44395/api/users/login", new StringContent(JsonConvert.SerializeObject(userDTO), Encoding.UTF8, "application/json"));
            var content = response.Result.Content.ReadAsStringAsync().Result;
            switch (response.Result.StatusCode.ToString())
            {
                case "OK":
                    return Ok(content);
                case "Unauthorized":
                    return Unauthorized();
                default:
                    return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        } 

        public bool CheckValidation(string token)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = client.GetAsync("https://localhost:44395/api/validate");
            if (response.Result.StatusCode.ToString().Equals("Unauthorized"))
            {
                return false;
            }
            if (response.Result.StatusCode.ToString().Equals("OK"))
            {
                return true;
            }
            return false;
        }
    }
}
