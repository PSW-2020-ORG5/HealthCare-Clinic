using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedSpecController : ControllerBase
    {

        [HttpGet("spec/{name}")]
        public IActionResult GetSpecification(String name)
        {

            if (System.IO.File.Exists("MedSpec\\" + name + ".txt"))
            {
                new Process
                {
                    StartInfo = new ProcessStartInfo("MedSpec\\" + name + ".txt")
                    {
                        UseShellExecute = true
                    }
                }.Start();

                return StatusCode(200);
            }

            return StatusCode(204);

        }






    }
}
