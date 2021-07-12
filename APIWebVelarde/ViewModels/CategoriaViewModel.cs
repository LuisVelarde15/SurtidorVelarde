using APIWebVelarde.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebVelarde.ViewModels
{
    public class CategoriaViewModel
    {
        [Required(ErrorMessage = "Debe escribir el campo nombre")]
        [StringLength(25,MinimumLength =5,ErrorMessage ="El campo {0} puede Debe de {2} a {1} letras")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Debe escribir el su puesto de trabajo")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "El campo {0} debe tener de {2} a {1} letras")]
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
