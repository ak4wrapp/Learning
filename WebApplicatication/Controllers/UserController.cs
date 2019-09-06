using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicatication.Filters;

namespace WebApplicatication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        [ValidateModelAttribute(IsTest = true)]
        public ActionResult<string> AddPlayer([FromBody] string name)
        {
            return Ok("Added");
        }

        [HttpGet]
        [ValidateModelAttribute(IsTest = true)]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Amandeep Kirar", "Renu Sihan" };
        }
    }
}