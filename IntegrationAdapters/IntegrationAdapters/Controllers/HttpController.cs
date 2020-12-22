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
        public IActionResult GetEnvironmentVariable()
        {
            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            return Ok(env);
        }

        [HttpGet("httpfile/{name}")]
        public async Task<IActionResult> SendFileViaHttp(String name)
        {
            await HttpService.SendPostRequest2(name);

            return Ok();
        }
    }
}
