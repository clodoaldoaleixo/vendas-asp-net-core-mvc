using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace VendasMVC.Services
{
    public class DepartamentoService
    {
        private VendasMVCContext _contexto;

        public DepartamentoService(VendasMVCContext contexto)
        {
            _contexto = contexto;
        }

        /// <summary>
        /// Versão assincrona do método
        /// </summary>
        /// <returns></returns>
        public async Task<List<Departamento>> ListarAsync()
        {
            return await _contexto.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
