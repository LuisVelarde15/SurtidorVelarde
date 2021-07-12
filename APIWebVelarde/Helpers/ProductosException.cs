using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebVelarde.Helpers
{
    public class ProductosException : Exception
    { 
        public ProductosException(string Mensaje) : base(Mensaje)
        {

        }
    }
}
