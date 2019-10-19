using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
using Oracle.ManagedDataAccess.Client;

namespace BLL {
    public class ProductoService {
        ProductoRepository productoRepositorio;
        OracleConnection conexion;
        public ProductoService() {
            string cadena = "Data Source=localhost:1521/xepdb1;User Id=sarasoft;Password=1234";
            conexion = new OracleConnection(cadena);
            productoRepositorio = new ProductoRepository(conexion);
        }


        public Respuesta Guardar(Producto producto) {

            var Respuesta = new Respuesta();
            Respuesta.IsError = false;
            try {
                conexion.Open();
                productoRepositorio.Guardar(producto);
                Respuesta.Mensaje = $"Se registro satisfactoriamente el producto {producto.Nombre}";
                return Respuesta;
            } catch (Exception e) {
                conexion.Close();
                Respuesta.IsError = true;
                Respuesta.Mensaje = "Error de Base de Datos:" + e.Message.ToString();
                return Respuesta;
            } finally {
                conexion.Close();

            }

        }


        public Respuesta Consultar() {
            Respuesta respuesta = new Respuesta();

            respuesta.IsError = false;

            try {
                conexion.Open();
                respuesta.productos = productoRepositorio.Consultar();
                return respuesta;
            } catch (Exception e) {
                respuesta.IsError = true;
                respuesta.Mensaje = "Error de Base de Datos:" + e.Message.ToString();
                return respuesta;
            } finally {
                conexion.Close();
            }
        }
        public Respuesta BuscarXnombre(string nombre)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.IsError = false;
            try
            {
                conexion.Open();
                respuesta.productos = productoRepositorio.BuscarXnombre(nombre);

            }
            catch (Exception e)
            {
                respuesta.IsError = true;
                respuesta.Mensaje = "Error de Base de Datos:" + e.Message.ToString();

            }
            finally
            {
                conexion.Close();
            }
            return respuesta;
        }

        public Respuesta Modificar(Producto producto) {
            var Respuesta = new Respuesta();
            Respuesta.IsError = false;
            try {
                conexion.Open();
                productoRepositorio.Modificar(producto);
                Respuesta.Mensaje = $"Se modificó satisfactoriamente el producto {producto.Nombre}";
                return Respuesta;
            } catch (Exception e) {
                conexion.Close();
                Respuesta.IsError = true;
                Respuesta.Mensaje = "Error de Base de Datos:" + e.Message.ToString();
                return Respuesta;
            } finally {
                conexion.Close();

            }
        }
        public Respuesta Eliminar(Producto producto) {
            var Respuesta = new Respuesta();
            Respuesta.IsError = false;
            try {
                conexion.Open();
                productoRepositorio.Eliminar(producto);
                Respuesta.Mensaje = $"Se eliminó satisfactoriamente el producto {producto.Nombre}";
                return Respuesta;
            } catch (Exception e) {
                conexion.Close();
                Respuesta.IsError = true;
                Respuesta.Mensaje = "Error de Base de Datos:" + e.Message.ToString();
                return Respuesta;
            } finally {
                conexion.Close();

            }
        }

        public class Respuesta {
            public IList<Producto> productos { get; set; }
            public string Mensaje { get; set; }
            public bool IsError { get; set; }
            
        }
    }
}
