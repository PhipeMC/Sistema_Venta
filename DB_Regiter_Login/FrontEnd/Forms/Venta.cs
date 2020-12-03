using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Regiter_Login.FrontEnd.Forms
{
    public partial class Venta : Form
    {
        private static MySQL.DBConnect Connection = new MySQL.DBConnect();
        bool press = false;
        string res = "";
        private Menu Frm_Menu;
        public Venta()
        {
            InitializeComponent();
        }

        public Venta(Menu menu_frame)
        {
            InitializeComponent();
            this.Frm_Menu = menu_frame;
        }

        private bool ValidarVenta()
        {
            bool ok = true;
            DateTime fecha;
            if (txtFecha.Text == "" || txtIDEmpleado.Text == "" || txtIDCliente.Text == "")
            {
                ok = false;
            }
            if (!DateTime.TryParse(txtFecha.Text, out fecha))
            {
                ok = false;
                MessageBox.Show("Solo puede insertar Fechas");
            }
            return ok;
        }
        private bool Validar()
        {
            bool ok = true;
            int num;
            decimal des;
            if (txtProducto.Text == "" || txtCantidad.Text=="" || txtFecha.Text=="" || txtIDEmpleado.Text=="" || txtIDCliente.Text=="")
            {
                ok = false;
            }
            if (!int.TryParse(txtCantidad.Text, out num))
            {
                ok = false;
                MessageBox.Show("Solo puede insertar números en cantidad");
            }
            if (!int.TryParse(txtIDCliente.Text, out num))
            {
                ok = false;
                MessageBox.Show("Solo puede insertar números en IDCliente");
            }
            if (!int.TryParse(txtIDEmpleado.Text, out num))
            {
                ok = false;
                MessageBox.Show("Solo puede insertar números en IDEmpleado");
            }
            if (!decimal.TryParse(txtDescuento.Text, out des))
            {
                ok = false;
                MessageBox.Show("Solo puede insertar números con punto decimal en Descuento");
            }
            
            return ok;
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            List<string>[] venta = new List<string>[3];
            List<string>[] venta2 = Connection.SelectVenta(txtProducto.Text);
            venta[0] = new List<string>();
            venta[1] = new List<string>();
            venta[2] = new List<string>();
            try
            {
                if (Validar())
                {
                    if (press == true)
                    {
                        Connection.InsertarVenta(txtCantidad.Text, txtDescuento.Text, txtProducto.Text);
                        venta[0].Add(txtProducto.Text);
                        venta[1].Add(txtCantidad.Text);
                        venta[2].Add(txtDescuento.Text);
                        tblVenta.Rows.Add(venta[0][0], venta2[0][0], venta[1][0], venta[2][0], res, venta2[2][0]);
                    }
                    else
                    {
                        MessageBox.Show("Primero tiene que crear la venta");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Frm_Menu.Visible = true;
            this.Close();
            
        }

        private void btnCrearVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarVenta())
                {
                    res = Connection.CrearVenta(txtFecha.Text, txtIDEmpleado.Text, txtIDCliente.Text);
                    press = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Venta_Load(object sender, EventArgs e)
        {
            press = false;
        }
    }
}
