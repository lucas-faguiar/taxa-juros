using System;
using System.Threading.Tasks;

namespace CalculaJuros.API.Interfaces
{
    public interface IJurosService
    {   
        Task<double> ObtemTaxaJuros();
        double CalculaJuros(double valorInicial, Int32 meses, double taxajuros);
        string FormataJuros(double juros);
    }
}