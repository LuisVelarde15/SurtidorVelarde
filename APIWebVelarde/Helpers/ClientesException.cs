using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebVelarde.Helpers
{
    public class ClientesException : Exception
    {
        public ClientesException(string Mensaje) : base(Mensaje)
        {

        }
    }
}
