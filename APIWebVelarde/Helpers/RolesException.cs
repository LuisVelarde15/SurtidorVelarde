using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebVelarde.Helpers
{
    public class RolesException : Exception
    {
        public RolesException(string Mensaje) : base(Mensaje)
        {

        }
    }
}
