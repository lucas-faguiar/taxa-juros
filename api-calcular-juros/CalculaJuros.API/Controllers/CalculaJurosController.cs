using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CalculaJuros.API.Interfaces;

namespace CalculaJuros.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ILogger<CalculaJurosController> _logger;
        private readonly IJurosService _jurosService;

        public CalculaJurosController(
            ILogger<CalculaJurosController> logger,
            IJurosService jurosService
        )
        {
            _logger = logger;
            _jurosService = jurosService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(double valorInicial, Int32 meses)
        {
            // Verificação dos parâmetros
            List<string> erros = new List<string>();
            if (valorInicial == 0)
                erros.Add("Preencha o campo valorInicial com algum valor maior que 0");
            if (meses == 0)
                erros.Add("Preencha o campo meses com algum valor maior que 0");
            if(erros.Count > 0) 
                return BadRequest(erros);

            // Serviço para obter taxa de juros
            double taxaJuros = await _jurosService.ObtemTaxaJuros();  

            // Serviço para calcular juros
            double juros = _jurosService.CalculaJuros(valorInicial, meses, taxaJuros);   

            // Serviço para formatar juros
            string jurosFormatado = _jurosService.FormataJuros(juros);     

            // Retorno
            return Ok(jurosFormatado);
        }
    }
}
