using APIWebVelarde.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebVelarde.Models
{
    public class Categoria
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Debe escribir el nombre")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "El campo {0} puede Debe de {2} a {1} letras")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Debe escribir el su puesto de trabajo")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "El campo {0} debe tener de {2} a {1} letras")]
        public string descripcion { get; set; }
        public bool activo { get; set; }
        public Categoria()
        {
        }

        public Categoria(string nombre, string descripcion, bool activo)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.activo = activo;
        }
        public Categoria(CategoriaViewModel c)
        {
            this.nombre = c.nombre;
            this.descripcion = c.descripcion;
        }
       
    }
}
