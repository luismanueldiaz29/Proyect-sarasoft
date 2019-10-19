using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using Oracle.ManagedDataAccess.Client;


namespace BLL
{
    public class AbonoService
    {
        AbonoRepository abonoRepositorio;

        OracleConnection conexion;
        public AbonoService()
        {
            string cadena = "Data Source=localhost:1521/xepdb1;User Id=sarasoft;Password=1234";
            conexion = new OracleConnection(cadena);
            abonoRepositorio = new AbonoRepository(conexion);
        }
        public Respuesta2 Guardar(Abono abono)
        {

            var Respuesta = new Respuesta2();
            Respuesta.IsError = false;
            try
            {
                conexion.Open();
                abonoRepositorio.Guardar(abono);
                Respuesta.Mensaje = $"Se registro satisfactoriamente el abono";
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
                respuesta.Abonos = abonoRepositorio.Consultar();
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
        public Respuesta2 Buscar(string idCliente)
        {
            Respuesta2 respuesta = new Respuesta2();
            respuesta.IsError = false;


            try
            {
                conexion.Open();
                respuesta.Abonos = abonoRepositorio.Buscar(idCliente);

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
        public class Respuesta2
        {
            public IList<Abono> Abonos { get; set; }
            public string Mensaje { get; set; }
            public bool IsError { get; set; }
        }
    }
}
