using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desaffio.Integracao.Response;

namespace Desaffio.Integracao.Interfaces
{
    public interface IViaCepIntegracao
    {
        Task<ViaCepResponse>ObterDadosViaCep(string cep);
    }
}