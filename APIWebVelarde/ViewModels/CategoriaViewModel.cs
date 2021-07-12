using APIWebVelarde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebVelarde.ViewModels
{
    public class CategoriaViewModel
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public CategoriaViewModel()
        {

        }

        public CategoriaViewModel(string nombre, string descripcion)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
        }
        public CategoriaViewModel(Categoria c)
        {
            this.nombre = c.nombre;
            this.descripcion = c.descripcion;
        }
       
    }
}
