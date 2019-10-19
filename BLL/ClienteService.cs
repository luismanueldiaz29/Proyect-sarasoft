using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using Entity;
using Oracle.ManagedDataAccess.Client;

namespace BLL {
    public class ClienteService {
        ClienteRepository clienteRepositorio;
        OracleConnection conexion;

        public ClienteService() {
            string cadena = "Data Source=localhost:1521/xepdb1;User Id=sarasoft;Password=1234";
            conexion = new OracleConnection(cadena);
            clienteRepositorio = new ClienteRepository(conexion);
        }
        public Respuesta Guardar(Cliente cliente)
        {
            
            var Respuesta = new Respuesta();
            Respuesta.IsError = false;
            try
            {
                conexion.Open();
                clienteRepositorio.Guardar(cliente);
                Respuesta.Mensaje = $"Se registro satisfactoriamente el cliente {cliente.Nombre1 +" "+ cliente.Apellido1}";
                return Respuesta;
            }
            catch (Exception e)
            {
                conexion.Close();
                Respuesta.IsError = true;
                Respuesta.Mensaje = "Error de Base de Datos:" + e.Message.ToString();
                return Respuesta;
            }
            finally
            {
                conexion.Close();

            }

        }

        public Respuesta Modificar(Cliente cliente) {
            var respuesta = new Respuesta();
            try {
                conexion.Open();
                clienteRepositorio.Modificar(cliente);
                conexion.Close();
                respuesta.Mensaje = "La información fue modificada correctamente";
                return respuesta;
            } catch (Exception ex) {
                respuesta.Mensaje = ex.ToString();
                conexion.Close();
                return respuesta;
            }
        }

        public Respuesta Eliminar(string cedula) {
            var respuesta = new Respuesta();
            try {
                conexion.Open();
                clienteRepositorio.Eliminar(cedula);
                respuesta.Mensaje = "La informacion fue Eliminada de forma correcta";
                conexion.Close();
                return respuesta;
            } catch (Exception ex) {
                respuesta.Mensaje = ex.ToString();
                conexion.Close();
                return respuesta;
            }
        }

        public Respuesta Consultar()
        {
            Respuesta respuesta = new Respuesta();
            
            respuesta.IsError = false;
            
            try
            {
                conexion.Open();
                respuesta.Clientes = clienteRepositorio.Consultar();
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.IsError = true;
                respuesta.Mensaje = "Error de Base de Datos:" + e.Message.ToString();
                return respuesta;
            }
            finally
            {
                conexion.Close();
            }
        }
        public Respuesta Buscar(string nombre)
        {
            Respuesta respuesta = new Respuesta();

            respuesta.IsError = false;

            try
            {
                conexion.Open();
                respuesta.Clientes = clienteRepositorio.Buscar(nombre);
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.IsError = true;
                respuesta.Mensaje = "Error de Base de Datos:" + e.Message.ToString();
                return respuesta;
            }
            finally
            {
                conexion.Close();
            }
        }

        public class Respuesta
        {
            public IList<Cliente> Clientes { get; set; }
            public string Mensaje { get; set; }
            public bool IsError { get; set; }
        }
    }
}
