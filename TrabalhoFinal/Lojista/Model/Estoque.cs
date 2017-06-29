using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public int Id { get; set; }

        /// <summary>
        /// Quantidade do produto no estoque do lojista
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// Relacionamento com produto
        /// </summary>
        public Produto Produto { get; set; }
    }
}
