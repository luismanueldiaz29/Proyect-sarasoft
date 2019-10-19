using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Detalle
    {
        public int Codigo { get; set; }
        public int CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Categoria { get; set; }
        public decimal Costo { get; set; }
        public decimal SubTotal { get; set; }
        public int CantidadVendida { get; set; }
        public int CodigoFactura { get; set; }
        public string Presentacion { get; set; }


    }
}
