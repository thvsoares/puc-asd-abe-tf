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
        private ILojistaRepository _lojistaRepository;

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

        /// <summary>
        /// Muda o estado de um pedido para em fabricação e notifica o cliente
        /// </summary>
        /// <param name="id">Código do pedido</param>
        [HttpPut("fabricar/{id}")]
        public void PutFabricar(int id)
        {
            _atacadistaRepository.MudarEstadoPedido(id, EstadoPedido.EmFabricacao);
            _lojistaRepository.NotificarMudancaPedido(id, EstadoPedido.EmFabricacao);
        }

        /// <summary>
        /// Muda o estado de um pedido para despachado e notifica o cliente
        /// </summary>
        /// <param name="id">Código do pedido</param>
        [HttpPut("despachar/{id}")]
        public void PutDespachar(int id)
        {
            _atacadistaRepository.MudarEstadoPedido(id, EstadoPedido.Despachado);
            _lojistaRepository.NotificarMudancaPedido(id, EstadoPedido.Despachado);
        }
    }
}