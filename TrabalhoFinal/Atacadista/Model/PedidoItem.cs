using System.ComponentModel.DataAnnotations;

namespace Atacadista.Model
{
    /// <summary>
    /// Entrada de produto num pedido
    /// </summary>
    public class PedidoItem
    {
        /// <summary>
        /// Código do pedido
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Código do produto
        /// </summary>
        public int IdProduto { get; set; }

        /// <summary>
        /// Quantidade de unidades do produto
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// Observação do pedido
        /// </summary>
        public string Observacao { get; set; }
    }
}