
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
        private string USER_HOST = Environment.GetEnvironmentVariable("USER_HOST") ?? "localhost";
        [HttpGet]
        public IActionResult GetAll()
        {
            string token = Request.Headers["Authorization"];
            string tokenSplit;
            try
            {
                tokenSplit = token.Split(" ")[1];
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            var validate = CheckValidation(tokenSplit);
            if (!validate)
            {
                return Unauthorized();
            }
            else
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                var client = new HttpClient(clientHandler);
                var response = client.GetAsync($"https://{USER_HOST}:44395/api/users");
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
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);
            var response = client.PostAsync($"https://{USER_HOST}:44395/api/users/login", new StringContent(JsonConvert.SerializeObject(userDTO), Encoding.UTF8, "application/json"));
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
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = client.GetAsync($"https://{USER_HOST}:44395/api/validate");
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

        [HttpGet("docSpec/{type}")]
        public IActionResult GetBySpecialty(int type)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);
            var response = client.GetAsync($"https://{USER_HOST}:44395/api/doctors/spec/" + type);
            var content = response.Result.Content.ReadAsStringAsync().Result;
            return Ok(content);
        }
    }
}
