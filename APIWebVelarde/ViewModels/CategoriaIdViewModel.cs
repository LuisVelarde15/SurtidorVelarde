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
        public CategoriaIdViewModel()
        { 
        }

        public CategoriaIdViewModel(string nombre, string descripcion)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
        }
        public CategoriaIdViewModel(Categoria c)
        {
            this.id = c.id;
            this.nombre = c.nombre;
            this.descripcion = c.descripcion;

        }
        
    }
}
