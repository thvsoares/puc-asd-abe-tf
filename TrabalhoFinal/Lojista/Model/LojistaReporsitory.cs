using System;
using System.Collections.Generic;
using System.Linq;

namespace Lojista.Model
{
    public class LojistaReporsitory : ILojistaRepository
    {
        private LojistaContext _context;

        public LojistaReporsitory(LojistaContext context)
        {
            _context = context;
        }

        public List<Estoque> BuscarEstoque()
        {
            return _context.Estoques.ToList();
        }

        public int GravarEstoque(Estoque estoque)
        {
            _context.Estoques.Add(estoque);
            _context.SaveChanges();
            return estoque.Id;
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

        public void AtualizarEstadoPedido(int id, EstadoPedido estado)
        {
            _context.Pedidos.Single(s => s.Id == id).Estado = estado;
        }

        public Estoque BuscarEstoquePorProduto(int id)
        {
            return _context.Estoques.SingleOrDefault(s => s.Produto.Id == id);
        }

        public Produto BuscarProduto(int id)
        {
            return _context.Produtos.Single(s => s.Id == id);
        }
    }
}
