using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasMVC.Services.Exceptions
{
    public class IntegridadeException : Exception
    {
        public IntegridadeException(string mensagem) : base(mensagem)
        {
        }
    }
}
