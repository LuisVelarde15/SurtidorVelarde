using APIWebVelarde.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebVelarde.Models
{
    public class Clientes
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string rfc { get; set; }
        public bool activo { get; set; }
        public Clientes()
        {
        }
        public Clientes(string nombre, string direccion, string telefono, string email, string rfc, bool activo)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.email = email;
            this.rfc = rfc;
            this.activo = true;
        }
        public Clientes(ClientesViewModel c)
        {
            this.nombre = c.nombre;
            this.direccion = c.direccion;
            this.telefono = c.telefono;
            this.email = c.email;
            this.rfc = c.rfc;
            this.activo = true;
        }

    }
}
