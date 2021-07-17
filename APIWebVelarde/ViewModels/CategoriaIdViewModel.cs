using APIWebVelarde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebVelarde.ViewModels
{
    public class CategoriaIdViewModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }
        public CategoriaIdViewModel()
        { 
        }

        public CategoriaIdViewModel(int id,string nombre, string descripcion, bool activo)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.activo = activo;
        }
        public CategoriaIdViewModel(Categoria c)
        {
            
            this.nombre = c.nombre;
            this.descripcion = c.descripcion;

        }
        
    }
}
