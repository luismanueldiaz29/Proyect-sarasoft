using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace DAL
{
    public class FacturaRepository
    {
        private OracleConnection Conexion;

        IList<Factura> facturas = new List<Factura>();

        public FacturaRepository(OracleConnection conexion)
        {
            Conexion = conexion;
        }
        public void Guardar(Factura factura)
        {

            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "facturacion.Guardarfactura";
                Comando.CommandType = CommandType.StoredProcedure;
                Procedimiento(factura, Comando);

                Comando.ExecuteNonQuery();
            }

        }
        private static void Procedimiento(Factura factura, OracleCommand Comando)
        {
            OracleParameter Codigo = new OracleParameter();
            Codigo.ParameterName = ":sec_factura.nextval";
            Codigo.Value = factura.Codigo;
            Comando.Parameters.Add(Codigo);

            OracleParameter FechaCreacion = new OracleParameter();
            FechaCreacion.ParameterName = ":fechacreacion";
            FechaCreacion.Value = factura.Fecha;
            Comando.Parameters.Add(FechaCreacion);

            OracleParameter TotalPagar = new OracleParameter();
            TotalPagar.ParameterName = ":totalpagar";
            TotalPagar.Value = factura.TotalPagar;
            Comando.Parameters.Add(TotalPagar);

            OracleParameter IdCliente = new OracleParameter();
            IdCliente.ParameterName = ":cliente_idcliente";
            IdCliente.Value = factura.IdCliente;
            Comando.Parameters.Add(IdCliente);

            OracleParameter CodCuenta = new OracleParameter();
            CodCuenta.ParameterName = ":cuenta_codcuenta";
            CodCuenta.Value = factura.CodigoCuenta;
            Comando.Parameters.Add(CodCuenta);

            OracleParameter IdVendedor = new OracleParameter();
            IdVendedor.ParameterName = ":empleado_idvendedor";
            IdVendedor.Value = factura.IdVendedor;
            Comando.Parameters.Add(IdVendedor);

        }
        public IList<Factura> Consultar()
        {
            facturas.Clear();
            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "Select * from factura";

                using (var reader = Comando.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Factura factura = new Factura();
                        factura = Map(reader);
                        facturas.Add(factura);
                    }


                }


            }
            return facturas;
        }
        public Factura Map(OracleDataReader reader)
        {
            Factura factura = new Factura();
            factura.Codigo = Convert.ToInt32(reader["codfactura"]);
            factura.Fecha = reader["fechacreacion"].ToString();
            factura.TotalPagar = Convert.ToDecimal(reader["totalpagar"]);
            factura.IdCliente = reader["cliente_idcliente"].ToString();
            factura.CodigoCuenta = Convert.ToInt32(reader["cuenta_codcuenta"]);
            factura.IdVendedor = reader["empleado_idvendedor"].ToString();
            

            return factura;
        }
    }
}
