using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationAdapters.Models;
using IntegrationAdapters.Repositories.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly MyDbContext dbContext;

        public ApiController(MyDbContext context)
        {
            this.dbContext = context;
        }
        [HttpGet] // GET /api/api
        public IActionResult Get()
        {
            List<Api> result = new List<Api>();
            dbContext.Apis.ToList().ForEach(api => result.Add(api));
            return Ok(result);
        }

        [HttpGet("{id?}")] // get api/api/
        public IActionResult Get(string id)
        {
            List<Api> result = new List<Api>();
            dbContext.Apis.ToList().ForEach(api => result.Add(api));
            foreach(var api in result)
            {
                if (api.name == id)
                    return Ok(api);
            }

            return NotFound();
        }

        [HttpPost("save")] // post api/api
        [Consumes("application/json")]
        public IActionResult Post(Api api)
        {
            if (api.name == "") return BadRequest();
         
            dbContext.Apis.Add(api);
            dbContext.SaveChanges();
            return Ok();
            
        }

    }
}