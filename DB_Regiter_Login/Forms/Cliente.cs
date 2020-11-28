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

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(String));
            table.Columns.Add("Nombre", typeof(String));
            table.Columns.Add("Direccion", typeof(String));
            table.Columns.Add("Telefono", typeof(String));
            List<String>[] proveedores = Connection.SelectProveedores();
            foreach (String str in proveedores[])
            {
                table.Rows.Add(str);
            }
            dataGridView1.DataSource = table;
        }
    }
}
