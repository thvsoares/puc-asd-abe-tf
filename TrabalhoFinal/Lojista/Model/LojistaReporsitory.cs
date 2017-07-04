﻿using System.Collections.Generic;
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
    }
}
