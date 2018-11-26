using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMVC.Models;
using VendasMVC.Services.Exceptions;
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
            return _contexto.Vendedor.Include("Departamento").OrderBy(x => x.Nome).ToList();
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

        public void Atualizar(Vendedor vendedor)
        {
            if (!_contexto.Vendedor.Any(x => x.Id == vendedor.Id))
            {
                throw new NotFoundException("Vendedor não encontrado");
            }

            try
            {
                _contexto.Vendedor.Update(vendedor);
                _contexto.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DbConcorrenciaException("Há outro usuário atualizando o mesmo registro.");
            }
            
        }
    }
}
