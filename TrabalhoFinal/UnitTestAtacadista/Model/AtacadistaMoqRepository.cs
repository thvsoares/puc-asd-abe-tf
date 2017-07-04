using Atacadista.Model;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestAtacadista.Model
{
    public class AtacadistaMoqRepository : IAtacadistaRepository
    {
        private List<Pedido> _pedidos = new List<Pedido>();
        private List<Produto> _produtos = new List<Produto>();

        public Pedido BuscarPedido(int id)
        {
            return _pedidos.Single(s => s.Id == id);
        }

        public List<Pedido> BuscarPedidos()
        {
            return _pedidos;
        }

        public List<Produto> BuscarProdutos()
        {
            return _produtos;
        }

        public int GravarPedido(Pedido pedido)
        {
            if (pedido.Id == 0)
                pedido.Id = _pedidos.Count + 1;
            _pedidos = _pedidos.Where(w => w.Id != pedido.Id).ToList();
            _pedidos.Add(pedido);
            return pedido.Id;
        }

        public int GravarProduto(Produto produto)
        {
            _produtos = _produtos.Where(w => w.Id != produto.Id).ToList();
            _produtos.Add(produto);
            return produto.Id;
        }
    }
}
