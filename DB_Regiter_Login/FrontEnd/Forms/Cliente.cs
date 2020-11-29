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
        }
    }
}
