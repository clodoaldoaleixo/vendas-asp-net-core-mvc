using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VendasMVC.Models
{
    [Serializable]
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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
    
        [DisplayFormat(DataFormatString = "{0:C2}")]
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
