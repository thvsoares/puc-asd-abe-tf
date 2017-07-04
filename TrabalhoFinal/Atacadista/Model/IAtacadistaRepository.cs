using System.Collections.Generic;

namespace Atacadista.Model
{
    /// <summary>
    /// Define as operações locais do atacadista
    /// </summary>
    public interface IAtacadistaRepository
    {
        /// <summary>
        /// Grava um produto no repositorio local
        /// </summary>
        /// <param name="produto">Dados do produto a ser gravado</param>
        /// <returns>Código do produto gravado</returns>
        int GravarProduto(Produto produto);

        /// <summary>
        /// Recupera a lista de produtos
        /// </summary>
        /// <returns>Dados dos produtos</returns>
        List<Produto> BuscarProdutos();
    }
}
