using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Factura
    {
        public int Codigo { get; set; }
        public string Fecha { get; set; }
        public decimal TotalPagar { get; set; }
        public int CodigoCuenta { get; set; }
        public string IdCliente { get; set; }
        public string IdVendedor { get; set; }

        //List<Detalle> detalles;

        public decimal CalcularTotal()
        {
            return TotalPagar;
        }
    }
}
