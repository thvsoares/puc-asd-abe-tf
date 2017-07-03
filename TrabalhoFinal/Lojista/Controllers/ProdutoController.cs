using Lojista.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Lojista.Controllers
{
    /// <summary>
    /// Gerência o cadastro de produtos do lojista
    /// </summary>
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private ILojistaRepository _lojistaRepository;

        /// <summary>
        /// Construtor com injeção de depêndencia
        /// </summary>
        /// <param name="lojistaRepository">Repositório do lojista</param>
        public ProdutoController(ILojistaRepository lojistaRepository)
        {
            _lojistaRepository = lojistaRepository;
        }

        /// <summary>
        /// Cadastra um produto
        /// </summary>
        /// <param name="produto">Dados do produto a ser cadastrado</param>
        [HttpPost]
        public void Put(int id, [FromBody]Produto produto)
        {
            produto.Id = id;
            _lojistaRepository.GravarProduto(produto);
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