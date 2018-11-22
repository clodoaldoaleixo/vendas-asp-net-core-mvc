using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VendasMVC.Models
{
    public class VendasMVCContext : DbContext
    {
        public VendasMVCContext (DbContextOptions<VendasMVCContext> options)
            : base(options)
        {
        }

        public DbSet<VendasMVC.Models.Departamento> Departamento { get; set; }
        public DbSet<VendasMVC.Models.Venda> Venda { get; set; }
        public DbSet<VendasMVC.Models.Vendedor> Vendedor { get; set; }
    }
}
