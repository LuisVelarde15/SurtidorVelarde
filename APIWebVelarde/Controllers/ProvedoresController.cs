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
    public class ProvedoresController : ControllerBase
    {
        Datos db = new Datos();//Conexion a la BD global a la base de datos para todos los metodos
        Respuesta resultado = new Respuesta();
        // GET: api/<ProveedoresController>
        [HttpGet("Todos los Proveedores")]
        public ActionResult<string> BuscarTodos()
        {
            try
            {
                List<ProvedoresIdViewModel> lista = new List<ProvedoresIdViewModel>();

                foreach (Provedores p in db.Proveedores)
                {
                    lista.Add(new ProvedoresIdViewModel(p));
                }
                if (lista.Count == 0)
                {
                    throw new ProvedoresException("No tenemos Proveedores para mostrar");
                    throw new ProvedoresException("Inserte Proveedores para poder mostrarlos");
                }
                resultado.Info = lista;
            }
            catch (ProvedoresException ex)
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
        [HttpGet("BuscarProveedor{id}")]
        public ActionResult BuscarId(int id)
        {
            try
            {
                Provedores BuscarProveedor = db.Proveedores.Find(id);
                if (BuscarProveedor != null)
                {
                    resultado.Info = new ProvedoresIdViewModel(BuscarProveedor);
                }
                else
                {
                    throw new ProvedoresException("El Proveedor no fue encontrado");
                }
            }
            catch (ProvedoresException ex)
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

        // POST api/Proveedores/NuevoProveedor
        [HttpPost("NuevoProveedor")]
        public ActionResult Nuevo([FromBody] ProvedoresViewModel p)
        {
            try
            {
                Provedores nueva = new Provedores(p);//No le muestro el ID para que no lo cambie ni la variable Activo
                db.Proveedores.Add(nueva);
                db.SaveChanges();
                resultado.Info = new ProvedoresIdViewModel(nueva);//Muestro el ID junto con los datos nuevos agregados

            }
            catch (Exception)
            {
                resultado.Estado = false;
                resultado.Mensaje = "Se precento un error, consulte al Administrador";
                //ex.Message; muestra todos los detalles del error solo se puede ver por el Administrador
            }
            return Ok(resultado);
        }

        // PUT api/Proveedores/ActualizarProveedor
        [HttpPut("ActualizarProveedor{id}")]
        public ActionResult Actualizar(int id, [FromBody] Provedores p)
        {
            try
            {
                Provedores BuscarProvedores = db.Proveedores.Find(id);

                if (BuscarProvedores != null)
                {
                    BuscarProvedores.nombre = p.nombre;
                    BuscarProvedores.direccion = p.direccion;
                    BuscarProvedores.telefono = p.telefono;
                    BuscarProvedores.email = p.email;
                    BuscarProvedores.rfc = p.rfc;

                    db.SaveChanges();
                    resultado.Info = new ProvedoresIdViewModel(BuscarProvedores);
                }
                else
                {
                    throw new Exception("El Proveedor no fue encontrado");
                }
            }
            catch (ProvedoresException ex)
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
        [HttpDelete("InactivarProveedor{id}")]
        public ActionResult Inactivar(int id)
        {
            try
            {
                Provedores BuscarProvedores = db.Proveedores.Find(id);

                if (BuscarProvedores != null)
                {
                    BuscarProvedores.activo = false;
                    db.SaveChanges();
                    resultado.Info = new ProvedoresViewModel(BuscarProvedores);
                }
                else
                {
                    throw new Exception("El Proveedor no fue encontrado");
                }
            }
            catch (ProvedoresException ex)
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
        [HttpDelete("ActivarProveedor{id}")]
        public ActionResult Activar(int id)
        {
            try
            {
                Provedores BuscarProvedor = db.Proveedores.Find(id);

                if (BuscarProvedor != null)
                {
                    BuscarProvedor.activo = true;
                    db.SaveChanges();
                    resultado.Info = new ProvedoresViewModel(BuscarProvedor);
                }
                else
                {
                    throw new Exception("El Proveedor no fue encontrada");
                }
            }
            catch (ProvedoresException ex)
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
        [HttpDelete("EliminarProveedor{id}")]
        public ActionResult Eliminar(int id)
        {
            try
            {
                Provedores BuscarProvedores = db.Proveedores.Find(id);

                if (BuscarProvedores != null)
                {
                    db.Proveedores.Remove(BuscarProvedores);
                    db.SaveChanges();
                    resultado.Info = new ProvedoresViewModel(BuscarProvedores);
                }
                else
                {
                    throw new Exception("El Proveedor no fue encontrado");
                }
            }
            catch (ProvedoresException ex)
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
