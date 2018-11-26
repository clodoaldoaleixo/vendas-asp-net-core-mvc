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

        public async Task<List<Vendedor>> ListarAsync()
        {
            return await _contexto.Vendedor.Include("Departamento").OrderBy(x => x.Nome).ToListAsync();
        }

        public Vendedor Pesquisar(int? id)
        {
            return _contexto.Vendedor.Include("Departamento").FirstOrDefault(x => x.Id == id);
        }

        public async Task<Vendedor> PesquisarAsync(int? id)
        {
            return await _contexto.Vendedor.Include("Departamento").FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Gravar(Vendedor vendedor)
        {
            _contexto.Vendedor.Add(vendedor);
            _contexto.SaveChanges();
        }

        public async Task GravarAsync(Vendedor vendedor)
        {
            _contexto.Vendedor.Add(vendedor);
            await _contexto.SaveChangesAsync();
        }

        public void Deletar(int? id)
        {
            var obj = _contexto.Vendedor.Find(id);
            _contexto.Vendedor.Remove(obj);
            _contexto.SaveChanges();
        }

        public async Task DeletarAsync(int? id)
        {
            var obj = await _contexto.Vendedor.FindAsync(id);
            _contexto.Vendedor.Remove(obj);
            await _contexto.SaveChangesAsync();
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

        public async Task AtualizarAsync(Vendedor vendedor)
        {
            var existe = await _contexto.Vendedor.AnyAsync(x => x.Id == vendedor.Id);

            if (!existe)
            {
                throw new NotFoundException("Vendedor não encontrado");
            }

            try
            {
                _contexto.Vendedor.Update(vendedor);
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DbConcorrenciaException("Há outro usuário atualizando o mesmo registro.");
            }

        }
    }
}
