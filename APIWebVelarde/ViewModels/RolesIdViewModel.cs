using APIWebVelarde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebVelarde.ViewModels
{
    public class RolesIdViewModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public RolesIdViewModel()
        {
        }

        public RolesIdViewModel(string nombre, string descripcion)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
        }
        public RolesIdViewModel(Roles r)
        {
            this.id = r.id;
            this.nombre = r.nombre;
            this.descripcion = r.descripcion;

        }
    }
}
