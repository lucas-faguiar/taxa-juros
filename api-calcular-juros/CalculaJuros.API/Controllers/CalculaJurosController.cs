﻿using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CalculaJuros.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ILogger<CalculaJurosController> _logger;

        public CalculaJurosController(ILogger<CalculaJurosController> logger)
        {
            _logger = logger;
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

            // Obtém taxa de juros
            double taxajuros = 0.0;            
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://taxajuros.azurewebsites.net/taxajuros"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    double.TryParse(apiResponse, NumberStyles.Any, CultureInfo.CreateSpecificCulture("pt-BR"), out taxajuros);
                }
            }

            // Cálculo do juros
            double juros = valorInicial*Math.Pow((1 + taxajuros), meses);
            
            // Formatação da resposta
            double jurosTruncado = Math.Truncate(juros * 100) / 100;
            string jurosFormatado = jurosTruncado.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));

            // Retorno
            return Ok(jurosFormatado);
        }
    }
}