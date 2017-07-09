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
        /// <param name="lojistaRepository">Repositório do lojista</param>
        public ConfiguracaoController(IAtacadistaRepository atacadistaRepository)
        {
            _atacadistaRepository = atacadistaRepository;
        }

        /// <summary>
        /// Atualiza uma configuração
        /// </summary>
        /// <param name="key">Chave da configuração</param>
        /// <param name="value">Novo valor para a configuração</param>
        [HttpPut("key")]
        public void Put(string key, [FromBody]string value)
        {
            switch (key.ToUpper())
            {
                case "URLATACADISTA": _atacadistaRepository.UrlAtacadista = value; break;
                default: throw new KeyNotFoundException();
            }
        }
    }
}