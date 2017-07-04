using Lojista.Model;

namespace UnitTestLojista.Model
{
    public class AtacadistaMoqRepository : IAtacadistaRepository
    {
        public int IdPedido { get; set; } = 1;

        public int OrcamentoAceito { get; set; }

        public int OrcamentoRejeitado { get; set; }

        public void AceitarOrcamento(int id)
        {
            OrcamentoAceito = id;
        }

        public void RejeitarOrcamento(int id)
        {
            OrcamentoRejeitado = id;
        }

        public int SolicitacaoPedido(Pedido pedido)
        {
            return IdPedido++;
        }
    }
}
