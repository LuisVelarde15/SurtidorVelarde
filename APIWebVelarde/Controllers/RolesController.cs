using APIWebVelarde.Helpers;
using APIWebVelarde.Models;
using APIWebVelarde.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWebVelarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        Datos db = new Datos();//Conexion a la BD global a la base de datos para todos los metodos
        Respuesta resultado = new Respuesta();

        // GET: api/Categorias/Todos
        [HttpGet("Todos los Roles")]
        public ActionResult<string> BuscarTodos()
        {
            try
            {
                List<RolesIdViewModel> lista = new List<RolesIdViewModel>();

                foreach (Roles r in db.Roles)
                {
                    lista.Add(new RolesIdViewModel(r));
                }
                if (lista.Count == 0)
                {
                    throw new RolesException("No tenemos Roles para mostrar");
                    throw new RolesException("Inserte Roles para poder mostrarlas");
                }
                resultado.Info = lista;
            }
            catch (RolesException ex)
            {
                resultado.Estado = false;
                resultado.Mensaje = ex.Message;
            }
            catch (Exception)
            {
                resultado.Estado = false;
                resultado.Mensaje = "Se precento un error, consulte al Administrador";
                //ex.Message; muestra todos los detalles del error solo se puede ver por el Administrador
            }
            return Ok(resultado);
        }

        // GET api/CategoriasporId
        [HttpGet("BuscarRoles{id}")]
        public ActionResult BuscarId(int id)
        {
            try
            {
                Roles BuscarRoles = db.Roles.Find(id);
                if (BuscarRoles != null)
                {
                    resultado.Info = new RolesIdViewModel(BuscarRoles);
                }
                else
                {
                    throw new RolesException("El Rol no fue encontrado");
                }
            }
            catch (RolesException ex)
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
        [HttpPost("NuevoRol")]
        public ActionResult Nuevo([FromBody] RolesViewModel r)
        {
            try
            {
                Roles nueva = new Roles(r);//No le muestro el ID para que no lo cambie ni la variable Activo
                db.Roles.Add(nueva);
                db.SaveChanges();
                resultado.Info = new RolesViewModel(nueva);//Muestro el ID junto con los datos nuevos agregados

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
        [HttpPut("ActualizarRol{id}")]
        public ActionResult Actualizar(int id, [FromBody] Roles r)
        {
            try
            {
                Roles BuscarRol = db.Roles.Find(id);

                if (BuscarRol != null)
                {
                    BuscarRol.nombre = r.nombre;
                    BuscarRol.descripcion = r.descripcion;
                    db.SaveChanges();
                    resultado.Info = new RolesIdViewModel(BuscarRol);
                }
                else
                {
                    throw new Exception("El Rol no fue encontrado");
                }
            }
            catch (RolesException ex)
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
        [HttpDelete("InactivarRol{id}")]
        public ActionResult Inactivar(int id)
        {
            try
            {
                Roles BuscarRol = db.Roles.Find(id);

                if (BuscarRol != null)
                {
                    BuscarRol.activo = false;
                    db.SaveChanges();
                    resultado.Info = new RolesViewModel(BuscarRol);
                }
                else
                {
                    throw new Exception("El Rol no fue encontrado");
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
        [HttpDelete("ActivarRol{id}")]
        public ActionResult Activar(int id)
        {
            try
            {
                Roles BuscarRol = db.Roles.Find(id);

                if (BuscarRol != null)
                {
                    BuscarRol.activo = true;
                    db.SaveChanges();
                    resultado.Info = new RolesViewModel(BuscarRol);
                }
                else
                {
                    throw new Exception("El Rol no fue encontrada");
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
                Roles BuscarRol = db.Roles.Find(id);

                if (BuscarRol != null)
                {
                    db.Roles.Remove(BuscarRol);
                    db.SaveChanges();
                    resultado.Info = new RolesViewModel(BuscarRol);
                }
                else
                {
                    throw new Exception("El Rol no fue encontrado");
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
