using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Regiter_Login.Forms
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente client = new Cliente();
            this.Visible = false;
            client.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ingresando..");
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ingresando..");
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ingresando..");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Forms.Menu main = new Forms.Menu();
            this.Visible = false;
            main.Visible = true;
        }
    }
}
