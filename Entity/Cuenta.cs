using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Cuenta
    {
        public int Codigo { get; set; }
        public string FechaCreacion { get; set; }
        public string  Estado { get; set; }
        public decimal ValorDeuda { get; set; }
        public decimal SaldoAnterior { get; set; }
        public decimal TotalAbonos { get; set; }
        public decimal TotalFacturas { get; set; }
        public string IdCliente { get; set; }

        public decimal RecalcularDeuda()
        {
            return ValorDeuda;
        }
    }
}
