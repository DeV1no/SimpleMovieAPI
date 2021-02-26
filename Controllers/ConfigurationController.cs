using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("api/configuration")]
    public class ConfigurationController:ControllerBase
    {
        private readonly IConfiguration configuration;

        public ConfigurationController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(configuration["lastname"]);
        }
    }
}