using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojista.Model
{
    public class AtacadistaRepository : IAtacadistaRepository
    {
        private static string _urlAtacadista;
        public string UrlAtacadista { get => _urlAtacadista; set => _urlAtacadista = value; }

        public void AceitarOrcamento(int id)
        {
            throw new NotImplementedException();
        }

        public void RejeitarOrcamento(int id)
        {
            throw new NotImplementedException();
        }

        public int SolicitacaoPedido(Pedido pedido)
        {
            throw new NotImplementedException();
        }
    }
}
