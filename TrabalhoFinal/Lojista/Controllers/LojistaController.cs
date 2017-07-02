using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lojista.Controllers
{
    /// <summary>
    /// Controla as operações do lojista
    /// </summary>
    [Route("api/[controller]")]
    public class LojistaController : Controller
    {
        /// <summary>
        /// Recupera os valores do estoque atual
        /// </summary>
        /// <returns>Dados do estoque atual</returns>
        [HttpGet]
        [Route("estoque")]
        public IEnumerable<string> BuscarEstoque()
        {
            return new string[] { "value1", "estoque" };
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
