using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebVelarde.Helpers
{
    public class ProvedoresException : Exception
    {
        public ProvedoresException(string Mensaje) : base(Mensaje)
        {

        }
    }
}
