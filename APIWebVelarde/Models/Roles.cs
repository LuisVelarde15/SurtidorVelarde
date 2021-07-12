using APIWebVelarde.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebVelarde.Models
{
    public class Roles
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }
        public Roles()
        {
        }

        public Roles(string nombre, string descripcion, bool activo)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.activo = activo;
        }
        public Roles(RolesViewModel r)
        {
            this.nombre = r.nombre;
            this.descripcion = r.descripcion;
            this.activo = true;
        }
    }
}
