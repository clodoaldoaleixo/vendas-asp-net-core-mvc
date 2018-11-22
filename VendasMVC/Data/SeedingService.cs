using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMVC.Models;

namespace VendasMVC.Data
{
    public class SeedingService
    {
        private VendasMVCContext _contexto;

        public SeedingService(VendasMVCContext contexto)
        {
            _contexto = contexto;
        }

        public void Seed()
        {
            if (_contexto.Departamento.Any() || _contexto.Venda.Any() || _contexto.Vendedor.Any())
            {
                return;
            }

            Departamento d1 = new Departamento(1, "Computadores");
            Departamento d2 = new Departamento(2, "Eletronicos");
            Departamento d3 = new Departamento(3, "Moda");
            Departamento d4 = new Departamento(4, "Livros");

            Vendedor v1 = new Vendedor(1, "Michelle Amorim", "michelle@gmail.com", new DateTime(1980, 1, 25), 2000, d1);
            Vendedor v2 = new Vendedor(2, "Ruth Monteiro", "ruth@gmail.com", new DateTime(1970, 10, 12), 3800, d1);

            Vendedor v3 = new Vendedor(3, "Simone Santos", "simone@gmail.com", new DateTime(1974, 2, 25), 1780, d2);
            Vendedor v4 = new Vendedor(4, "Michelle Souza Evangelista", "michelleevangalista@gmail.com", new DateTime(1995, 4, 20), 2480, d2);

            Vendedor v5 = new Vendedor(5, "Michelle Amorim", "michelle@gmail.com", new DateTime(1989, 5, 10), 3470, d3);
            Vendedor v6 = new Vendedor(6, "Michelle Amorim", "michelle@gmail.com", new DateTime(1992, 10, 05), 1650, d3);

            Vendedor v7 = new Vendedor(7, "Michelle Amorim", "michelle@gmail.com", new DateTime(1993, 4, 12), 4800, d4);
            Vendedor v8 = new Vendedor(8, "Michelle Amorim", "michelle@gmail.com", new DateTime(1995, 5, 14), 6200, d4);

            Venda ve1 = new Venda(1, new DateTime(2018, 10, 01), 1100, StatusVenda.Concluida,v1);
            Venda ve2 = new Venda(2, new DateTime(2018, 10, 10), 2200, StatusVenda.Concluida, v2);
            Venda ve3 = new Venda(3, new DateTime(2018, 10, 15), 3300, StatusVenda.Concluida, v3);
            Venda ve4 = new Venda(4, new DateTime(2018, 10, 18), 2450, StatusVenda.Concluida, v4);
            Venda ve5 = new Venda(5, new DateTime(2018, 10, 20), 10810, StatusVenda.Concluida, v5);
            Venda ve6 = new Venda(6, new DateTime(2018, 10, 28), 7875, StatusVenda.Concluida, v6);

            _contexto.Departamento.AddRange(d1, d2, d3, d4);
            _contexto.Vendedor.AddRange(v1, v2, v3, v4, v5, v6, v7, v8);
            _contexto.Venda.AddRange(ve1, ve2, ve3, ve4, ve5, ve6);

            _contexto.SaveChanges();
        }
    }
}
