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
    public class CuentaRepository
    {
        private OracleConnection Conexion;
        IList<Cuenta> cuentas = new List<Cuenta>();
        public CuentaRepository(OracleConnection conexion)
        {
            Conexion = conexion;
        }
        public void Guardar(Cuenta cuenta)
        {

            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "controlcuenta.Guardarcuenta";
                Comando.CommandType = CommandType.StoredProcedure;
                Procedimiento(cuenta, Comando);

                Comando.ExecuteNonQuery();
            }

        }
        private static void Procedimiento(Cuenta cuenta, OracleCommand Comando)
        {
            OracleParameter Codigo = new OracleParameter();
            Codigo.ParameterName = ":sec_cuenta.nextval";
            Codigo.Value = cuenta.Codigo;
            Comando.Parameters.Add(Codigo);

            OracleParameter FechaCreacion = new OracleParameter();
            FechaCreacion.ParameterName = ":fechacreacion";
            FechaCreacion.Value = cuenta.FechaCreacion;
            Comando.Parameters.Add(FechaCreacion);

            OracleParameter ValorDeuda = new OracleParameter();
            ValorDeuda.ParameterName = ":valordeuda";
            ValorDeuda.Value = cuenta.ValorDeuda;
            Comando.Parameters.Add(ValorDeuda);

            OracleParameter Estado = new OracleParameter();
            Estado.ParameterName = ":estado";
            Estado.Value = cuenta.Estado;
            Comando.Parameters.Add(Estado);

            OracleParameter SaldoAnterior = new OracleParameter();
            SaldoAnterior.ParameterName = ":saldoanterior";
            SaldoAnterior.Value = cuenta.SaldoAnterior;
            Comando.Parameters.Add(SaldoAnterior);

            OracleParameter TotalAbonos = new OracleParameter();
            TotalAbonos.ParameterName = ":totalabonos";
            TotalAbonos.Value = cuenta.TotalAbonos;
            Comando.Parameters.Add(TotalAbonos);

            OracleParameter TotalFacturas = new OracleParameter();
            TotalFacturas.ParameterName = ":totalfacturas";
            TotalFacturas.Value = cuenta.TotalFacturas;
            Comando.Parameters.Add(TotalFacturas);

            OracleParameter IdCliente = new OracleParameter();
            IdCliente.ParameterName = ":idcliente";
            IdCliente.Value = cuenta.IdCliente;
            Comando.Parameters.Add(IdCliente);

        }
        public IList<Cuenta> Consultar()
        {
            cuentas.Clear();
            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "Select * from cuenta";

                using (var reader = Comando.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Cuenta cuenta = new Cuenta();
                        cuenta = Map(reader);
                        cuentas.Add(cuenta);
                    }


                }


            }
            return cuentas;
        }
        public IList<Cuenta> ConsultarGraficar()
        {
            cuentas.Clear();
            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "select extract(year from fechacreacion) año, extract (month from fechacreacion) mes, sum(totalfacturas) suma from cuenta   group by (extract(year from fechacreacion), extract(month from fechacreacion)) order by año,mes asc ";

                using (var reader = Comando.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Cuenta cuenta = new Cuenta();
                        cuenta = MapearGraficar(reader);
                        cuentas.Add(cuenta);
                    }


                }


            }
            return cuentas;
        }
        public Cuenta MapearGraficar(OracleDataReader reader)
        {
            var cuenta = new Cuenta();
            string año = Convert.ToString(reader["año"]);
            string mes = Convert.ToString(reader["mes"]);
            cuenta.FechaCreacion = año + " " + mes;
            cuenta.ValorDeuda = Convert.ToDecimal(reader["suma"]);
            return cuenta;
        }
        public Cuenta Map(OracleDataReader reader)
        {
            var cuenta = new Cuenta();
            cuenta.Codigo = Convert.ToInt32(reader["codcuenta"]);
            cuenta.FechaCreacion = Convert.ToString(reader["fechacreacion"]);
            cuenta.ValorDeuda = Convert.ToDecimal(reader["valordeuda"]);
            cuenta.Estado = reader["estado"].ToString();
            cuenta.SaldoAnterior = Convert.ToDecimal(reader["saldoanterior"]);
            cuenta.TotalAbonos = Convert.ToDecimal(reader["totalabonos"]);
            cuenta.TotalFacturas = Convert.ToDecimal(reader["totalfacturas"]);
            cuenta.IdCliente = reader["cliente_idcliente"].ToString();

            return cuenta;
        }
        public Cuenta BuscarT(string idCliente)
        {

            using (var comando = Conexion.CreateCommand())
            {

                comando.CommandText = @"SELECT codcuenta FROM cuenta WHERE idCliente = idCliente and estado = 'Activa'";
                comando.Parameters.Add("idCliente", OracleDbType.Varchar2).Value = idCliente;
                int lec = Convert.ToInt32(comando.ExecuteReader());
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
        public IList<Cuenta> Buscar(string idCliente)
        {

            cuentas.Clear();
            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "select * from cuenta where cliente_idcliente like :idcliente||''||'%'";
                Comando.Parameters.Add(":idcliente", OracleDbType.Varchar2).Value = idCliente;
                using (var reader = Comando.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Cuenta cuenta = new Cuenta();
                        cuenta = Map(reader);
                        cuentas.Add(cuenta);
                    }


                }


            }
            return cuentas;
        }
        public void GuardarNueva(string idCliente)
        {

            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "facturacion.nuevacuenta";
                Comando.CommandType = CommandType.StoredProcedure;

                OracleParameter FechaCreacion = new OracleParameter();
                FechaCreacion.ParameterName = ":fechacreacion";
                FechaCreacion.Value = DateTime.Now.ToShortDateString();
                Comando.Parameters.Add(FechaCreacion);

                OracleParameter IdCliente = new OracleParameter();
                IdCliente.ParameterName = ":sec_cuenta.nextval";
                IdCliente.Value = idCliente;
                Comando.Parameters.Add(IdCliente);

                Comando.ExecuteNonQuery();
            }

        }



    }
}
