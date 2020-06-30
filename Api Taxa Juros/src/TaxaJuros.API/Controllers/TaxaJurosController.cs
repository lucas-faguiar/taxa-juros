using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TaxaJuros.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaJurosController : ControllerBase
    {
        private static readonly double TaxaJuros = 0.01;

        private readonly ILogger<TaxaJurosController> _logger;

        public TaxaJurosController(ILogger<TaxaJurosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            string resultado = TaxaJuros.ToString("G", CultureInfo.CreateSpecificCulture("pt-BR")); //.Replace('.', ',');
            return resultado;
        }
    }
}
