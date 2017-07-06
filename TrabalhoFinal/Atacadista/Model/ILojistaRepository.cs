using System.Collections.Generic;

namespace Atacadista.Model
{
    /// <summary>
    /// Representa o repositório do lojista
    /// </summary>
    public interface ILojistaRepository
    {
        /// <summary>
        /// Envia a proposta de orçamento para o lojista
        /// </summary>
        /// <param name="orcamento">Dados do orçamento</param>
        void PropostaOrcamento(Orcamento orcamento);

        /// <summary>
        /// Notifica o lojista de uma mudança de status no pedido
        /// </summary>
        /// <param name="id">Id do pedido</param>
        /// <param name="solicitado">Novo status</param>
        void NotificarMudancaPedido(int id, EstadoPedido solicitado);
    }
}