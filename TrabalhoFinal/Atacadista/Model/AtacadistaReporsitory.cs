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

        public List<Orcamento> BuscarOrcamentos()
        {
            return _context.Pedidos
                .Where(w => w.Orcamento != null)
                .Select(s => s.Orcamento)
                .ToList();
        }

        public void MudarEstadoPedido(int id, EstadoPedido estado)
        {
            var pedido = _context.Pedidos.Single(s => s.Id == id);
            pedido.Estado = estado;
            _context.SaveChanges();
        }
    }
}
