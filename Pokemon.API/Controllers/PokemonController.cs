using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Pokemon.API.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/Pokemon")]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;

        public PokemonController(ILogger<PokemonController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hi, from the Pokemon Controller");
        }
    }
}
