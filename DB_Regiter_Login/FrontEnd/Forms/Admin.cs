using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB_Regiter_Login.Forms;

namespace DB_Regiter_Login.FrontEnd.Forms
{
    public partial class Admin : Form
    {
        private String user;
        private String puesto;
        public Form1 login;
        public Admin()
        {
            InitializeComponent();
        }
        public Admin(String user, String puesto, Form1 frmMain)
        {
            InitializeComponent();
            this.user = user;
            this.puesto = puesto;
            this.login = frmMain;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Cliente cl = new Cliente();
            //MessageBox.Show("Ingresando..");
            cl.Visible = true;
            this.Visible = false;
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            FrmEmpleados em = new FrmEmpleados();
            em.Visible = true;
            this.Visible = false;
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            Proveedores p = new Proveedores();
            MessageBox.Show("Ingresando..");
            p.Visible = true;
            this.Visible = false;
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Producto pr = new Producto();
            pr.Visible = true;
            this.Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            FrontEnd.Forms.Menu main = new FrontEnd.Forms.Menu(this.user, this.puesto, this.login);
            this.Visible = false;
            main.Visible = true;
        }
    }
}
