using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Producto
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int CantidadBodega { get; set; }
        public decimal Costo { get; set; }
        public string FechaVencimiento { get; set; }
        public decimal PrecioCompra { get; set; }
        public string Presentacion { get; set; }

    }
}
