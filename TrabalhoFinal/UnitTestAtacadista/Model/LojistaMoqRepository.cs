using System.Collections.Generic;
using System.Linq;
using System;
using Atacadista.Model;

namespace UnitTestAtacadista.Model
{
    public class LojistaMoqRepository : ILojistaRepository
    {
        public string UrlLojista { get; set; }

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
