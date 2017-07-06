using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atacadista.Model
{
    public class LojistaRepository : ILojistaRepository
    {
        private static string _urlLojista;
        public string UrlLojista { get => _urlLojista; set => _urlLojista = value; }

        public void NotificarMudancaPedido(int id, EstadoPedido solicitado)
        {
            throw new NotImplementedException();
        }

        public void PropostaOrcamento(Orcamento orcamento)
        {
            throw new NotImplementedException();
        }
    }
}
