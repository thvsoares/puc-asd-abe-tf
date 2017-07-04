using Lojista.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace UnitTestLojista.Model
{
    public class LojistaMoqRepository : ILojistaRepository
    {
        private List<Estoque> _estoque = new List<Estoque>();
        private List<Pedido> _pedidos = new List<Pedido>();
        private List<Produto> _produtos = new List<Produto>();

        public List<Estoque> BuscarEstoque()
        {
            return _estoque;
        }

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

        public int GravarEstoque(Estoque estoque)
        {
            if (estoque.Id == 0)
                estoque.Id = _estoque.Count + 1;
            _estoque = _estoque.Where(w => w.Id != estoque.Id).ToList();
            _estoque.Add(estoque);
            return estoque.Id;
        }

        public int GravarPedido(Pedido pedido)
        {
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
