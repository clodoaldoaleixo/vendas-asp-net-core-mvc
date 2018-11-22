using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasMVC.Models
{
    public class Venda
    {
        public Venda()
        {
        }

        public Venda(int id, DateTime data, double valor, StatusVenda status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Valor = valor;
            Status = status;
            Vendedor = vendedor;
        }

        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public StatusVenda Status { get; set; }
        public Vendedor Vendedor { get; set; }
    }

    public enum StatusVenda : int
    {
        Pendente = 0,
        Concluida = 1,
        Cancelada = 2
    }
}
