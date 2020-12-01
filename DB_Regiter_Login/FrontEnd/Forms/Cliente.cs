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
    public partial class Cliente : Form
    {
        private static DBConnect Connection = new DBConnect();
        private Form1 FrmMain;
        public Cliente()
        {
            InitializeComponent();
        }

        public Cliente(Form1 Main)
        {
            InitializeComponent();
            this.FrmMain = Main;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Llena la tabla de los clientes al iniciar
        /// </summary>
        private void fill_Table() {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(String));
            table.Columns.Add("Nombre", typeof(String));
            table.Columns.Add("RFC", typeof(String));
            table.Columns.Add("Direccion", typeof(String));
            table.Columns.Add("Telefono", typeof(String));
            List<String>[] clientes = Connection.SelectClientes();
            for (int i = 0; i < clientes[0].Count(); i++)
            {
                table.Rows.Add(clientes[0][i],clientes[1][i],clientes[2][i],clientes[3][i],clientes[4][i]);
            }
            dataGridView1.DataSource = table;
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            fill_Table();
            txt_ID.Text = Connection.get_Last_ID_Client().ToString();
            lbl_user.Text = String.Format("Bienvenido ");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (txt_number.TextLength > 10) {
                txt_number.Text = txt_number.Text.Substring(0,txt_number.TextLength-1);
                MessageBox.Show("Ingrese un numero telefonico valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            txt_ID.Text = Connection.get_Last_ID_Client().ToString();
        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            String claveSelec = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            List<String>[] data_user = Connection.SelectClientes(claveSelec);
            txt_ID_update.Text = data_user[0][0];
            txt_name_update.Text = data_user[1][0];
            txt_address_update.Text = data_user[3][0];
            txt_celphone_update.Text = data_user[4][0];
            txt_RFC_update.Text = data_user[2][0];
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            String claveSelec = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            List<String>[] data_user = Connection.SelectClientes(claveSelec);
            txt_ID_update.Text = data_user[0][0];
            txt_name_update.Text = data_user[1][0];
            txt_address_update.Text = data_user[3][0];
            txt_celphone_update.Text = data_user[4][0];
            txt_RFC_update.Text = data_user[2][0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (verification_update())
            {
                try
                {
                    Connection.update_Client(Convert.ToInt32(txt_ID_update.Text), txt_name_update.Text, txt_address_update.Text, txt_celphone_update.Text, txt_RFC_update.Text);
                    fill_Table();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Ha ocurrido el siguiente error\n{0}", ex.ToString()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingresa los campos correspondientes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (verification()) {
                try
                {
                    Connection.add_Client(Convert.ToInt32(txt_ID.Text), txt_name.Text, txt_address.Text, txt_number.Text, txt_RFC.Text);
                    clear_and_Fill();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Ha ocurrido el siguiente error\n{0}", ex.ToString()),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else {
                MessageBox.Show("Ingresa los campos correspondientes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        /// <summary>
        /// Metodo para vaciar las casillas y actualizar la tabla
        /// </summary>
        private void clear_and_Fill() {
            txt_ID.Clear();
            txt_name.Clear();
            txt_address.Clear();
            txt_number.Clear();
            txt_RFC.Clear();
            txt_ID.Text = Connection.get_Last_ID_Client().ToString();
            fill_Table();
        }

        private Boolean verification() {
            if (txt_name.Text.Equals("") || txt_address.Text.Equals("") || txt_RFC.Text.Equals("") || txt_number.TextLength < 10) {
                return false;
            }
            return true;
        }

        private Boolean verification_update()
        {
            if (txt_name_update.Text.Equals("") || txt_address_update.Text.Equals("") || txt_RFC_update.Text.Equals("") || txt_celphone_update.TextLength < 10)
            {
                return false;
            }
            return true;
        }

        private void txt_celphone_update_TextChanged(object sender, EventArgs e)
        {
            if (txt_celphone_update.TextLength > 10)
            {
                txt_celphone_update.Text = txt_celphone_update.Text.Substring(0, txt_celphone_update.TextLength - 1);
                MessageBox.Show("Ingrese un numero telefonico valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(169,160,160);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(240,240,240);
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(169, 160, 160);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(169, 160, 160);
        }
    }
}
