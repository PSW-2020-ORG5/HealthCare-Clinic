using IntegrationAdapters.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpController : ControllerBase
    {

        [HttpGet("env")]
        public IActionResult GetVariable()
        {
            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            return Ok(env);
        }

        [HttpGet("httpfile/{name}/{port}")]
        public async Task<IActionResult> SendFileViaHttp(String name, String port)
        {
            Console.WriteLine("USAOO U HTTP CONTROLLER****************************************");
            await HttpService.SendPostRequest2(name, port);

            return Ok();
        }
    }
}
