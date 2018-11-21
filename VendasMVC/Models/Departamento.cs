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
        [DisplayName("Código")]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
