using Microsoft.EntityFrameworkCore;

namespace Lojista.Model
{
    public class LojistaContext : DbContext
    {
        public LojistaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }
    }
}