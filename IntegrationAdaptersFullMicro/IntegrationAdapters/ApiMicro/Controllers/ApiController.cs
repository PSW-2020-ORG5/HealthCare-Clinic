using System.Collections.Generic;
using APIGateway.EmailService;
using IntegrationAdapters.Models;
using IntegrationAdapters.Repositories.DbContexts;
using IntegrationAdapters.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ApiKeyService apiKeyService;

        public ApiController(MyApiContext context)
        {
            this.apiKeyService = new ApiKeyService(context);
        }


        [HttpGet] // GET /api/api
        [EnableCors("Policy")]
        public IActionResult Get()
        {
            List<Api> result = apiKeyService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id?}")] // get api/api/
        public IActionResult Get(string id)
        {
            Api api = apiKeyService.GetById(id);
            if (api == null) return NotFound();

            return Ok(api);
        }

        [HttpPost("save")] // post api/api
        [Consumes("application/json")]
        public IActionResult Post(Api api)
        {
            if (api.name == "") return BadRequest();
            apiKeyService.Save(api);

            return Ok();           
        }
    }
}