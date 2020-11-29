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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnCajero_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ingresando..");
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            this.Visible = false;
            admin.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();
            this.Visible = false;
            main.Visible = true;
        }
    }
}
