using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojista.Model
{
    public class LojistaReporsitory : ILojistaRepository
    {
        private LojistaContext _context;

        public LojistaReporsitory(LojistaContext context)
        {
            _context = context;
        }

        public List<Estoque> ConsultarEstoque()
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
    }
}
