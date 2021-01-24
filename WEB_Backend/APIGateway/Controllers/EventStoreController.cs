using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIGateway.Controllers
{
    [Route("/events")]
    [ApiController]
    public class EventStorecController : ControllerBase

    {
        private string USER_HOST = Environment.GetEnvironmentVariable("USER_HOST") ?? "localhost";
        [HttpGet]
        public IActionResult GetStatisticDTO()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            var client = new HttpClient(clientHandler);
            var response = client.GetAsync($"https://{USER_HOST}:44397/api/events");
            var content = response.Result.Content.ReadAsStringAsync().Result;
            return Ok(content);
        }
    }
}
