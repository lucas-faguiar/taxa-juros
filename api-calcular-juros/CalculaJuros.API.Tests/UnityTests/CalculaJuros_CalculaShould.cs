using System;
using Xunit;
using CalculaJuros.API.Interfaces;  
using CalculaJuros.API.Services;  

namespace CalculaJuros.API.Tests
{
    public class CalculaJuros_CalculaShould
    {
        private readonly IJurosService _jurosService;

        public CalculaJuros_CalculaShould()
        {
            _jurosService = new JurosService();
        }

        [Fact]
        public async void ObtemTaxaJuros_Should_ReturnCorrectValue()
        {
            // Act
            var response = await _jurosService.ObtemTaxaJuros();
        
            // Assert
            Assert.Equal(0.01, response);
        }

        [Fact]
        public void CalculaJuros_Should_ReturnCorrectValue()
        {
            // Arrange
            double valorInicial = 100;
            int meses = 5;
            double taxaJuros = 0.01;

            // Act
            var response = _jurosService.CalculaJuros(valorInicial, meses, taxaJuros);
        
            // Assert
            Assert.Equal(105.10100501000001, response);
        }

        [Fact]
        public void FormataJuros_Should_ReturnCorrectValue()
        {
            // Arrange
            double juros = 105.10100501000001;
        
            // Act
            var response = _jurosService.FormataJuros(juros);
        
            // Assert
            Assert.Equal("105,10", response);
        }
    }
}
