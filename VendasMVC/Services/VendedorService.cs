using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMVC.Models;
using Microsoft.EntityFrameworkCore;

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
            return _contexto.Vendedor.Include("Departamento").ToList();
        }

        public Vendedor Pesquisar(int? id)
        {
            return _contexto.Vendedor.Include("Departamento").FirstOrDefault(x => x.Id == id);
        }

        public void Gravar(Vendedor vendedor)
        {
            _contexto.Vendedor.Add(vendedor);
            _contexto.SaveChanges();
        }

        public void Deletar(int? id)
        {
            var obj = _contexto.Vendedor.Find(id);
            _contexto.Vendedor.Remove(obj);
            _contexto.SaveChanges();
            
        }
    }
}
