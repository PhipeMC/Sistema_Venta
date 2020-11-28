using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Regiter_Login.BackEnd
{
    class Empleado
    {
        public int idEmpleado { get; set; }
        public String nombreCompleto { get; set; }
        public String direccion { get; set; }
        public int telefono { get; set; }
        public String usuario { get; set; }
        public String contrasenia { get; set; }
        public String puesto { get; set; }
    }
}
