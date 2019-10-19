using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;

namespace DAL {
    public class ProductoRepository {
        private OracleConnection Conexion;

        IList<Producto> productos = new List<Producto>();
        public ProductoRepository(OracleConnection conexion) {
            Conexion = conexion;
        }
        public void Guardar(Producto producto) {

            using (var Comando = Conexion.CreateCommand()) {
                Comando.CommandText = "pq_producto.guardar_producto";
                Comando.CommandType = CommandType.StoredProcedure;

                OracleParameter CodProducto = new OracleParameter();
                CodProducto.ParameterName = ":sec_producto.nextval";
                CodProducto.Value = producto.Codigo;
                Comando.Parameters.Add(CodProducto);

                CrearParametros(producto, Comando);

                Comando.ExecuteNonQuery();


            }


        }
        private void CrearParametros(Producto producto, OracleCommand comando)
        {
            OracleParameter Nombre = new OracleParameter();
            Nombre.ParameterName = ":nombre";
            Nombre.Value = producto.Nombre;
            comando.Parameters.Add(Nombre);

            OracleParameter Categoria = new OracleParameter();
            Categoria.ParameterName = ":categoria";
            Categoria.Value = producto.Categoria;
            comando.Parameters.Add(Categoria);

            OracleParameter Costo = new OracleParameter();
            Costo.ParameterName = ":costo";
            Costo.Value = producto.Costo;
            comando.Parameters.Add(Costo);

            OracleParameter PrecioCompra = new OracleParameter();
            PrecioCompra.ParameterName = ":preciocompra";
            PrecioCompra.Value = producto.PrecioCompra;
            comando.Parameters.Add(PrecioCompra);

            OracleParameter CantidadBodega = new OracleParameter();
            CantidadBodega.ParameterName = ":cantidadbodega";
            CantidadBodega.Value = producto.CantidadBodega;
            comando.Parameters.Add(CantidadBodega);

            OracleParameter FechaVencimiento = new OracleParameter();
            FechaVencimiento.ParameterName = ":fechavencimiento";

            if (producto.Categoria == "Medicamento")
            {
                FechaVencimiento.Value = producto.FechaVencimiento;
            }
            else
            {
                FechaVencimiento.Value = "NO APLICA";
            }
            comando.Parameters.Add(FechaVencimiento);

            OracleParameter Presentacion = new OracleParameter();
            Presentacion.ParameterName = ":presentacion";
            Presentacion.Value = producto.Presentacion;
            comando.Parameters.Add(Presentacion);
        }
        public IList<Producto> Consultar() {
            productos.Clear();
            using (var Comando = Conexion.CreateCommand()) {
                Comando.CommandText = "Select * from producto";

                using (var reader = Comando.ExecuteReader()) {

                    while (reader.Read()) {
                        Producto producto = new Producto();
                        producto = Map(reader);
                        productos.Add(producto);
                    }


                }


            }
            return productos;
        }

        public IList<Producto> BuscarXnombre(string nombre)
        {

            productos.Clear();
            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "select * from producto where nombre like :nom||''||'%' order by nombre desc";
                Comando.Parameters.Add(":nom", OracleDbType.Varchar2).Value = nombre;
                using (var reader = Comando.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Producto producto = new Producto();
                        producto = Map(reader);
                        productos.Add(producto);
                    }


                }


            }
            return productos;
        }

        public Producto Map(OracleDataReader reader) {
            var producto = new Producto();
            producto.Codigo = Convert.ToInt32(reader["codproducto"]);
            producto.Nombre = (string)reader["nombre"];
            producto.Categoria = reader["categoria"].ToString();
            producto.Costo = Convert.ToDecimal(reader["costo"]);
            producto.PrecioCompra = Convert.ToDecimal(reader["preciocompra"]);
            producto.FechaVencimiento = reader["fechavencimiento"].ToString();
            producto.Presentacion = reader["presentacion"].ToString();
            producto.CantidadBodega = Convert.ToInt32(reader["cantidadbodega"]);

            return producto;
        }
        public void Modificar(Producto producto) {
            using (var Comando = Conexion.CreateCommand()) {
                Comando.CommandText = "pq_producto.modificar_producto";
                Comando.CommandType = CommandType.StoredProcedure;

                OracleParameter CodProducto = new OracleParameter();
                CodProducto.ParameterName = "@codproducto";
                CodProducto.Value = producto.Codigo;
                Comando.Parameters.Add(CodProducto);

                CrearParametros(producto, Comando);

                Comando.ExecuteNonQuery();


            }

        }
        public void Eliminar(Producto producto) {
            using (var Comando = Conexion.CreateCommand()) {
                Comando.CommandText = "pq_producto.eliminar_producto";
                Comando.CommandType = CommandType.StoredProcedure;

                OracleParameter CodProducto = new OracleParameter();
                CodProducto.ParameterName = "@codproducto";
                CodProducto.Value = producto.Codigo;
                Comando.Parameters.Add(CodProducto);

                Comando.ExecuteNonQuery();

            }
        }
    }
}
