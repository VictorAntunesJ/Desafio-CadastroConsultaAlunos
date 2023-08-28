using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desaffio.Integracao.Response;
using Refit;

namespace Desaffio.Integracao.Refit
{
    public interface IViaCepIntegracaoRefit
    {
        [Get("/ws/{Cep}/json")]
        Task<ApiResponse<ViaCepResponse>> ObterDadosViaCep(string cep);
    }
}
