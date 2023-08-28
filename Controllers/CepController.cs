using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desaffio.Integracao.Interfaces;
using Desaffio.Integracao.Response;
using Microsoft.AspNetCore.Mvc;

namespace Desaffio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegracao _viaCepIntegracao;

        public CepController(IViaCepIntegracao viaCepIntegracao)
        {
            _viaCepIntegracao = viaCepIntegracao;
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<ViaCepResponse>> ListarDadosDoEndereco(string cep)
        {
            var responseData = await _viaCepIntegracao.ObterDadosViaCep(cep);

            if (responseData == null)
            {
                return BadRequest("CEP Não Encontrado!!");
            }
            return Ok(responseData);
        }
    }
}
