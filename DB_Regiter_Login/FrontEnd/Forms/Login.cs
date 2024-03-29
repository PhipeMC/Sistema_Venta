﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB_Regiter_Login.Forms;
using DB_Regiter_Login.MySQL;

namespace DB_Regiter_Login
{
    public partial class Form1 : Form
    {
        private static DBConnect Connection = new DBConnect();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pic_logo.Location = new Point(this.Width/2 - 50,50);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string>[] list = new List<string>[4];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list = Connection.Select();
        }
        private void txt_nickname_Click(object sender, EventArgs e)
        {
            if (txt_nickname.Text.Equals("Nickname"))
            {
                txt_nickname.Clear();
                pic_user.Image = Properties.Resources.male_user_48px_selected;
                panel_nick.BackColor = Color.FromArgb(4, 95, 159);
                txt_nickname.ForeColor = Color.FromArgb(4, 95, 159);

                pic_password.Image = Properties.Resources.password_48px;
                panel_password.BackColor = Color.FromArgb(240, 240, 240);
                txt_password.ForeColor = Color.FromArgb(240, 240, 240);
            }
            else {
                pic_user.Image = Properties.Resources.male_user_48px_selected;
                panel_nick.BackColor = Color.FromArgb(4, 95, 159);
                txt_nickname.ForeColor = Color.FromArgb(4, 95, 159);

                pic_password.Image = Properties.Resources.password_48px;
                panel_password.BackColor = Color.FromArgb(240, 240, 240);
                txt_password.ForeColor = Color.FromArgb(240, 240, 240);
            }
        }
        private void txt_password_Click(object sender, EventArgs e)
        {
            if (txt_password.Text.Equals("Contraseña"))
            {
                txt_password.Clear();
                txt_password.PasswordChar = '*';
                pic_password.Image = Properties.Resources.password_48px_selected;
                panel_password.BackColor = Color.FromArgb(4, 95, 159);
                txt_password.ForeColor = Color.FromArgb(4, 95, 159);

                pic_user.Image = Properties.Resources.male_user_48px;
                panel_nick.BackColor = Color.FromArgb(240, 240, 240);
                txt_nickname.ForeColor = Color.FromArgb(240, 240, 240);
            }
            else {
                txt_password.PasswordChar = '*';
                pic_password.Image = Properties.Resources.password_48px_selected;
                panel_password.BackColor = Color.FromArgb(4, 95, 159);
                txt_password.ForeColor = Color.FromArgb(4, 95, 159);

                pic_user.Image = Properties.Resources.male_user_48px;
                panel_nick.BackColor = Color.FromArgb(240, 240, 240);
                txt_nickname.ForeColor = Color.FromArgb(240, 240, 240);
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Check_Login();
        }

        private void txt_nickname_Enter(object sender, EventArgs e)
        {
            if (txt_nickname.Text.Equals("Nickname"))
            {
                txt_nickname.Clear();
                pic_user.Image = Properties.Resources.male_user_48px_selected;
                panel_nick.BackColor = Color.FromArgb(4, 95, 159);
                txt_nickname.ForeColor = Color.FromArgb(4, 95, 159);

                pic_password.Image = Properties.Resources.password_48px;
                panel_password.BackColor = Color.FromArgb(240, 240, 240);
                txt_password.ForeColor = Color.FromArgb(240, 240, 240);
            }
            else
            {
                pic_user.Image = Properties.Resources.male_user_48px_selected;
                panel_nick.BackColor = Color.FromArgb(4, 95, 159);
                txt_nickname.ForeColor = Color.FromArgb(4, 95, 159);

                pic_password.Image = Properties.Resources.password_48px;
                panel_password.BackColor = Color.FromArgb(240, 240, 240);
                txt_password.ForeColor = Color.FromArgb(240, 240, 240);
            }
        }

        private void txt_password_Enter(object sender, EventArgs e)
        {
            if (txt_password.Text.Equals("Contraseña"))
            {
                txt_password.Clear();
                txt_password.PasswordChar = '*';
                pic_password.Image = Properties.Resources.password_48px_selected;
                panel_password.BackColor = Color.FromArgb(4, 95, 159);
                txt_password.ForeColor = Color.FromArgb(4, 95, 159);

                pic_user.Image = Properties.Resources.male_user_48px;
                panel_nick.BackColor = Color.FromArgb(240, 240, 240);
                txt_nickname.ForeColor = Color.FromArgb(240, 240, 240);
            }
            else
            {
                txt_password.PasswordChar = '*';
                pic_password.Image = Properties.Resources.password_48px_selected;
                panel_password.BackColor = Color.FromArgb(4, 95, 159);
                txt_password.ForeColor = Color.FromArgb(4, 95, 159);

                pic_user.Image = Properties.Resources.male_user_48px;
                panel_nick.BackColor = Color.FromArgb(240, 240, 240);
                txt_nickname.ForeColor = Color.FromArgb(240, 240, 240);
            }
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel_close.BackColor = Color.FromArgb(50,50,50);
        }

        private void panel_close_MouseLeave(object sender, EventArgs e)
        {
            panel_close.BackColor = Color.FromArgb(30,30,30);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            panel_close.BackColor = Color.FromArgb(50, 50, 50);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            panel_close.BackColor = Color.FromArgb(30, 30, 30);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Metodo para hacer la conexion con la BD y verificar si es el usario correcto
        /// </summary>
        private void Check_Login() {
            try
            {
                if (Connection.Check(txt_nickname.Text, txt_password.Text))
                {
                    String puesto = Connection.get_Puesto(txt_nickname.Text);
                    FrontEnd.Forms.Menu FrmCliente = new FrontEnd.Forms.Menu(txt_nickname.Text, puesto,this);
                    FrmCliente.Visible = true;
                    this.Visible = false;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Verifica nuevamente los datos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar) {
                case '\r':
                    Check_Login();
                    break;
            }
        }
    }
}
