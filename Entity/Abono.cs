using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Abono
    {
        public string Fecha { get; set; }
        public int Codigo { get; set; }
        public int CodigoCuenta { get; set; }
        public decimal ValorAbono { get; set; }
        public string IdCliente { get; set; }


    }
}
