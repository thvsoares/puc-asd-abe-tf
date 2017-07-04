using System;
using System.Collections.Generic;
using System.Linq;

namespace Atacadista.Model
{
    public class AtacadistaReporsitory : IAtacadistaRepository
    {
        private AtacadistaContext _context;

        public AtacadistaReporsitory(AtacadistaContext context)
        {
            _context = context;
        }

        public int GravarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return produto.Id;
        }

        public List<Produto> BuscarProdutos()
        {
            return _context.Produtos.ToList();
        }

        public int GravarPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
            return pedido.Id;
        }

        public List<Pedido> BuscarPedidos()
        {
            return _context.Pedidos.ToList();
        }

        public Pedido BuscarPedido(int id)
        {
            return _context.Pedidos.Single(s => s.Id == id);
        }
    }
}
