using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// Estado do pedido
        /// </summary>
        public EstadoPedido Estado { get; set; }

        /// <summary>
        /// Orçamento do pedido
        /// </summary>
        public Orcamento Orcamento { get; set; }

        /// <summary>
        /// Lista de itens do pedido
        /// </summary>
        public List<PedidoItem> Itens { get; set; }
    }
}