using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Diagnostics;
using Microsoft.AspNetCore.Cors;
using System.Text;
using IntegrationAdapters.Dtos;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedSpecController : ControllerBase
    {

        [HttpGet("spec/{name}")]
        public IActionResult GetSpecification(String name)
        {

            if (System.IO.File.Exists("MedSpec" + Path.DirectorySeparatorChar + name + ".txt"))
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

        [HttpPost("getspechttp")]
        [EnableCors("Policy")]
        public void GetFileViaHttp(FileDto fileDto)
        {
            byte[] data = Convert.FromBase64String(fileDto.Bytes);
            string decodedString = Encoding.UTF8.GetString(data);

            string path = "MedSpec" + Path.DirectorySeparatorChar + fileDto.Title + ".txt";

            // Create the file, or overwrite if the file exists.
            using (FileStream fs = System.IO.File.Create(path, 1024))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(decodedString);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
        }
    }
}
