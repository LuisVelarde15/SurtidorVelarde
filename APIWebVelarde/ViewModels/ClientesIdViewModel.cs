using APIWebVelarde.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebVelarde.ViewModels
{
    public class ClientesIdViewModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string rfc { get; set; }
        public ClientesIdViewModel()
        {
        }
        public ClientesIdViewModel(string nombre, string direccion, string telefono, string email, string rfc)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.email = email;
            this.rfc = rfc;
        }
        public ClientesIdViewModel(Clientes c)
        {
            this.id = c.id;
            this.nombre = c.nombre;
            this.direccion = c.direccion;
            this.telefono = c.telefono;
            this.email = c.email;
            this.rfc = c.rfc;
        }
    }
}
