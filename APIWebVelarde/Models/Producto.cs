﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebVelarde.Models
{
    public class Producto
    {
        public int id { get; set; }

        [ForeignKey("categoria")]
        public int idcategoria { get; set; }//Llave Foranea
        public string codigo{ get; set; }
        public string nombre { get; set; }
        public decimal precio_venta { get; set; }
        public int existencia { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }
        public Categoria categoria { get; set; }//Objeto de relacion a Categoria


        public Producto()
        {
        }



    }
}
