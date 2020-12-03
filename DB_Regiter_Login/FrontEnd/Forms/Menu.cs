using DB_Regiter_Login.MySQL;
using DB_Regiter_Login.Properties;
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
    public partial class Menu : Form
    {
        private static DBConnect Connection = new DBConnect();
        private String user;
        private String puesto;
        public Form1 login;

        public Menu()
        {
            InitializeComponent();
        }

        public Menu(String user, String puesto, Form1 frmMain)
        {
            InitializeComponent();
            this.user = user;
            this.puesto = puesto;
            this.login = frmMain;
        }

        private void btnCajero_Click(object sender, EventArgs e)
        {
            Venta vent = new Venta(this);
            this.Visible = false;
            vent.Visible = true;
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            this.Visible = false;
            admin.Visible = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //Form1 main = new Form1();
            //this.Visible = false;
            //main.Visible = true;

            this.Close();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            sound_login();
            lbl_user.Text = String.Format("Bienvenido {0}", Connection.get_Nombre(user));
            panel2.Location = new Point((this.Width / 2)-panel2.Width/2,panel2.Location.Y);
        }

        public void sound_login() {
            using (var soundPlayer = new System.Media.SoundPlayer(Resources.Vista_MSNMSGR_NewMail))
            {
                soundPlayer.Play();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            login.Close();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(169, 160, 160);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(240, 240, 240);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Venta vent = new Venta(this);
            this.Visible = false;
            vent.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Venta vent = new Venta(this);
            this.Visible = false;
            vent.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Venta vent = new Venta(this);
            this.Visible = false;
            vent.Visible = true;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(225, 225, 225);
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(225, 225, 225);
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(225, 225, 225);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(240, 240, 240);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(240, 240, 240);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(240, 240, 240);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (puesto.Equals("admin"))
            {
                Admin admin = new Admin();
                this.Visible = false;
                admin.Visible = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (puesto.Equals("admin"))
            {
                Admin admin = new Admin();
                this.Visible = false;
                admin.Visible = true;
            }
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            if (puesto.Equals("admin"))
            {
                Admin admin = new Admin();
                this.Visible = false;
                admin.Visible = true;
            }
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            if (puesto.Equals("admin")) {
                panel3.BackColor = Color.FromArgb(225, 225, 225);
            }
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            if (puesto.Equals("admin"))
            {
                panel3.BackColor = Color.FromArgb(225, 225, 225);
            }
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            if (puesto.Equals("admin"))
            {
                panel3.BackColor = Color.FromArgb(225, 225, 225);
            }
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            if (puesto.Equals("admin"))
            {
                panel3.BackColor = Color.FromArgb(240, 240, 240);
            }
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            if (puesto.Equals("admin"))
            {
                panel3.BackColor = Color.FromArgb(240, 240, 240);
            }
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            if (puesto.Equals("admin"))
            {
                panel3.BackColor = Color.FromArgb(240, 240, 240);
            }
        }
    }
}
