using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Lojista.Model
{
    public class LojistaContext : DbContext
    {
        public LojistaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Estoque> Estoque { get; set; }
    }
}
