using Lojista.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Lojista.Controllers
{
    /// <summary>
    /// Gerência o estoque do lojista
    /// </summary>
    [Route("api/[controller]")]
    public class EstoqueController : Controller
    {
        private ILojistaRepository _lojistaRepository;

        /// <summary>
        /// Construtor com injeção de depêndencia
        /// </summary>
        /// <param name="lojistaRepository">Repositório do lojista</param>
        public EstoqueController(ILojistaRepository lojistaRepository)
        {
            _lojistaRepository = lojistaRepository;
        }

        /// <summary>
        /// Recupera os valores do estoque atual
        /// </summary>
        /// <returns>Dados do estoque atual</returns>
        [HttpGet]
        public IEnumerable<Estoque> Get()
        {
            return _lojistaRepository.BuscarEstoque();
        }
    }
}