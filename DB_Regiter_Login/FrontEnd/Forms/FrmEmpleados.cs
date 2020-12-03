using DB_Regiter_Login.BackEnd;
using DB_Regiter_Login.FrontEnd.Forms;
using DB_Regiter_Login.MySQL;
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
        private static DBConnect conexion=new DBConnect();
        public FrmEmpleados()
        {
            InitializeComponent();
            
        }

        private void fill_Table()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(String));
            table.Columns.Add("Nombre", typeof(String));
            table.Columns.Add("Direccion", typeof(String));
            table.Columns.Add("Teléfono", typeof(String));
            table.Columns.Add("Usuario", typeof(String));
            table.Columns.Add("Contraseña", typeof(String));
            table.Columns.Add("Puesto", typeof(String));
            List<Empleado> empleados = conexion.SelectEmpleados();
            for (int i = 0; i < empleados.Count; i++)
            {
                table.Rows.Add(empleados[i].idEmpleado,empleados[i].nombreCompleto,empleados[i].direccion,
                 empleados[i].telefono,empleados[i].usuario,empleados[i].contrasenia,empleados[i].puesto);
                
            }
            tblDatos.DataSource = table;
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            fill_Table();
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Admin ad = new Admin();
            ad.Visible = true;
            this.Visible = false;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Admin ad = new Admin();
            ad.Visible = true;
            this.Visible = false;
        }

        private void label9_MouseClick(object sender, MouseEventArgs e)
        {
            Admin ad = new Admin();
            ad.Visible = true;
            this.Visible = false;
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(169, 160, 160);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(240, 240, 240);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(169, 160, 160);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(240, 240, 240);
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(169, 160, 160);
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(240, 240, 240);
        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            String claveSelec = tblDatos.Rows[tblDatos.CurrentRow.Index].Cells[0].Value.ToString();
            Empleado empleado = conexion.SelectEmpleado(claveSelec);
            txtNombreAct.Text = empleado.nombreCompleto;
            txtDireccionAct.Text = empleado.direccion;
            txtTelAct.Text = empleado.telefono;
            txtPuestoAct.Text = empleado.puesto;
        }

        private void tblDatos_Click(object sender, EventArgs e)
        {
            String claveSelec = tblDatos.Rows[tblDatos.CurrentRow.Index].Cells[0].Value.ToString();
            Empleado empleado = conexion.SelectEmpleado(claveSelec);
            txtNombreAct.Text = empleado.nombreCompleto;
            txtDireccionAct.Text = empleado.direccion;
            txtTelAct.Text = empleado.telefono;
            txtPuestoAct.Text = empleado.puesto;
        }

        private void tblDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
