using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokemon.API.RepositoryPattern;
using System.Collections.Generic;
using System.Linq;

namespace Pokemon.API.Controllers
{
   [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{v:apiVersion}/pokemon")]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;
         private readonly IPokemonRepository _pk;

        private readonly Pokemon.Common.Data.PokemonContext _db;
        public PokemonController(ILogger<PokemonController> logger , IPokemonRepository db)
        {
            _logger = logger;
            _pk = db;
            
        }

        [HttpGet]
        public IActionResult  Get() {


            return Ok( _pk.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var pokemon = _pk.GetById(id);

            if (pokemon == null)
            {
                return NotFound("Pokemon not found");
            }

            return Ok(pokemon);
        }

      

    }
}
