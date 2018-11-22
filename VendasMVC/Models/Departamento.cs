using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace VendasMVC.Models
{
    [Serializable]
    public class Departamento
    {
        public Departamento()
        {
        }

        public Departamento(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        [DisplayName("Código")]
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Vendedor> ListaVendedores { get; set; }
        
        public void AdicionarVendedor(Vendedor vendedor)
        {
            ListaVendedores.Add(vendedor);
        }

        public double TotalVendas(DateTime dtInicial, DateTime dtFinal)
        {
            return ListaVendedores.Sum(vendas => vendas.TotalVendas(dtFinal, dtFinal));
        }
    }
}
