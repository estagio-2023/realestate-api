using AppCasasAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Security;

namespace AppCasasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppCasasController : ControllerBase
    {
        private readonly ILogger<AppCasasController> _logger;
        private readonly IVendedorRepository _vendedorRepository;

        public AppCasasController(ILogger<AppCasasController> logger,IVendedorRepository vendedorRepository)
        {
            _logger = logger;   
            _vendedorRepository = vendedorRepository;
        }

        [HttpGet(Name = "GetAppCasas")]
        public async Task<string?> Get()
        {
            return await _vendedorRepository.GetUserName();
           
        }
    }
}
