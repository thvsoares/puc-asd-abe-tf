using System.ComponentModel.DataAnnotations;

namespace Lojista.Model
{
    /// <summary>
    /// Representa a quantidade de um produto no estoque do lojista
    /// </summary>
    public class Estoque
    {
        /// <summary>
        /// Código da entrada de estoque
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Quantidade do produto no estoque do lojista
        /// </summary>
        [Required]
        public int Quantidade { get; set; }

        /// <summary>
        /// Relacionamento com produto
        /// </summary>
        [Required]
        public Produto Produto { get; set; }
    }
}