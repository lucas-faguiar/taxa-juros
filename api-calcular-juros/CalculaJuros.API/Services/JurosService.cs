using System;
using System.Threading.Tasks;
using System.Globalization;
using System.Net.Http;
using CalculaJuros.API.Interfaces;

namespace CalculaJuros.API.Services

{
    public class JurosService : IJurosService
    {
        public async Task<double> ObtemTaxaJuros()
        {
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

            return taxajuros;
        }

        public double CalculaJuros(double valorInicial, Int32 meses, double taxajuros)
        {
            // Cálculo do juros
            double juros = valorInicial*Math.Pow((1 + taxajuros), meses);

            return juros;
        }

        public string FormataJuros(double juros)
        {            
            // Formatação do juros
            double jurosTruncado = Math.Truncate(juros * 100) / 100;
            string jurosFormatado = jurosTruncado.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));

            return jurosFormatado;
        }
    }
}