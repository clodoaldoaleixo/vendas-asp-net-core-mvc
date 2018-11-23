using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasMVC.Services.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string mensagem) : base(mensagem) { }
    }
}
