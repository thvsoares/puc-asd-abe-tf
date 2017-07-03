using System.Collections.Generic;

namespace Lojista.Model
{
    /// <summary>
    /// Interface que define as operações locais do lojista
    /// </summary>
    public interface ILojistaRepository
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

        /// <summary>
        /// Grava uma entrade de estoque referente a um produto
        /// </summary>
        /// <param name="estoque">Dados do estoque com id do produto</param>
        /// <returns>Sequencial do registro gravado</returns>
        int GravarEstoque(Estoque estoque);

        /// <summary>
        /// Recupera a lista de registros de estoque
        /// </summary>
        /// <returns>Dados do estoque</returns>
        List<Estoque> BuscarEstoque();
    }
}