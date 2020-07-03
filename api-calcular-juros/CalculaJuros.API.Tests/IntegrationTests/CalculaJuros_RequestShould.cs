using Xunit;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;  
using Microsoft.AspNetCore.Hosting;

namespace CalculaJuros.API.Tests
{
    public class CalculaJuros_RequestShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public CalculaJuros_RequestShould()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
            .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task ReturnCalculaJuros()
        {
            // Act
            var response = await _client.GetAsync("/calculaJuros?valorInicial=100&meses=5");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("105,10", responseString);
        }
       
    }
}
