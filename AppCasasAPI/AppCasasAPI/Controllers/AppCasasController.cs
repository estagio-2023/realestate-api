using Microsoft.AspNetCore.Mvc;

namespace AppCasasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppCasasController : ControllerBase
    {
        private readonly ILogger<AppCasasController> _logger;

        public AppCasasController(ILogger<AppCasasController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public string Get()
        {
            return "Hello AppCasas";
        }
    }
}
