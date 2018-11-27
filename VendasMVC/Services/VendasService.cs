using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace VendasMVC.Services
{
    public class VendasService
    {
        private readonly VendasMVCContext _contexto;

        public VendasService(VendasMVCContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Venda>> ListarPorDataAsync(DateTime? dtInicial, DateTime? dtFinal)
        {
            var consulta = from obj in _contexto.Venda select obj;

            if (dtInicial != null)
            {
                consulta = consulta.Where(x => x.Data >= dtInicial);
            }

            if (dtFinal != null)
            {
                consulta = consulta.Where(x => x.Data <= dtFinal);
            }

            return await consulta.Include(x => x.Vendedor).Include(x => x.Vendedor.Departamento).OrderByDescending(x => x.Data).ToListAsync();
        }
    }
}
