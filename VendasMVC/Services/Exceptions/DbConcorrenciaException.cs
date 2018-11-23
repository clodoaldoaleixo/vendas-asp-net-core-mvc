using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasMVC.Services.Exceptions
{
    public class DbConcorrenciaException : Exception
    {
        public DbConcorrenciaException(string mensagem) : base(mensagem){ }
    }
}
