using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DtoDetalle
    {
        public int CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Categoria { get; set; }
        public string Presentacion { get; set; }
        public decimal Costo { get; set; }
        public decimal SubTotal { get; set; }
        public int CantidadVendida { get; set; }
    }
}
