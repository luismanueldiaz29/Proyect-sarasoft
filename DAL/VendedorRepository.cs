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
    public class VendedorRepository
    {
        private OracleConnection Conexion;
        IList<Vendedor> vendedores = new List<Vendedor>();
        public VendedorRepository(OracleConnection conexion)
        {
            Conexion = conexion;
        }
        public Vendedor Buscar(string idVendedor, string contraseña)
        {

            using (var comando = Conexion.CreateCommand())
            {

                comando.CommandText = @"SELECT * FROM Empleado WHERE idvendedor = :idvendedor and contraseña = :contraseña";
                
                
                comando.Parameters.Add("idvendedor", OracleDbType.Varchar2).Value = idVendedor;
                comando.Parameters.Add("contraseña", OracleDbType.Varchar2).Value = contraseña;
                using (var reader = comando.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return Map(reader);
                    }
                    else
                    {
                        return null;
                    }

                }
            }
        }

        public Vendedor Map(OracleDataReader reader)
        {
            var Vendedor = new Vendedor();
            Vendedor.IdVendedor = (string)reader["idvendedor"];
            Vendedor.Nombre1 = (string)reader["primernombre"];
            Vendedor.Nombre2 = Convert.ToString(reader["segundonombre"]);
            Vendedor.Apellido1 = (string)reader["primerapellido"];
            Vendedor.Apellido2 = (string)reader["segundoapellido"];
            Vendedor.Cargo = (string)reader["cargo"];
            Vendedor.Telefono1 = Convert.ToString(reader["telefono1"]);
            Vendedor.Telefono2 = Convert.ToString(reader["telefono2"]);
            Vendedor.Direccion = (string)reader["direccion"];
            Vendedor.Contraseña = (string)reader["contraseña"];
            return Vendedor;
        }
        public void Guardar(Vendedor vendedor)
        {

            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "controlvendedor.Guardarvendedor";
                Comando.CommandType = CommandType.StoredProcedure;
                Procedimiento(vendedor, Comando);

                Comando.ExecuteNonQuery();
            }

        }

        private static void Procedimiento(Vendedor vendedor, OracleCommand Comando)
        {
            OracleParameter IdVendedor = new OracleParameter();
            IdVendedor.ParameterName = ":idvendedor";
            IdVendedor.OracleDbType = OracleDbType.Varchar2;
            IdVendedor.Value = vendedor.IdVendedor;
            Comando.Parameters.Add(IdVendedor);

            OracleParameter Nombre1 = new OracleParameter();
            Nombre1.ParameterName = ":nombre1";
            Nombre1.OracleDbType = OracleDbType.Varchar2;
            Nombre1.Value = vendedor.Nombre1;
            Comando.Parameters.Add(Nombre1);

            OracleParameter Nombre2 = new OracleParameter();
            Nombre2.ParameterName = ":nombre2";
            Nombre2.OracleDbType = OracleDbType.Varchar2;
            Nombre2.Value = vendedor.Nombre2;
            Comando.Parameters.Add(Nombre2);

            OracleParameter Apellido1 = new OracleParameter();
            Apellido1.ParameterName = ":apellido1";
            Apellido1.OracleDbType = OracleDbType.Varchar2;
            Apellido1.Value = vendedor.Apellido1;
            Comando.Parameters.Add(Apellido1);

            OracleParameter Apellido2 = new OracleParameter();
            Apellido2.ParameterName = ":apellido2";
            Apellido2.OracleDbType = OracleDbType.Varchar2;
            Apellido2.Value = vendedor.Apellido2;
            Comando.Parameters.Add(Apellido2);

            OracleParameter Cargo = new OracleParameter();
            Cargo.ParameterName = ":cargo";
            Cargo.OracleDbType = OracleDbType.Varchar2;
            Cargo.Value = vendedor.Cargo;
            Comando.Parameters.Add(Cargo);

            OracleParameter Telefono1 = new OracleParameter();
            Telefono1.ParameterName = ":telefono1";
            Telefono1.OracleDbType = OracleDbType.Varchar2;
            Telefono1.Value = vendedor.Telefono1;
            Comando.Parameters.Add(Telefono1);

            OracleParameter Telefono2 = new OracleParameter();
            Telefono2.ParameterName = ":telefono2";
            Telefono2.OracleDbType = OracleDbType.Varchar2;
            Telefono2.Value = vendedor.Telefono2;
            Comando.Parameters.Add(Telefono2);

            OracleParameter Direccion = new OracleParameter();
            Direccion.ParameterName = ":direccion";
            Direccion.OracleDbType = OracleDbType.Varchar2;
            Direccion.Value = vendedor.Direccion;
            Comando.Parameters.Add(Direccion);

            OracleParameter Contraseña = new OracleParameter();
            Contraseña.ParameterName = ":correo";
            Contraseña.OracleDbType = OracleDbType.Varchar2;
            Contraseña.Value = vendedor.Contraseña;
            Comando.Parameters.Add(Contraseña);
        }

        public void Modificar(Vendedor vendedor)
        {
            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "Controlvendedor.Modificarvendedor";
                Comando.CommandType = CommandType.StoredProcedure;
                Procedimiento(vendedor, Comando);
                Comando.ExecuteNonQuery();
            }
        }
        public IList<Vendedor> Consultar()
        {
            vendedores.Clear();
            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "Select * from empleado";

                using (var reader = Comando.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Vendedor vendedor = new Vendedor();
                        vendedor = Map(reader);
                        vendedores.Add(vendedor);
                    }


                }


            }
            return vendedores;
        }
    }
}
