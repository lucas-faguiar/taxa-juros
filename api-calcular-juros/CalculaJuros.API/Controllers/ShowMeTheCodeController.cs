using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ShowMeTheCode.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowMeTheCodeController : ControllerBase
    {
        private readonly ILogger<ShowMeTheCodeController> _logger;

        public ShowMeTheCodeController(ILogger<ShowMeTheCodeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // Url do código fonte
            string url = "https://github.com/lucas-faguiar/taxa-juros";

            // Retorno
            return Ok(url);
        }
    }
}
