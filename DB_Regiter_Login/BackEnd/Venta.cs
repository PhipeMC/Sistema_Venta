using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Regiter_Login.BackEnd
{
    class Venta
    {
        public int idVenta { get; set; }
        public DateTime fecha { get; set; }
        public int idEmpleado { get; set; }
        public int idCliente { get; set; }
    }
}
