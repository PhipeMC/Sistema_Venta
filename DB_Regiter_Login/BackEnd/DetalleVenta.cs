using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Regiter_Login.BackEnd
{
    class DetalleVenta
    {
        public int idVenta { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public double precioXUnidad { get; set; }
        public double descuento { get; set; }

    }
}
