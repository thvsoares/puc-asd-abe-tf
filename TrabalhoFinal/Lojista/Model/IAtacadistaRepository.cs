namespace Lojista.Model
{
    /// <summary>
    /// Representa o repositório do atacadista
    /// </summary>
    public interface IAtacadistaRepository
    {
        /// <summary>
        /// Caminho base do serviço de atacadista
        /// </summary>
        string UrlAtacadista { get; set; }

        /// <summary>
        /// Realiza uma solicitação de pedido ao atacadista
        /// </summary>
        /// <param name="pedido">Dados do pedido</param>
        /// <returns>Sequencial do pedido recebido</returns>
        int SolicitacaoPedido(Pedido pedido);

        /// <summary>
        /// Aceita o orçamento informado
        /// </summary>
        /// <param name="id">Id do orçamento a ser aceito</param>
        void AceitarOrcamento(int id);

        /// <summary>
        /// Rejeita o orçamento informado
        /// </summary>
        /// <param name="id">Id do orçamento a ser rejeitado</param>
        void RejeitarOrcamento(int id);
    }
}
