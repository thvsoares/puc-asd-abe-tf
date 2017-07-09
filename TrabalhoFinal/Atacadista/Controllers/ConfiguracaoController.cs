using Atacadista.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Atacadista.Controllers
{
    /// <summary>
    /// Gerência a configuração do lojista
    /// </summary>
    [Route("api/[controller]")]
    public class ConfiguracaoController : Controller
    {
        private ILojistaRepository _lojistaRepository;

        /// <summary>
        /// Construtor com injeção de depêndencia
        /// </summary>
        /// <param name="lojistaRepository">Repositório do lojista</param>
        public ConfiguracaoController(ILojistaRepository lojistaRepository)
        {
            _lojistaRepository = lojistaRepository;
        }

        /// <summary>
        /// Atualiza uma configuração
        /// </summary>
        /// <param name="configuracao">Chave valor com a configuracao a ser atualizada</param>
        [HttpPut]
        public void Put([FromBody]KeyValuePair<string, string> configuracao)
        {
            switch (configuracao.Key.ToUpper())
            {
                case "URLLOJISTA": _lojistaRepository.UrlLojista = configuracao.Value; break;
                default: throw new KeyNotFoundException();
            }
        }
    }
}