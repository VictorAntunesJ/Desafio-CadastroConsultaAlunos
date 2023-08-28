using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desaffio.Integracao.Interfaces;
using Desaffio.Integracao.Refit;
using Desaffio.Integracao.Response;

namespace Desaffio.Integracao
{
    public class ViaCepIntegracao : IViaCepIntegracao
    {
        private readonly IViaCepIntegracaoRefit _viaCepIntegracaoRefit;

        public ViaCepIntegracao(IViaCepIntegracaoRefit viaCepIntegracaoRefit)
        {
            _viaCepIntegracaoRefit = viaCepIntegracaoRefit;
        }

        public async Task<ViaCepResponse> ObterDadosViaCep(string cep)
        {
            var responseData = await _viaCepIntegracaoRefit.ObterDadosViaCep(cep);

            if (responseData != null && responseData.IsSuccessStatusCode)
            {
                return responseData.Content;
            }
            return null;
        }
    }
}
