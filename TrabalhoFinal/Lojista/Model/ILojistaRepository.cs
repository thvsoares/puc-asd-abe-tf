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
        /// Recupera a entrada de estoque com a quantidade do produto informado
        /// </summary>
        /// <param name="id">Código do produto</param>
        /// <returns>Dados do estoque</returns>
        Estoque BuscarEstoquePorProduto(int id);

        /// <summary>
        /// Recupera um produto pelo seu código
        /// </summary>
        /// <param name="id">Código do produto</param>
        /// <returns>Dados do produto</returns>
        Produto BuscarProduto(int id);

        /// <summary>
        /// Recupera a lista de registros de estoque
        /// </summary>
        /// <returns>Dados do estoque</returns>
        List<Estoque> BuscarEstoque();

        /// <summary>
        /// Grava um pedido com seus itens
        /// </summary>
        /// <param name="pedido">Dados do pedido e itens</param>
        /// <returns>Sequencia do pedido gravado</returns>
        int GravarPedido(Pedido pedido);

        /// <summary>
        /// Recupera a lista de pedidos
        /// </summary>
        /// <returns>Dados dos pedidos</returns>
        List<Pedido> BuscarPedidos();

        /// <summary>
        /// Recupera o pedido informado
        /// </summary>
        /// <param name="id">Código do pedido</param>
        /// <returns>Dados do pedido</returns>
        Pedido BuscarPedido(int id);

        /// <summary>
        /// Atualiza o estado de um pedido
        /// </summary>
        /// <param name="id">Sequencial do pedido</param>
        /// <param name="estado">Novo estado de pedido</param>
        void AtualizarEstadoPedido(int id, EstadoPedido estado);
    }
}