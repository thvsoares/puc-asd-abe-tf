using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public int Id { get; set; }

        /// <summary>
        /// Nome do produto
        /// </summary>
        public string Nome { get; set; }
    }
}
