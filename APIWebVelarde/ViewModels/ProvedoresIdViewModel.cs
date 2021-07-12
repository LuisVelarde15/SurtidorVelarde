using APIWebVelarde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebVelarde.ViewModels
{
    public class ProvedoresIdViewModel
    {

        public int id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string rfc { get; set; }
        public ProvedoresIdViewModel()
        {
        }
        public ProvedoresIdViewModel(string nombre, string direccion, string telefono, string email, string rfc)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.email = email;
            this.rfc = rfc;
        }
        public ProvedoresIdViewModel(Provedores p)
        {
            this.id = p.id;
            this.nombre = p.nombre;
            this.direccion = p.direccion;
            this.telefono = p.telefono;
            this.email = p.email;
            this.rfc = p.rfc;
        }
    }
}
