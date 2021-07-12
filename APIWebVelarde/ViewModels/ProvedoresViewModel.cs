using APIWebVelarde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebVelarde.ViewModels
{
    public class ProvedoresViewModel
    {

        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string rfc { get; set; }
        public ProvedoresViewModel()
        {
        }
        public ProvedoresViewModel(string nombre, string direccion, string telefono, string email, string rfc)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.email = email;
            this.rfc = rfc;
        }
        public ProvedoresViewModel(Provedores p)
        {
            this.nombre = p.nombre;
            this.direccion = p.direccion;
            this.telefono = p.telefono;
            this.email = p.email;
            this.rfc = p.rfc;
        }
    }
}
