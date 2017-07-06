using System;
using Lojista.Model;

namespace UnitTestLojista.Model
{
    public class AtacadistaMoqRepository : IAtacadistaRepository
    {
        public int IdPedido { get; set; } = 1;

        public int OrcamentoAceito { get; set; } = 0;

        public int OrcamentoRejeitado { get; set; } = 0;

        public string UrlAtacadista { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
