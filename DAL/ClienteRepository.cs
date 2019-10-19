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
    public class ClienteRepository {

        private OracleConnection Conexion;

        IList<Cliente> clientes = new List<Cliente>();
        
        public ClienteRepository(OracleConnection conexion)
        {
            Conexion = conexion;

        }

        public void Guardar(Cliente cliente)
        {
            
            using (var Comando = Conexion.CreateCommand()) {
                Comando.CommandText = "controlcliente.GuardarCliente";
                Comando.CommandType = CommandType.StoredProcedure;
                Procedimiento(cliente, Comando);

                Comando.ExecuteNonQuery();
            }

        }

        private static void Procedimiento(Cliente cliente, OracleCommand Comando) {
            OracleParameter Idcliente = new OracleParameter();
            Idcliente.ParameterName = ":cedula";
            Idcliente.OracleDbType = OracleDbType.Varchar2;
            Idcliente.Value = cliente.IdCliente;
            Comando.Parameters.Add(Idcliente);

            OracleParameter Nombre1 = new OracleParameter();
            Nombre1.ParameterName = ":nom1";
            Nombre1.OracleDbType = OracleDbType.Varchar2;
            Nombre1.Value = cliente.Nombre1;
            Comando.Parameters.Add(Nombre1);

            OracleParameter Nombre2 = new OracleParameter();
            Nombre2.ParameterName = ":nom2";
            Nombre2.OracleDbType = OracleDbType.Varchar2;
            Nombre2.Value = cliente.Nombre2;
            Comando.Parameters.Add(Nombre2);

            OracleParameter Apellido1 = new OracleParameter();
            Apellido1.ParameterName = ":ape1";
            Apellido1.OracleDbType = OracleDbType.Varchar2;
            Apellido1.Value = cliente.Apellido1;
            Comando.Parameters.Add(Apellido1);

            OracleParameter Apellido2 = new OracleParameter();
            Apellido2.ParameterName = ":ape2";
            Apellido2.OracleDbType = OracleDbType.Varchar2;
            Apellido2.Value = cliente.Apellido2;
            Comando.Parameters.Add(Apellido2);

            OracleParameter telefon1 = new OracleParameter();
            telefon1.ParameterName = ":tel1";
            telefon1.OracleDbType = OracleDbType.Varchar2;
            telefon1.Value = cliente.Telefono1;
            Comando.Parameters.Add(telefon1);

            OracleParameter telefon2 = new OracleParameter();
            telefon2.ParameterName = ":tel2";
            telefon2.OracleDbType = OracleDbType.Varchar2;
            telefon2.Value = cliente.Telefono2;
            Comando.Parameters.Add(telefon2);

            OracleParameter direccion = new OracleParameter();
            direccion.ParameterName = ":dir";
            direccion.OracleDbType = OracleDbType.Varchar2;
            direccion.Value = cliente.Direccion;
            Comando.Parameters.Add(direccion);

            OracleParameter correo = new OracleParameter();
            correo.ParameterName = ":cor";
            correo.OracleDbType = OracleDbType.Varchar2;
            correo.Value = cliente.Correo;
            Comando.Parameters.Add(correo);
        }

        public void Modificar(Cliente cliente) {
            using (var Comando = Conexion.CreateCommand()) {
                Comando.CommandText = "ControlCliente.ModificarCliente";
                Comando.CommandType = CommandType.StoredProcedure;
                Procedimiento(cliente, Comando);
                Comando.ExecuteNonQuery();
            }
        }

        public IList<Cliente> Consultar()
        {
            clientes.Clear();
            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "Select * from cliente";
                
                using (var reader = Comando.ExecuteReader())
                {
                    
                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente();
                        cliente = Map(reader);
                        clientes.Add(cliente);
                    }


                }


            }
            return clientes;
        }
        public Cliente Map(OracleDataReader reader)
        {
            var cliente = new Cliente();
            cliente.IdCliente = (string)reader["idcliente"];
            cliente.Nombre1 = (string)reader["nombre1"];
            cliente.Nombre2 = reader["nombre2"].ToString();
            cliente.Apellido1 = (string)reader["apellido1"];
            cliente.Apellido2 = (string)reader["apellido2"];
            cliente.Direccion = (string)reader["direccion"];
            cliente.Telefono1 = reader["telefono1"].ToString();
            cliente.Telefono2 = reader["telefono2"].ToString();
            cliente.Correo = reader["correo"].ToString();
          
            return cliente;
        }

        public bool validar(string cedula) {
            bool verificar = false;
            foreach (var item in Consultar()) {
                if (item.IdCliente.Equals(cedula)) {
                    verificar = true;
                }
            }
            return verificar;
        }

        public IList<Cliente> Buscar(string Nombre)
        {
            clientes.Clear();
            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "Select * from cliente where nombre1||' '||nombre2 like :nom||''||'%' or nombre2 like :nom||''||'%'";
                //+$" or nombre2 like '{Nombre}%'";
                Comando.Parameters.Add(":nom", OracleDbType.Varchar2).Value = Nombre;
                using (var reader = Comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente();
                        cliente = Map(reader);
                        clientes.Add(cliente);
                    }
                }
            }
            return clientes;
        }

        public void Eliminar(string cedula) {
            using (var Comando = Conexion.CreateCommand()) {
                Comando.CommandText = "ControlCliente.EliminarCliente";
                Comando.CommandType = CommandType.StoredProcedure;

                OracleParameter Cedula = new OracleParameter();
                Cedula.ParameterName = ":cedula";
                Cedula.OracleDbType = OracleDbType.Varchar2;
                Cedula.Value = cedula;
                Comando.Parameters.Add(Cedula);

                Comando.ExecuteNonQuery();
            }
        }
        
    }
}
