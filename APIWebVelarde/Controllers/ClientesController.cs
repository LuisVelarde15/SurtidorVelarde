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
    public class ClientesController : ControllerBase
    {
        Datos db = new Datos();//Conexion a la BD global a la base de datos para todos los metodos
        Respuesta resultado = new Respuesta();
        // GET: api/<ClientesController>
        [HttpGet("Todos los clientes")]
        public ActionResult<string> BuscarTodos()
        {
            try
            {
                List<ClientesIdViewModel> lista = new List<ClientesIdViewModel>();

                foreach (Clientes c in db.Clientes)
                {
                    lista.Add(new ClientesIdViewModel(c));
                }
                if (lista.Count == 0)
                {
                    throw new ClientesException("No tenemos Clientes para mostrar");
                    throw new ClientesException("Inserte Clientes para poder mostrarlos");
                }
                resultado.Info = lista;
            }
            catch (ClientesException ex)
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
        [HttpGet("BuscarCliente{id}")]
        public ActionResult BuscarId(int id)
        {
            try
            {
                Clientes BuscarCliente = db.Clientes.Find(id);
                if (BuscarCliente != null)
                {
                    resultado.Info = new ClientesIdViewModel(BuscarCliente);
                }
                else
                {
                    throw new ClientesException("El Cliente no fue encontrado");
                }
            }
            catch (ClientesException ex)
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
        [HttpPost("NuevoCliente")]
        public ActionResult Nuevo([FromBody] ClientesViewModel c)
        {
            try
            {
                Clientes nueva = new Clientes(c);//No le muestro el ID para que no lo cambie ni la variable Activo
                db.Clientes.Add(nueva);
                db.SaveChanges();
                resultado.Info = new ClientesIdViewModel(nueva);//Muestro el ID junto con los datos nuevos agregados

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
        public ActionResult Actualizar(int id, [FromBody] Clientes c)
        {
            try
            {
                Clientes BuscarCliente = db.Clientes.Find(id);

                if (BuscarCliente != null)
                {
                    BuscarCliente.nombre = c.nombre;
                    BuscarCliente.direccion = c.direccion;
                    BuscarCliente.telefono = c.telefono;
                    BuscarCliente.email = c.email;
                    BuscarCliente.rfc = c.rfc;

                    db.SaveChanges();
                    resultado.Info = new ClientesIdViewModel(BuscarCliente);
                }
                else
                {
                    throw new Exception("El Cliente no fue encontrado");
                }
            }
            catch (ClientesException ex)
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
                Clientes BuscarCliente = db.Clientes.Find(id);

                if (BuscarCliente != null)
                {
                    BuscarCliente.activo = false;
                    db.SaveChanges();
                    resultado.Info = new ClientesViewModel(BuscarCliente);
                }
                else
                {
                    throw new Exception("El Cliente no fue encontrado");
                }
            }
            catch (ClientesException ex)
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
                Clientes BuscarClientes = db.Clientes.Find(id);

                if (BuscarClientes != null)
                {
                    BuscarClientes.activo = true;
                    db.SaveChanges();
                    resultado.Info = new ClientesViewModel(BuscarClientes);
                }
                else
                {
                    throw new Exception("El Clietne no fue encontrada");
                }
            }
            catch (ClientesException ex)
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
                Clientes BuscarCliente = db.Clientes.Find(id);

                if (BuscarCliente != null)
                {
                    db.Clientes.Remove(BuscarCliente);
                    db.SaveChanges();
                    resultado.Info = new ClientesViewModel(BuscarCliente);
                }
                else
                {
                    throw new Exception("El Cliente no fue encontrado");
                }
            }
            catch (ClientesException ex)
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
