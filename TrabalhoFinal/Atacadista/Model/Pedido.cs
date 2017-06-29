using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atacadista.Model
{
    /// <summary>
    /// Representa um pedido
    /// </summary>
    public class Pedido
    {
        /// <summary>
        /// Código do pedido
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Lista de itens do pedido
        /// </summary>
        public List<PedidoItem> Itens { get; set; }
    }
}
