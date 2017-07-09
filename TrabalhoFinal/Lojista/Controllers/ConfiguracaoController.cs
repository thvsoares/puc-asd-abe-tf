using Lojista.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Lojista.Controllers
{
    /// <summary>
    /// Gerência a configuração do lojista
    /// </summary>
    [Route("api/[controller]")]
    public class ConfiguracaoController : Controller
    {
        private IAtacadistaRepository _atacadistaRepository;

        /// <summary>
        /// Construtor com injeção de depêndencia
        /// </summary>
        /// <param name="atacadistaRepository">Repositório do atacadista</param>
        public ConfiguracaoController(IAtacadistaRepository atacadistaRepository)
        {
            _atacadistaRepository = atacadistaRepository;
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
                case "URLATACADISTA": _atacadistaRepository.UrlAtacadista = configuracao.Value; break;
                default: throw new KeyNotFoundException();
            }
        }
    }
}