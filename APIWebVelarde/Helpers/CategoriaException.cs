using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebVelarde.Helpers
{
    public class CategoriaException : Exception
    {
        public CategoriaException(string Mensaje) : base(Mensaje)
        {

        }
    }
}
