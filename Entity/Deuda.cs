using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Deuda
    {
        public float ValorDeuda { get; set; }
        List<Abono> Abonos;
    }
}
