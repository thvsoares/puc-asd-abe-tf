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
            return _lojistaRepository.ConsultarEstoque();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}