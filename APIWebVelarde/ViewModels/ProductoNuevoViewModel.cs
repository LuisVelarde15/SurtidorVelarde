using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebVelarde.ViewModels
{
    public class ProductoNuevoViewModel
    {
        public int idcategoria { get; set; } // llave foranea
        public string codigo { get; set; }
        public string nombre { get; set; }
        public decimal precio_venta { get; set; }
        public int existencia { get; set; }
        public string descripcion { get; set; }

        public ProductoNuevoViewModel()
        {
        }
    }
}
