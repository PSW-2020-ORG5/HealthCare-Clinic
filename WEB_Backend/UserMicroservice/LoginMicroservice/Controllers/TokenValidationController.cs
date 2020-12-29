﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginMicroservice.Controllers
{
    [Produces("application/json")]
    [Route("api/validate")]
    [ApiController]
    [Authorize]
    public class TokenValidationController:ControllerBase
    {
        [HttpGet]
        public IActionResult Validate()
        {
            return Ok();
        }
    }
}
