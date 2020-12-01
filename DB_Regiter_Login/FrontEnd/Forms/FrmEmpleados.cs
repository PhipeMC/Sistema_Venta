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
    public partial class FrmEmpleados : Form
    {
        public FrmEmpleados()
        {
            InitializeComponent();
            
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void checkDireccion_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkDireccion.Checked)
            {
                txtDireccion.Enabled = true;
            }
            else
            {
                txtDireccion.Enabled = false;
            }
        }

        private void checkTel_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkTel.Checked)
            {
                txtTel.Enabled = true;
            }
            else
            {
                txtTel.Enabled = false;
            }
        }
    }
}
