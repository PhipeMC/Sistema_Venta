﻿using System;
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
        private String user;
        private String puesto;

        public Menu()
        {
            InitializeComponent();
        }

        public Menu(String user, String puesto)
        {
            InitializeComponent();
            this.user = user;
            this.puesto = puesto;
        }

        private void btnCajero_Click(object sender, EventArgs e)
        {
            Venta vent = new Venta();
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
            Form1 main = new Form1();
            this.Visible = false;
            main.Visible = true;
        }
    }
}
