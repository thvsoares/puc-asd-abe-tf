using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atacadista.Model
{
    /// <summary>
    /// Orçamento de um pedido
    /// </summary>
    public class Orcamento
    {
        /// <summary>
        /// Código do orçamento
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Código do pedido
        /// </summary>
        public int IdPedido { get; set; }

        /// <summary>
        /// Valor do orçamento
        /// </summary>
        public float Valor { get; set; }

        /// <summary>
        /// Data prevista de entrega
        /// </summary>
        public DateTime PrevisaoEntrega { get; set; }

        /// <summary>
        /// Pedido do orçamento
        /// </summary>
        public Pedido Pedido { get; set; }
    }
}
