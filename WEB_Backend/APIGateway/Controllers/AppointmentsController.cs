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
    [Route("/appointments")]
    [ApiController]
    public class AppointmentsController: ControllerBase
    {
        private string USER_HOST = Environment.GetEnvironmentVariable("USER_HOST") ?? "localhost";
        [HttpPost("freeCheckups")]
        public IActionResult GetFreeCheckupsForDoctor([FromBody] JObject dto)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);
            var response = client.PostAsync($"https://{USER_HOST}:44397/api/checkups/freeCheckups", new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json"));
            var content = response.Result.Content.ReadAsStringAsync().Result;
            return Ok(content);
        }

        [HttpGet("patientCheckups/{id}")]
        public IActionResult GetPatientCheckups(int id)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);
            var response = client.GetAsync($"https://{USER_HOST}:44397/api/checkups/patientCheckups/"+id);
            var content = response.Result.Content.ReadAsStringAsync().Result;
            return Ok(content);
        }

        [HttpPost("schedule")]
        public IActionResult ScheduleCheckup([FromBody] JObject dto)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);
            var response = client.PostAsync($"https://{USER_HOST}:44397/api/checkups/schedule", new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json"));
            var content = response.Result.Content.ReadAsStringAsync().Result;
            return Ok(content);
        }
        [HttpDelete("cancel/{id}")]
        public IActionResult DeleteById(int id)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);
            var response = client.DeleteAsync($"https://{USER_HOST}:44397/api/checkups/cancel/" + id);
            var content = response.Result.Content.ReadAsStringAsync().Result;
            return Ok(content);
        }
    }
}
