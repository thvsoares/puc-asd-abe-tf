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

        /// <summary>
        /// Cria ou atualiza uma entrada de estoque para um código de produto
        /// </summary>
        /// <param name="id">Código do produto</param>
        /// <param name="estoque">Dados da entrada de estoque</param>
        /// <returns>Sequencial da entrada de estoque criada/atualizada</returns>
        [HttpPut("{id}")]
        public int Put(int id, [FromBody]Estoque estoque)
        {
            var estoqueLocal = _lojistaRepository.BuscarEstoquePorProduto(id);

            if (estoqueLocal == null)
            {
                estoqueLocal = estoque;
                estoque.Produto = _lojistaRepository.BuscarProduto(id);
            }
            else
            {
                estoqueLocal.Quantidade = estoque.Quantidade;
            }

            _lojistaRepository.GravarEstoque(estoqueLocal);

            return estoqueLocal.Id;
        }
    }
}