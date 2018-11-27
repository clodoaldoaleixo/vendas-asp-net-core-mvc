using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VendasMVC.Models
{
    [Serializable]
    public class Vendedor
    {
        public Vendedor()
        {
        }

        public Vendedor(int id, string nome, string email, DateTime dataNascimento, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public int Id { get; set; }

        [Display(Name = "Nome do Vendedor")]
        [Required(ErrorMessage ="{0} Obrigatório")]
        [StringLength(60, MinimumLength = 3,ErrorMessage = "Campo {0} tem máximo de caracteres é 60 e o mínimo 3")]
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} Obrigatório")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "{0} Obrigatório")]
        [Display(Name = "Salário Base")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double SalarioBase { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<Venda> Vendas { get; set; }

        public void AdicionarVenda(Venda venda)
        {
            Vendas.Add(venda);
        }

        public void RemoverVenda(Venda venda)
        {
            Vendas.Remove(venda);
        }

        public double TotalVendas(DateTime dtInicial, DateTime dtFinal)
        {
            return Vendas.Where(x => x.Data >= dtInicial && x.Data <= dtFinal).Sum(x => x.Valor);
        }
    }
}
