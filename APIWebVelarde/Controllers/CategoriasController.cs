using APIWebVelarde.Helpers;
using APIWebVelarde.Models;
using APIWebVelarde.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWebVelarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        Datos db = new Datos();//Conexion a la BD global a la base de datos para todos los metodos
        Respuesta resultado = new Respuesta();

        // GET: api/Categorias/Todos
        [HttpGet("Todas las Categorias")]
        public ActionResult<string> BuscarTodos()
        {
            //return new string[] { "Jose", "Jorge","Luis" };            
            // var json = db.Categorias;
            try
            {
                List<CategoriaIdViewModel> lista = new List<CategoriaIdViewModel>();

                foreach (Categoria c in db.Categorias)
                {
                    lista.Add(new CategoriaIdViewModel(c));
                }
                if (lista.Count == 0)
                {
                    throw new CategoriaException("No tenemos categorias para mostrar");
                    throw new CategoriaException("Inserte categorias para poder mostrarlas");
                }
                resultado.Info = lista;
            }
            catch (CategoriaException ex)
            {
                resultado.Estado = false;
                resultado.Mensaje = ex.Message;
            }
            catch(Exception)
            {
                resultado.Estado = false;
                resultado.Mensaje = "Se precento un error, consulte al Administrador";
                //ex.Message; muestra todos los detalles del error solo se puede ver por el Administrador
            }      
            return Ok(resultado);
        }

        // GET api/CategoriasporId
        [HttpGet("BuscarCategorias{id}")]
        public ActionResult BuscarId(int id)
        {
            try
            {
                Categoria Buscarcategoria = db.Categorias.Find(id);
                if (Buscarcategoria != null)
                {
                    resultado.Info =new CategoriaIdViewModel( Buscarcategoria);
                }
                else
                {
                    throw new CategoriaException("Categoria no encontrada");
                }
            }
            catch(CategoriaException ex)
            {
                resultado.Mensaje = ex.Message;
                resultado.Estado = false;
            }
            catch (Exception)
            {
                resultado.Estado = false;
                resultado.Mensaje = "Error en el sistema, consulte al Administrador";
            }
            return Ok(resultado);
            
        }

        // POST api/Categorias/NuevoRegistro
        [HttpPost("NuevaCategorias")]
        public ActionResult Nuevo([FromBody] CategoriaViewModel c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Categoria nueva = new Categoria(c);//No le muestro el ID para que no lo cambie ni la variable Activo
                    db.Categorias.Add(nueva);
                    db.SaveChanges();
                    resultado.Info = new CategoriaIdViewModel(nueva);//Muestro el ID junto con los datos nuevos agregados
                }
                else
                {
                    resultado.Estado = false;
                    string MensajeError = "";
                    
                    foreach(var error in ModelState.Values)
                    {
                        MensajeError += ( error.Errors[0].ErrorMessage);
                        MensajeError += "  |  ";
                    }
                    resultado.Mensaje = MensajeError; ;
                }

            }
            catch (Exception)
            {
                resultado.Estado = false;
                resultado.Mensaje = "Se precento un error, consulte al Administrador";
                //ex.Message; muestra todos los detalles del error solo se puede ver por el Administrador
            }

            return Ok(resultado);
        }

        // PUT api/Categorias/ActualizarRegistro
        [HttpPut("ActualizarCategorias{id}")]
        public ActionResult Actualizar(int id, [FromBody] Categoria c)
        {
            try
            {
                Categoria Buscacategoria = db.Categorias.Find(id);

                if (Buscacategoria != null)
                {
                    Buscacategoria.nombre = c.nombre;
                    Buscacategoria.descripcion = c.descripcion;
                    db.SaveChanges();
                    resultado.Info = new CategoriaIdViewModel(Buscacategoria);
                }
                else
                {
                    throw new Exception("La categoria no fue encontrada");
                }
            }
            catch (CategoriaException ex)
            {
                resultado.Mensaje = ex.Message;
                resultado.Estado = false;
            }
            catch (Exception)
            {
                resultado.Estado = false;
                resultado.Mensaje = "Error en el sistema, consulte al Administrador";
            }
            return Ok(resultado);


        }

        // DELETE api/<CategoriasController>/5
        [HttpDelete("InactivarCategorias{id}")]
        public ActionResult Inactivar(int id)
        {
            try
            {
                Categoria Buscacategoria = db.Categorias.Find(id);

                if (Buscacategoria != null)
                {
                    Buscacategoria.activo = false;
                    db.SaveChanges();
                    resultado.Info = new CategoriaViewModel( Buscacategoria);
                }
                else
                {
                    throw new Exception("La categoria no fue encontrada");
                }
            }
            catch (CategoriaException ex)
            {
                resultado.Mensaje = ex.Message;
                resultado.Estado = false;
            }
            catch (Exception)
            {
                resultado.Estado = false;
                resultado.Mensaje = "Error en el sistema, consulte al Administrador";
            }
            return Ok(resultado);
        }

        // DELETE api/<CategoriasController>/5
        [HttpDelete("ActivarCategorias{id}")]
        public ActionResult Activar(int id)
        {
            try
            {
                Categoria Buscacategoria = db.Categorias.Find(id);

                if (Buscacategoria != null)
                {
                    Buscacategoria.activo = true;
                    db.SaveChanges();
                    resultado.Info = new CategoriaViewModel(Buscacategoria);
                }
                else
                {
                    throw new Exception("La categoria no fue encontrada");
                }
            }
            catch (CategoriaException ex)
            {
                resultado.Mensaje = ex.Message;
                resultado.Estado = false;
            }
            catch (Exception)
            {
                resultado.Estado = false;
                resultado.Mensaje = "Error en el sistema, consulte al Administrador";
            }
            return Ok(resultado);
        }

        // DELETE api/<CategoriasController>/5
        [HttpDelete("EliminarCategorias{id}")]
        public ActionResult Eliminar(int id)
        {
            try
            {
                Categoria Buscacategoria = db.Categorias.Find(id);

                if (Buscacategoria != null)
                {
                    db.Categorias.Remove(Buscacategoria);
                    db.SaveChanges();
                    resultado.Info = new CategoriaViewModel(Buscacategoria);
                }
                else
                {
                    throw new Exception("La categoria no fue encontrada");
                }
            }
            catch (CategoriaException ex)
            {
                resultado.Mensaje = ex.Message;
                resultado.Estado = false;
            }
            catch (Exception)
            {
                resultado.Estado = false;
                resultado.Mensaje = "Error en el sistema, consulte al Administrador";
            }
            return Ok(resultado);
        }
    }
}
