using DB_Regiter_Login.BackEnd;
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

namespace DB_Regiter_Login.FrontEnd.Forms
{
    public partial class Proveedores : Form
    {
        private static DBConnect Connection = new DBConnect();
        private Form FrmMain;
        Proveedor p = new Proveedor();

        public Proveedores()
        {
            InitializeComponent();
        }

        public Proveedores(Form f)
        {
            InitializeComponent();
            this.FrmMain = f;
        }

        /// <summary>
        /// Acciona el proceso para el inseert de un proveedor
        /// </summary>
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            String mensaje = verificaciones();
            if (mensaje.Length == 0)
            {
                try
                {
                    Connection.insertProveedores(txtNombre.Text, txtDomicilio.Text, txtTelefono.Text); ;
                    fill_Table();
                    txtNombre.Clear();
                    txtDomicilio.Clear();
                    txtTelefono.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Ha ocurrido el siguiente error\n{0}", ex.ToString()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Acciona el proceso para el update de un proveedor
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            String mensaje = verificacionesModificar();
            if (mensaje.Length == 0)
            {
                try
                {
                    Connection.updateProveedores(Convert.ToInt32(txtId.Text), txtNombreMod.Text, txtDomicilioMod.Text, txtTelefonoMod.Text); ;
                    fill_Table();
                    txtId.Clear();
                    txtNombreMod.Clear();
                    txtDomicilioMod.Clear();
                    txtTelefonoMod.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Ha ocurrido el siguiente error\n{0}", ex.ToString()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Elimina un elemento de la tabla de proveedores atraves de elegir un valor de la tabla
        /// </summary>
        private void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.deleteProveedores(Convert.ToInt32(txtId.Text)); 
                fill_Table();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Ha ocurrido el siguiente error\n{0}", ex.ToString()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// verifica que lo que este, este en orden lo que se ingresa en el insert
        /// </summary>
        private String verificaciones()
        {

            if (txtDomicilio.Text.Length == 0 || txtNombre.Text.Length == 0 || txtTelefono.Text.Length == 0)
            {
                return "Uno de los campos se encuenytra sin llenar,debe llenar todos los campos para continuar";
            }
            else
            {
                if (txtDomicilio.Text.Length > 30)
                {
                    return "El domicilio es muy largo";
                }
                else if (txtNombre.Text.Length > 60)
                {
                    return "El domicilio es muy largo";
                }
                else if (txtTelefono.Text.Length > 0)
                {
                    if (txtTelefono.Text.Length != 10)
                    {
                        return "Ingrese un mnumero valido de 10 digitos";
                    }
                    else
                    {
                        String tmp = txtTelefono.Text;
                        for (int i = 0; i < txtTelefono.Text.Length; i++)
                        {
                            if (tmp[i] < 48 || tmp[i] > 57)
                            {
                                return "El numero de telefono solo debe de conformarse por digitos decimales";
                            }
                        }
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// verifica que lo que este, este en orden lo que se ingresa en el update
        /// </summary>
        private String verificacionesModificar()
        {

            if (txtDomicilioMod.Text.Length == 0 || txtNombreMod.Text.Length == 0 || txtTelefonoMod.Text.Length == 0)
            {
                return "Uno de los campos se encuenytra sin llenar,debe llenar todos los campos para continuar";
            }
            else
            {
                if (txtDomicilioMod.Text.Length > 30)
                {
                    return "El domicilio es muy largo";
                }
                else if (txtNombreMod.Text.Length > 60)
                {
                    return "El domicilio es muy largo";
                }
                else if (txtTelefonoMod.Text.Length > 0)
                {
                    if (txtTelefonoMod.Text.Length != 10)
                    {
                        return "Ingrese un mnumero valido de 10 digitos";
                    }
                    else
                    {
                        String tmp = txtTelefonoMod.Text;
                        for (int i = 0; i < txtTelefonoMod.Text.Length; i++)
                        {
                            if (tmp[i] < 48 || tmp[i] > 57)
                            {
                                return "El numero de telefono solo debe de conformarse por digitos decimales";
                            }
                        }
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// Llena la tabla de los proveedores al iniciar
        /// </summary>
        private void fill_Table()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(String));
            table.Columns.Add("Nombre", typeof(String));
            table.Columns.Add("Direccion", typeof(String));
            table.Columns.Add("Telefono", typeof(String));
            List<String>[] proveedores = Connection.SelectProveedores();
            for (int i = 0; i < proveedores[0].Count(); i++)
            {
                table.Rows.Add(proveedores[0][i], proveedores[1][i], proveedores[2][i], proveedores[3][i]);
            }
            dataGridView1.DataSource = table;
        }

        /// <summary>
        /// Llenar la tabla cada que se entre al form
        /// </summary>
        private void Proveedores_Load(object sender, EventArgs e)
        {
            fill_Table();
        }

        /// <summary>
        /// Regresar al menu de administrador, dandole clic a la flecha
        /// </summary>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Visible = true;
            this.Close();
        }

        /// <summary>
        /// Regresar al menu de administrador dandole clic a la etiqueta
        /// </summary>
        private void lblRegresar_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Visible = true;
            this.Close();
        }

        /// <summary>
        /// Permite seleccionar los datos atraves de dar clic en una celda de la tabla, ya sea para el update o el delete
        /// </summary>
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            String claveSelec = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            List<String>[] data_user = Connection.SelectProveedores(claveSelec);
            txtId.Text = data_user[0][0];
            txtNombreMod.Text = data_user[1][0];
            txtDomicilioMod.Text = data_user[2][0];
            txtTelefonoMod.Text = data_user[3][0];

            p.idProveedor = Convert.ToInt32(data_user[0][0]);
            p.nombreCompleto = data_user[1][0];
            p.direccion = data_user[2][0];
            p.telefono = data_user[3][0];
        }


    }
}
