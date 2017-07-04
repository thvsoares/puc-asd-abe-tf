using Lojista.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Lojista.Controllers
{
    /// <summary>
    /// Trata os orçamentos recebidos do atacadista
    /// </summary>
    [Route("api/[controller]")]
    public class OrcamentoController : Controller
    {
        private IAtacadistaRepository _atacadistaRepository;
        private ILojistaRepository _lojistaRepository;

        /// <summary>
        /// Construtor com injeção de depêndencia
        /// </summary>
        /// <param name="atacadistaRepository">Repositório do atacadista</param>
        /// <param name="lojistaRepository">Repositório do lojista</param>
        public OrcamentoController(IAtacadistaRepository atacadistaRepository, ILojistaRepository lojistaRepository)
        {
            _atacadistaRepository = atacadistaRepository;
            _lojistaRepository = lojistaRepository;
        }

        /// <summary>
        /// Recupera os orçamentos recebidos
        /// </summary>
        /// <returns>Dados dos orçamentos</returns>
        [HttpGet]
        public List<Orcamento> Get()
        {
            return _lojistaRepository.BuscarPedidos()
                .Where(w => w.Orcamento != null)
                .Select(s => s.Orcamento)
                .ToList();
        }

        /// <summary>
        /// Registra o orçamento de um pedido
        /// </summary>
        /// <param name="id">Código do pedido</param>
        /// <param name="orcamento">Dados do orçamento</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Orcamento orcamento)
        {
            Pedido pedido = _lojistaRepository.BuscarPedido(orcamento.IdPedido);
            pedido.Orcamento = orcamento;
            _lojistaRepository.GravarPedido(pedido);
        }

        /// <summary>
        /// Aceita o orçamento informado
        /// </summary>
        /// <param name="id">Código do orçamento</param>
        [HttpPatch("aceitar/{id}")]
        public void PatchAceitar(int id)
        {
            _atacadistaRepository.AceitarOrcamento(id);
        }

        /// <summary>
        /// Rejeita o orçamento informado
        /// </summary>
        /// <param name="id">Código do orçamento</param>
        [HttpPatch("rejeitar/{id}")]
        public void PatchRejeitar(int id)
        {
            _atacadistaRepository.RejeitarOrcamento(id);
        }
    }
}