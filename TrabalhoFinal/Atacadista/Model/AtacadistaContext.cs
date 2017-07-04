using Microsoft.EntityFrameworkCore;

namespace Atacadista.Model
{
    public class AtacadistaContext : DbContext
    {
        public AtacadistaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }
    }
}