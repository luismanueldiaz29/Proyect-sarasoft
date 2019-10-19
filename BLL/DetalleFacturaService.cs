using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
using Oracle.ManagedDataAccess.Client;

namespace BLL
{
    public class DetalleFacturaService
    {
        DetalleFacturaRepository detalleRepositorio;
        OracleConnection conexion;

        public DetalleFacturaService()
        {
            string cadena = "Data Source=localhost:1521/xepdb1;User Id=sarasoft;Password=1234";
            conexion = new OracleConnection(cadena);
            detalleRepositorio = new DetalleFacturaRepository(conexion);
        }
        public Respuesta Guardar(Detalle detalle)
        {

            var Respuesta = new Respuesta();
            Respuesta.IsError = false;
            try
            {
                conexion.Open();
                detalleRepositorio.Guardar(detalle);
                Respuesta.Mensaje = $"Se registro satisfactoriamente el detalle de factura";
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
        public Respuesta Consultar()
        {
            Respuesta respuesta = new Respuesta();

            respuesta.IsError = false;

            try
            {
                conexion.Open();
                respuesta.Detalles = detalleRepositorio.Consultar();
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
        public Respuesta Buscar(int codigo)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.IsError = false;

            try
            {
                conexion.Open();
                respuesta.Detalles = detalleRepositorio.Buscar(codigo);
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
            public IList<Detalle> Detalles { get; set; }
            public string Mensaje { get; set; }
            public bool IsError { get; set; }
        }
    }
}
