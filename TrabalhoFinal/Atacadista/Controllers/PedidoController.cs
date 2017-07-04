using Atacadista.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Atacadista.Controllers
{
    /// <summary>
    /// Gerência os pedidos recebidos dos lojistas
    /// </summary>
    [Route("api/[controller]")]
    public class PedidoController : Controller
    {
        private IAtacadistaRepository _atacadistaRepository;

        /// <summary>
        /// Construtor com injeção de depêndencia
        /// </summary>
        /// <param name="atacadistaRepository">Repositório do atacadista</param>
        public PedidoController(IAtacadistaRepository atacadistaRepository)
        {
            _atacadistaRepository = atacadistaRepository;
        }

        /// <summary>
        /// Recupera a lista de pedidos
        /// </summary>
        /// <returns>Lista de pedidos cadastrados</returns>
        [HttpGet]
        public List<Pedido> Get()
        {
            return _atacadistaRepository.BuscarPedidos();
        }

        /// <summary>
        /// Grava um pedido
        /// </summary>
        /// <param name="pedido">Dados de pedido</param>
        /// <returns>Sequencial do pedido gravado</returns>
        [HttpPost]
        public int Post([FromBody]Pedido pedido)
        {
            return _atacadistaRepository.GravarPedido(pedido);
        }
    }
}