using APIWebVelarde.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebVelarde.Models
{
    public class Provedores
    {

        public int id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string rfc { get; set; }
        public bool activo { get; set; }
        public Provedores()
        {
        }
        public Provedores(string nombre, string direccion, string telefono, string email, string rfc, bool activo)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.email = email;
            this.rfc = rfc;
            this.activo = true;
        }
        public Provedores(ProvedoresViewModel p)
        {
            this.nombre = p.nombre;
            this.direccion = p.direccion;
            this.telefono = p.telefono;
            this.email = p.email;
            this.rfc = p.rfc;
            this.activo = true;
        }
    }
}
