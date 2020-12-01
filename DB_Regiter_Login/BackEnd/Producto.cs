using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Regiter_Login;

namespace DB_Regiter_Login.BackEnd
{
    class Producto
    {
        public int idProducto { get; set; }
        public double precio { get; set; }
        public String nombre { get; set; }
        public String descripcion { get; set; }
        public int stock { get; set; } 
        public int idCategoria { get; set; }
        public int idProveedor { get; set; }
    }
}
