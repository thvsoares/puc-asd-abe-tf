using Atacadista.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Atacadista.Controllers
{
    /// <summary>
    /// Gerência o cadastro de produtos do atacadista
    /// </summary>
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private IAtacadistaRepository _atacadistaRepository;

        /// <summary>
        /// Construtor com injeção de depêndencia
        /// </summary>
        /// <param name="atacadistaRepository">Repositório do atacadista</param>
        public ProdutoController(IAtacadistaRepository atacadistaRepository)
        {
            _atacadistaRepository = atacadistaRepository;
        }

        /// <summary>
        /// Recupera a lista de produtos cadastrados
        /// </summary>
        /// <returns>Lista de produtos cadastrados</returns>
        [HttpGet]
        public List<Produto> Get()
        {
            return _atacadistaRepository.BuscarProdutos();
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
            _atacadistaRepository.GravarProduto(produto);
        }
    }
}