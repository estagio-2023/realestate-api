using Microsoft.AspNetCore.Mvc;
using System.Net.Security;

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

        [HttpGet(Name = "GetAppCasas")]
        public string Get()
        {
            return "Hello AppCasas";
        }
    }
}
