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
        /// Recupera a lista de produtos cadastrados
        /// </summary>
        /// <returns>Lista de produtos cadastrados</returns>
        [HttpGet]
        public List<Produto> Get()
        {
            return _lojistaRepository.BuscarProdutos();
        }

        /// <summary>
        /// Cadastra um produto com um id específico
        /// </summary>
        /// <param name="id">Código do produto</param>
        /// <param name="produto">Dados do produto a ser cadastrado</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Produto produto)
        {
            produto.Id = id;
            _lojistaRepository.GravarProduto(produto);
        }
    }
}