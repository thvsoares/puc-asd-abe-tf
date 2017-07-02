namespace Atacadista.Model
{
    /// <summary>
    /// Representa um produto com os dados relevantes para o atacadista
    /// </summary>
    public class Produto
    {
        /// <summary>
        /// Código do produto
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do produto
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Valor de uma unidade
        /// </summary>
        public float Valor { get; set; }
    }
}