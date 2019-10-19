using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace DAL
{
    public class AbonoRepository
    {
        private OracleConnection Conexion;
        IList<Abono> abonos = new List<Abono>();
        public AbonoRepository(OracleConnection conexion)
        {
            Conexion = conexion;
        }
        public void Guardar(Abono abono)
        {

            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "controlabono.guardarabono";
                Comando.CommandType = CommandType.StoredProcedure;

                OracleParameter FechaCreacion = new OracleParameter();
                FechaCreacion.ParameterName = ":fechacreacion";
                FechaCreacion.Value = abono.Fecha;
                Comando.Parameters.Add(FechaCreacion);

                OracleParameter ValorAbono = new OracleParameter();
                ValorAbono.ParameterName = ":valorabono";
                ValorAbono.Value = abono.ValorAbono;
                Comando.Parameters.Add(ValorAbono);

                OracleParameter IdCliente = new OracleParameter();
                IdCliente.ParameterName = ":cliente_idcliente";
                IdCliente.Value = abono.IdCliente;
                Comando.Parameters.Add(IdCliente);

                OracleParameter CodigoCuenta = new OracleParameter();
                CodigoCuenta.ParameterName = ":cuenta_codcuenta";
                CodigoCuenta.Value = abono.CodigoCuenta;
                Comando.Parameters.Add(CodigoCuenta);

                Comando.ExecuteNonQuery();
            }

        }
        public IList<Abono> Consultar()
        {
            abonos.Clear();
            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "Select * from abono";

                using (var reader = Comando.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Abono abono = new Abono();
                        abono = Map(reader);
                        abonos.Add(abono);
                    }


                }


            }
            return abonos;
        }
        public Abono Map(OracleDataReader reader)
        {
            Abono abono = new Abono();
            abono.Codigo = Convert.ToInt32(reader["codabono"]);
            abono.Fecha = reader["fechacreacion"].ToString();
            abono.ValorAbono = Convert.ToDecimal(reader["valorabono"]);
            abono.IdCliente = Convert.ToString(reader["cliente_idcliente"]);
            abono.CodigoCuenta = Convert.ToInt32(reader["cuenta_codcuenta"]);


            return abono;
        }
        public IList<Abono> Buscar(string idCliente)
        {

            abonos.Clear();
            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "select * from abono where cliente_idcliente like :idcliente||''||'%'";
                Comando.Parameters.Add(":idcliente", OracleDbType.Varchar2).Value = idCliente;
                using (var reader = Comando.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Abono abono = new Abono();
                        abono = Map(reader);
                        abonos.Add(abono);
                    }


                }


            }
            return abonos;
        }
    }
}
