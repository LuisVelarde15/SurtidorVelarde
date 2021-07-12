using APIWebVelarde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebVelarde.ViewModels
{
    public class RolesViewModel
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public RolesViewModel()
        {
        }

        public RolesViewModel(string nombre, string descripcion)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
        }
        public RolesViewModel(Roles r)
        {
            this.nombre = r.nombre;
            this.descripcion = r.descripcion;
        }
    }
}
