using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Api1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        public ClaimsController()
        {
                
        }

        [Authorize]
        [Route("base")]
        [HttpGet]
        public string GetBase()
        {
            return "Hello from Api";
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

        [Route("public")]
        [HttpGet]
        public bool GetUnauthorized()
        {
            return true;
        }
    }
}