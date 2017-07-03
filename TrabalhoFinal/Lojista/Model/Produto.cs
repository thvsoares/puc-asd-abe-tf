using System.ComponentModel.DataAnnotations;

namespace Lojista.Model
{
    /// <summary>
    /// Representa um produto com os dados relevantes para o lojista
    /// </summary>
    public class Produto
    {
        /// <summary>
        /// Código do produto
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do produto
        /// </summary>
        [Required]
        public string Nome { get; set; }
    }
}