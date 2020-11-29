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
    public partial class Program_Data : Form
    {
        private static DBConnect Connection = new DBConnect();
        private int User;
        private Form1 LogIn;
        public Program_Data()
        {
            InitializeComponent();
        }

        public Program_Data(int idUser, Form1 login_frame)
        {
            InitializeComponent();
            this.User = idUser;
            this.LogIn = login_frame;
        }

        private void Program_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Location = new Point((this.tabControl1.Location.X / 2 - 50), this.pictureBox1.Location.Y);
            startLabel();
        }

        private void startLabel(){
            this.label1.Text = String.Format("¡Bienvenido\n{0}!", Connection.getName(this.User));
            this.label1.Location = new Point((this.tabControl1.Location.X / 2 )-46, this.label1.Location.Y);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LogIn.Close();
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            panel_close.BackColor = Color.FromArgb(50, 50, 50);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            panel_close.BackColor = Color.FromArgb(45, 45, 48);
        }

        private void panel_close_Click(object sender, EventArgs e)
        {
            LogIn.Close();
        }

        private void panel_close_MouseEnter(object sender, EventArgs e)
        {
            panel_close.BackColor = Color.FromArgb(50, 50, 50);
        }

        private void panel_close_MouseLeave(object sender, EventArgs e)
        {
            panel_close.BackColor = Color.FromArgb(45, 45, 48);
        }

        private void fillTable() {
            DataTable table = new DataTable();
            table.Columns.Add("Mensaje encriptado", typeof(String));
            getData(table);
        }

        private void getData(DataTable table) {
            if (!Connection.selectMessages(this.User).Equals(""))
            {
                List<String>[] uncrypted = Connection.selectMessages2(this.User);
                foreach (String str in uncrypted[0])
                {
                    if (!str.Equals(""))
                    {
                        table.Rows.Add(str);
                    }
                }
                dataGridView1.DataSource = table;
            }
            else {
                MessageBox.Show("Aun no hay mensajes :(", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_message.Text.Equals(""))
            {
                MessageBox.Show("Inserta un mensaje valido", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                if (txt_message.Text.Length <= 50)
                {
                    DateTime thisDay = DateTime.Today;
                    if (Connection.selectMessages(this.User).Equals(""))
                    {
                        String str_data = String.Empty;
                        str_data = String.Format("{0}^", String.Format("{0}|{1}", thisDay.ToString("g"), txt_message.Text));
                        Connection.InsertMessage(this.User, str_data);
                        txt_message.Clear();
                    }
                    else
                    {
                        String str_data = String.Empty;
                        str_data = String.Format("{0}^{1}", Connection.selectMessages(this.User), String.Format("{0}|{1}", thisDay.ToString("g"), txt_message.Text));
                        Connection.updateMessage(this.User, str_data);
                        txt_message.Clear();
                    }
                }
                else {
                    MessageBox.Show("Has superado el maximo numero de caracteres admitidos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_decript_Click(object sender, EventArgs e)
        {
            fillTable();
        }

        private void panel_mini_MouseEnter(object sender, EventArgs e)
        {
            panel_mini.BackColor = Color.FromArgb(50, 50, 50);
        }

        private void panel_mini_MouseLeave(object sender, EventArgs e)
        {
            panel_mini.BackColor = Color.FromArgb(45, 45, 48);
        }

        private void panel_mini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            panel_mini.BackColor = Color.FromArgb(50, 50, 50);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            panel_mini.BackColor = Color.FromArgb(45, 45, 48);
        }

        private void txt_message_Click(object sender, EventArgs e)
        {
            if (txt_message.Text.Equals("Escribe aqui tu mensaje")) {
                txt_message.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fillTable2();
        }

        private void fillTable2()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mensaje encriptado", typeof(String));
            table.Columns.Add("Fecha", typeof(String));
            table.Columns.Add("Mensaje desencriptado", typeof(String));
            getData2(table);
        }

        private void getData2(DataTable table)
        {
            if (!Connection.selectMessages(this.User).Equals(""))
            {
                String[] data = Connection.selectMessages(this.User).Split('^');
                List<String>[] uncrypted = Connection.selectMessages2(this.User);
                foreach (String str in data)
                {
                    if (!str.Equals(""))
                    {
                        String[] messageData = str.Split('|');
                        table.Rows.Add(uncrypted[0][0],messageData[0],messageData[1]);
                    }
                }
                dataGridView1.DataSource = table;
            }
            else
            {
                MessageBox.Show("Aun no hay mensajes :(", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
