﻿using System;
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
        public IActionResult Get(double valorInicial, Int32 meses)
        {
            // Verificação dos parâmetros
            List<string> erros = new List<string>();
            if (valorInicial == 0)
                erros.Add("Preencha o campo valorInicial com algum valor maior que 0");
            if (meses == 0)
                erros.Add("Preencha o campo meses com algum valor maior que 0");
            if(erros.Count > 0) 
                return BadRequest(erros);
            
            // Cálculo do juros
            double juros = valorInicial*Math.Pow((1 + 0.01), meses);
            
            // Formatação da resposta
            double jurosFormatado = Math.Truncate(100 * juros) / 100;

            // Retorno
            return Ok(jurosFormatado);
        }
    }
}