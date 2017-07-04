using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lojista.Model
{
    /// <summary>
    /// Orçamento de um pedido
    /// </summary>
    public class Orcamento
    {
        /// <summary>
        /// Código do orçamento
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
    }
}