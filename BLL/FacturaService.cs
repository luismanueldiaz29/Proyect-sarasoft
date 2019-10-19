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
    public class FacturaService
    {
        FacturaRepository facturaRepositorio;
        OracleConnection conexion;

        public FacturaService()
        {
            string cadena = "Data Source=localhost:1521/xepdb1;User Id=sarasoft;Password=1234";
            conexion = new OracleConnection(cadena);
            facturaRepositorio = new FacturaRepository(conexion);
        }
        public Respuesta2 Guardar(Factura factura)
        {

            var Respuesta = new Respuesta2();
            Respuesta.IsError = false;
            try
            {
                conexion.Open();
                facturaRepositorio.Guardar(factura);
                Respuesta.Mensaje = $"Se registro satisfactoriamente la factura";
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
        public Respuesta2 Consultar()
        {
            Respuesta2 respuesta = new Respuesta2();

            respuesta.IsError = false;

            try
            {
                conexion.Open();
                respuesta.Facturas = facturaRepositorio.Consultar();
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
        public class Respuesta2
        {
            public IList<Factura> Facturas { get; set; }
            public string Mensaje { get; set; }
            public bool IsError { get; set; }
        }
    }
}
