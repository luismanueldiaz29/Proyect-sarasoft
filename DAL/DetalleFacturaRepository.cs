using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Entity;
using System.Data;

namespace DAL
{
    public class DetalleFacturaRepository
    {
        private OracleConnection Conexion;

        IList<Detalle> detalles = new List<Detalle>();

        public DetalleFacturaRepository(OracleConnection conexion)
        {
            Conexion = conexion;
        }
        public void Guardar(Detalle detalle)
        {

            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "facturacion.Guardardetalle";
                Comando.CommandType = CommandType.StoredProcedure;
                Procedimiento(detalle, Comando);

                Comando.ExecuteNonQuery();
            }

        }

        private static void Procedimiento(Detalle detalle, OracleCommand Comando)
        {
            OracleParameter Codigo = new OracleParameter();
            Codigo.ParameterName = ":coddetalle";           
            Codigo.Value = detalle.Codigo;
            Comando.Parameters.Add(Codigo);

            OracleParameter NombreProducto = new OracleParameter();
            NombreProducto.ParameterName = ":nombreproducto";            
            NombreProducto.Value = detalle.NombreProducto;
            Comando.Parameters.Add(NombreProducto);

            OracleParameter Categoria = new OracleParameter();
            Categoria.ParameterName = ":categoria";
            Categoria.Value = detalle.Categoria;
            Comando.Parameters.Add(Categoria);

            OracleParameter Cantidad = new OracleParameter();
            Cantidad.ParameterName = ":cantidad";
            Cantidad.Value = detalle.CantidadVendida;
            Comando.Parameters.Add(Cantidad);

            OracleParameter Costo = new OracleParameter();
            Costo.ParameterName = ":costo";
            Costo.Value = detalle.Costo;
            Comando.Parameters.Add(Costo);

            OracleParameter SubTotal = new OracleParameter();
            SubTotal.ParameterName = ":subtotal";
            SubTotal.Value = detalle.SubTotal;
            Comando.Parameters.Add(SubTotal);

            OracleParameter CodFactura = new OracleParameter();
            CodFactura.ParameterName = ":factura_codfactura";
            CodFactura.Value = detalle.CodigoFactura;
            Comando.Parameters.Add(CodFactura);

            OracleParameter CodProducto = new OracleParameter();
            CodProducto.ParameterName = ":producto_codproducto";
            CodProducto.Value = detalle.CodigoProducto;
            Comando.Parameters.Add(CodProducto);

            OracleParameter Presentacion = new OracleParameter();
            Presentacion.ParameterName = ":presentacion";
            Presentacion.Value = detalle.Presentacion;
            Comando.Parameters.Add(Presentacion);
        }
        public IList<Detalle> Consultar()
        {
            detalles.Clear();
            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "Select * from detalle";

                using (var reader = Comando.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Detalle detalle = new Detalle();
                        detalle = Map(reader);
                        detalles.Add(detalle);
                    }


                }


            }
            return detalles;
        }
        public Detalle Map(OracleDataReader reader)
        {
            Detalle detalle = new Detalle();
            detalle.Codigo = Convert.ToInt32(reader["coddetalle"]);
            detalle.NombreProducto = reader["nombreproducto"].ToString();
            detalle.Categoria = reader["categoria"].ToString();
            detalle.CantidadVendida = Convert.ToInt32(reader["cantidad"]);
            detalle.Costo = Convert.ToDecimal(reader["costo"]);
            detalle.SubTotal = Convert.ToDecimal(reader["subtotal"]);
            detalle.CodigoFactura = Convert.ToInt32(reader["factura_codfactura"]);
            detalle.CodigoProducto = Convert.ToInt32(reader["producto_codproducto"]);
            detalle.Presentacion = reader["presentacion"].ToString();

            return detalle;
        }
        public IList<Detalle> Buscar(int codigo)
        {
            detalles.Clear();
            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = @"Select * from detalle where factura_codfactura = :factura_codfactura";
                Comando.Parameters.Add("factura_codfactura", OracleDbType.Int32).Value = codigo;
                using (var reader = Comando.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Detalle detalle = new Detalle();
                        detalle = Map(reader);
                        detalles.Add(detalle);
                    }


                }


            }
            return detalles;
        }
    }
}
