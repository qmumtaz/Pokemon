using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Pokemon.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/Values")]
    [ApiController]
    public class ValuesV1Controller : ControllerBase
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value one from api version", "One" };
        }
    }

    [ApiVersion("2.0")]
    [Route("api/v{v:apiVersion}/Values")]
    [ApiController]
    public class ValuesV2Controller : ControllerBase
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value two from the api version", "two" };
        }
    }
}