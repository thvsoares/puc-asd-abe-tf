using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojista.Model
{
    /// <summary>
    /// Interface que define as operações locais do lojista
    /// </summary>
    public interface ILojistaRepository
    {
        /// <summary>
        /// Grava uma lista de produtos no repositório local
        /// </summary>
        /// <param name="produtos">Dados dos produtos a serem gravados</param>
        /// <returns>Quantidade de produtos gravados</returns>
        int GravarProdutos(List<Produto> produtos);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Estoque> ConsultarEstoque();
    }
}
