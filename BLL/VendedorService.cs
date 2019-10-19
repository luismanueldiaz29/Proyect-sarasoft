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
    public class VendedorService
    {
        VendedorRepository vendedorRepositorio;

        OracleConnection conexion;
        public VendedorService()
        {
            string cadena = "Data Source=localhost:1521/xe;User Id=sarasoft;Password=1234";
            conexion = new OracleConnection(cadena);
            vendedorRepositorio = new VendedorRepository(conexion);
        }
        public Vendedor Buscar(string idVendedor, string contraseña)
        {
            var Vendedor = new Vendedor();
            
                conexion.Open();
                Vendedor = vendedorRepositorio.Buscar(idVendedor, contraseña);
                conexion.Close();
                return Vendedor;
        }
        public Respuesta Guardar(Vendedor vendedor)
        {

            var Respuesta = new Respuesta();
            Respuesta.IsError = false;
            try
            {
                conexion.Open();
                vendedorRepositorio.Guardar(vendedor);
                Respuesta.Mensaje = $"Se registro satisfactoriamente el vendedor {vendedor.Nombre1 + " " + vendedor.Apellido1}";
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
        public Respuesta Modificar(Vendedor vendedor)
        {
            var respuesta = new Respuesta();
            try
            {
                conexion.Open();
                vendedorRepositorio.Modificar(vendedor);
                conexion.Close();
                respuesta.Mensaje = "La información fue modificada correctamente";
                return respuesta;
            }
            catch (Exception ex)
            {
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
                respuesta.Vendedores = vendedorRepositorio.Consultar();
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
            public IList<Vendedor> Vendedores { get; set; }
            public string Mensaje { get; set; }
            public bool IsError { get; set; }
        }
    }
}
