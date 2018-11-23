using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMVC.Models;

namespace VendasMVC.Services
{
    public class VendedorService
    {
        private readonly VendasMVCContext _contexto;

        public VendedorService(VendasMVCContext contexto)
        {
            _contexto = contexto;
        }

        public List<Vendedor> Listar()
        {
            return _contexto.Vendedor.ToList();
        }

        public void Gravar(Vendedor vendedor)
        {
            _contexto.Vendedor.Add(vendedor);
            _contexto.SaveChanges();
        }
    }
}
