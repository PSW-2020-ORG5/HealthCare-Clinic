using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        [HttpPost()]
        public IActionResult PostEvent([FromBody] JObject dto)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);
            var response = client.PostAsync($"https://{USER_HOST}:44397/api/events", new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json"));
            var content = response.Result.Content.ReadAsStringAsync().Result;
            return Ok(content);
        }
    }
}
