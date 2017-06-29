using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atacadista.Model
{
    /// <summary>
    /// Estados dos pedidos
    /// </summary>
    public enum EstadoPedido: byte
    {
        /// <summary>
        /// Estado inicial de um pedido
        /// </summary>
        Solicitado,

        /// <summary>
        /// Estado do pedido após confirmação
        /// </summary>
        EmFabricacao,

        /// <summary>
        /// Estado do pedido rejeitado
        /// </summary>
        Finalizado,

        /// <summary>
        /// Estado do pedido enviao ao lojista
        /// </summary>
        Despachado
    }
}
