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

        /// <summary>
        /// Recupera a lista de oreçamentos
        /// </summary>
        /// <returns>Dados dos orçamentos</returns>
        List<Orcamento> BuscarOrcamentos();

        /// <summary>
        /// Recupera a lista de pedidos
        /// </summary>
        /// <returns>Dados dos pedidos</returns>
        List<Pedido> BuscarPedidos();

        /// <summary>
        /// Recupera um pedido
        /// </summary>
        /// <param name="id">Código do pedido</param>
        /// <returns>Dados do pedido</returns>
        Pedido BuscarPedido(int id);

        /// <summary>
        /// Grava um pedido
        /// </summary>
        /// <param name="pedido">Dados do pedido</param>
        /// <returns>Sequencial do pedido</returns>
        int GravarPedido(Pedido pedido);

        /// <summary>
        /// Muda o estado de um pedido
        /// </summary>
        /// <param name="id">Id do pedido</param>
        /// <param name="estado">Novo estado do pedido</param>
        void MudarEstadoPedido(int id, EstadoPedido estado);
    }
}
