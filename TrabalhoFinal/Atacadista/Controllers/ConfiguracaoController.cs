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
        /// <param name="key">Chave da configuração</param>
        /// <param name="value">Novo valor para a configuração</param>
        [HttpPut("key")]
        public void Put(string key, [FromBody]string value)
        {
            switch (key.ToUpper())
            {
                case "URLLOJISTA": _lojistaRepository.UrlLojista = value; break;
                default: throw new KeyNotFoundException();
            }
        }
    }
}