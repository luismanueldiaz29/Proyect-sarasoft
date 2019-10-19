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
    public class CuentaService
    {
        CuentaRepository cuentaRepositorio;

        OracleConnection conexion;
        public CuentaService()
        {
            string cadena = "Data Source=localhost:1521/xepdb1;User Id=sarasoft;Password=1234";
            conexion = new OracleConnection(cadena);
            cuentaRepositorio = new CuentaRepository(conexion);
        }
        public Respuesta2 Guardar(Cuenta cuenta)
        {

            var Respuesta = new Respuesta2();
            Respuesta.IsError = false;
            try
            {
                conexion.Open();
                cuentaRepositorio.Guardar(cuenta);
                Respuesta.Mensaje = $"Se creó satisfactoriamente la cuenta";
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
                respuesta.Cuentas = cuentaRepositorio.Consultar();
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
        public Respuesta2 ConsultarGraficar()
        {
            Respuesta2 respuesta = new Respuesta2();

            respuesta.IsError = false;

            try
            {
                conexion.Open();
                respuesta.Cuentas = cuentaRepositorio.ConsultarGraficar();
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
                respuesta.Cuentas = cuentaRepositorio.Buscar(idCliente);
                
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
        public Respuesta2 GuardarNueva(string idCliente)
        {

            var Respuesta = new Respuesta2();
            Respuesta.IsError = false;
            try
            {
                conexion.Open();
                cuentaRepositorio.GuardarNueva(idCliente);
                Respuesta.Mensaje = $"Se creó satisfactoriamente la cuenta";
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

        public class Respuesta2
        {
            public IList<Cuenta> Cuentas { get; set; }
            public string Mensaje { get; set; }
            public bool IsError { get; set; }
        }
    }
}
