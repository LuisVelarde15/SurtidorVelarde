using APIWebVelarde.Helpers;
using APIWebVelarde.Models;
using APIWebVelarde.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWebVelarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        Datos db = new Datos();
        Respuesta Resultado = new Respuesta();
        /*
        // GET: api/<ProductosController>
        [HttpGet("Todos los podructos")]
        public ActionResult MostrarTodos()
        {

            var pro = db.Productos.Include(c=> c.categoria);

            var lista = pro.Select(p => new ProductosViewModel
                {
                    id = p.id,
                    nombre = p.nombre,
                    codigo = p.codigo,
                    descripcion = p.descripcion,
                    existencia = p.existencia,
                    idcategoria = p.idcategoria,
                    nombre_categoria = p.categoria.nombre
                }
            );;

            Resultado.Info = lista;

            return Ok(Resultado);
        }
        */


        // GET: api/values
        [HttpGet("Mostrar [action]")]
        public ActionResult Todos()
        {
            Datos db = new Datos();
            Respuesta Resultado = new Respuesta();

            var prod = db.Productos;// .Include(c => c.categoria);
            var lista = prod.Select(p => new ProductosViewModel
                {
                    id = p.id,
                    nombre = p.nombre,
                    codigo = p.codigo,
                    descripcion = p.descripcion,
                    existencia = p.existencia,
                    idcategoria = p.idcategoria,
                }
             );

            Resultado.Info = lista;
            return Ok(Resultado);

        }

        [HttpGet("Mostrar [action]")]
        public ActionResult Todos2()
        {
            Datos db = new Datos();
            Respuesta Resultado = new Respuesta();


            var prod = (from p in db.Productos
                        join c in db.Categorias on p.idcategoria equals c.id
                        orderby p.nombre ascending
                        select new
                        {
                            p.codigo,
                            p.nombre,
                            p.descripcion,
                            p.existencia,
                            p.precio_venta,
                            p.idcategoria,
                            nombre_categoria = c.nombre
                        });


            Resultado.Info = prod;

            return Ok(Resultado);

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET api/values/5
        [HttpGet("[action]/{nombre}")]
        public ActionResult BuscarNombre(string nombre)
        {
            Respuesta Resultado = new Respuesta();

            Datos db = new Datos();

            var BuscarProducto = (from p in db.Productos
                                  join c in db.Categorias
                                         on p.idcategoria equals c.id
                                  where p.nombre.Contains(nombre)
                                  select new
                                  {
                                      p.id,
                                      p.nombre,
                                      p.existencia,
                                      p.precio_venta,
                                      nombre_categoria = c.nombre
                                  }).ToList();


            Resultado.Info = BuscarProducto;

            return Ok(Resultado);
        }


        // POST api/values
        [HttpPost("Agregar [action] producto")]
        public ActionResult Nuevo([FromBody] ProductoNuevoViewModel p)
        {
            Respuesta Resultado = new Respuesta();
            Datos db = new Datos();

            Producto nuevo = new Producto(p);

            db.Productos.Add(nuevo);
            db.SaveChanges();

            return Ok(Resultado);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
