using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Atacadista.Model;

namespace Atacadista.Controllers
{
    /// <summary>
    /// Gerencia os orçamentos do atacadista
    /// </summary>
    [Route("api/[controller]")]
    public class OrcamentoController : Controller
    {
        private IAtacadistaRepository _atacadistaRepository;
        private ILojistaRepository _lojistaRepository;

        public OrcamentoController(IAtacadistaRepository atacadistaRepository, ILojistaRepository lojistaRepository)
        {
            _atacadistaRepository = atacadistaRepository;
            _lojistaRepository = lojistaRepository;
        }

        /// <summary>
        /// Recupera os orçamentos
        /// </summary>
        /// <returns>Retorna os dados dos orçamentos gravdos</returns>
        [HttpGet]
        public List<Orcamento> Get()
        {
            return _atacadistaRepository.BuscarOrcamentos();
        }

        /// <summary>
        /// Grava o orçamento de um pedido
        /// </summary>
        /// <param name="orcamento">Dados do orçamento com o id do pedido</param>
        /// <returns>Sequencial do orçamento gravado</returns>
        [HttpPost]
        public int Post([FromBody]Orcamento orcamento)
        {
            var pedido = _atacadistaRepository.BuscarPedido(orcamento.IdPedido);
            pedido.Orcamento = orcamento;

            _atacadistaRepository.GravarPedido(pedido);

            _lojistaRepository.PropostaOrcamento(pedido.Orcamento);

            return orcamento.Id;
        }

        /// <summary>
        /// Aceita o orçamento informado
        /// </summary>
        /// <param name="id">Código do orçamento</param>
        [HttpPut("aceitar/{id}")]
        public void PatchAceitar(int id)
        {
            var pedido = _atacadistaRepository.BuscarPedidos().Single(s => s.Orcamento?.Id == id);
            _atacadistaRepository.MudarEstadoPedido(pedido.Id, EstadoPedido.Solicitado);
            _lojistaRepository.NotificarMudancaPedido(pedido.Id, EstadoPedido.Solicitado);
        }

        /// <summary>
        /// Rejeita o orçamento informado
        /// </summary>
        /// <param name="id">Código do orçamento</param>
        [HttpPut("rejeitar/{id}")]
        public void PatchRejeitar(int id)
        {
            var pedido = _atacadistaRepository.BuscarPedidos().Single(s => s.Orcamento?.Id == id);
            _atacadistaRepository.MudarEstadoPedido(pedido.Id, EstadoPedido.Finalizado);
            _lojistaRepository.NotificarMudancaPedido(pedido.Id, EstadoPedido.Finalizado);
        }
    }
}
