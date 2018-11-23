using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMVC.Models;

namespace VendasMVC.Services
{
    public class DepartamentoService
    {
        private VendasMVCContext _contexto;

        public DepartamentoService(VendasMVCContext contexto)
        {
            _contexto = contexto;
        }

        public List<Departamento> Listar()
        {
            return _contexto.Departamento.OrderBy(x => x.Nome).ToList();
        }
    }
}
