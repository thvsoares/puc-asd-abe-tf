using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojista.Model
{
    /// <summary>
    /// Representa o repositório do atacadista
    /// </summary>
    public interface IAtacadistaRepository
    {
        /// <summary>
        /// Gera um orçamento com uma data e valor para um pedido
        /// </summary>
        /// <param name="pedido">Dados do pedido</param>
        /// <returns>Orçamento com data e valor</returns>
        Orcamento GerarOrcamento(Pedido pedido);
    }
}
