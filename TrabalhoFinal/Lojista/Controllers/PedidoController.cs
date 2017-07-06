using Lojista.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Lojista.Controllers
{
    /// <summary>
    /// Gerência os pedidos do lojista
    /// </summary>
    [Route("api/[controller]")]
    public class PedidoController : Controller
    {
        private ILojistaRepository _lojistaRepository;
        private IAtacadistaRepository _atacadistaRepository;

        /// <summary>
        /// Construtor com injeção de depêndencia
        /// </summary>
        /// <param name="atacadistaRepository">Repositório do atacadista</param>
        /// <param name="lojistaRepository">Repositório do lojista</param>
        public PedidoController(IAtacadistaRepository atacadistaRepository, ILojistaRepository lojistaRepository)
        {
            _atacadistaRepository = atacadistaRepository;
            _lojistaRepository = lojistaRepository;
        }

        /// <summary>
        /// Realiza um pedido ao atacadista
        /// </summary>
        /// <param name="pedido">Dados do pedido</param>
        /// <returns>Sequencial do pedido retornado pelo atacadista</returns>
        [HttpPost]
        public int Post(Pedido pedido)
        {
            int idPedido = _atacadistaRepository.SolicitacaoPedido(pedido);
            pedido.Id = idPedido;
            _lojistaRepository.GravarPedido(pedido);
            return pedido.Id;
        }

        /// <summary>
        /// Atualiza o estado de um pedido
        /// </summary>
        /// <param name="id">Sequencial do pedido</param>
        /// <param name="estado">Estado do pedido</param>
        [HttpPut("AtualizarEstado/{id}/{estado}")]
        public void PatchAtualizarEstado(int id, EstadoPedido estado)
        {
            _lojistaRepository.AtualizarEstadoPedido(id, estado);
        }
    }
}