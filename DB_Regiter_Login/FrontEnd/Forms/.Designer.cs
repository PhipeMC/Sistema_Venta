namespace DB_Regiter_Login
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txt_nickname = new System.Windows.Forms.TextBox();
            this.panel_nick = new System.Windows.Forms.Panel();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.panel_password = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_close = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pic_password = new System.Windows.Forms.PictureBox();
            this.pic_user = new System.Windows.Forms.PictureBox();
            this.pic_logo = new System.Windows.Forms.PictureBox();
            this.panel_close.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_password)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_user)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_nickname
            // 
            this.txt_nickname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txt_nickname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_nickname.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nickname.ForeColor = System.Drawing.Color.White;
            this.txt_nickname.Location = new System.Drawing.Point(66, 206);
            this.txt_nickname.Name = "txt_nickname";
            this.txt_nickname.Size = new System.Drawing.Size(337, 25);
            this.txt_nickname.TabIndex = 2;
            this.txt_nickname.Text = "Nickname";
            this.txt_nickname.Click += new System.EventHandler(this.txt_nickname_Click);
            this.txt_nickname.Enter += new System.EventHandler(this.txt_nickname_Enter);
            // 
            // panel_nick
            // 
            this.panel_nick.BackColor = System.Drawing.Color.White;
            this.panel_nick.Location = new System.Drawing.Point(24, 239);
            this.panel_nick.Name = "panel_nick";
            this.panel_nick.Size = new System.Drawing.Size(379, 1);
            this.panel_nick.TabIndex = 3;
            // 
            // txt_password
            // 
            this.txt_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txt_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_password.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.ForeColor = System.Drawing.Color.White;
            this.txt_password.Location = new System.Drawing.Point(66, 288);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(336, 25);
            this.txt_password.TabIndex = 5;
            this.txt_password.Text = "Contraseña";
            this.txt_password.Click += new System.EventHandler(this.txt_password_Click);
            this.txt_password.Enter += new System.EventHandler(this.txt_password_Enter);
            this.txt_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_password_KeyPress);
            // 
            // panel_password
            // 
            this.panel_password.BackColor = System.Drawing.Color.White;
            this.panel_password.Location = new System.Drawing.Point(24, 321);
            this.panel_password.Name = "panel_password";
            this.panel_password.Size = new System.Drawing.Size(375, 1);
            this.panel_password.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(95)))), ((int)(((byte)(159)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Help;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button1.Location = new System.Drawing.Point(24, 467);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(375, 45);
            this.button1.TabIndex = 7;
            this.button1.Text = "Iniciar Sesión";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel_close
            // 
            this.panel_close.Controls.Add(this.pictureBox1);
            this.panel_close.Location = new System.Drawing.Point(377, 12);
            this.panel_close.Name = "panel_close";
            this.panel_close.Size = new System.Drawing.Size(45, 25);
            this.panel_close.TabIndex = 10;
            this.panel_close.Click += new System.EventHandler(this.panel_close_Click);
            this.panel_close.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.panel_close.MouseLeave += new System.EventHandler(this.panel_close_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DB_Regiter_Login.Properties.Resources.delete_48px;
            this.pictureBox1.Location = new System.Drawing.Point(13, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // pic_password
            // 
            this.pic_password.Image = global::DB_Regiter_Login.Properties.Resources.password_48px;
            this.pic_password.Location = new System.Drawing.Point(24, 283);
            this.pic_password.Name = "pic_password";
            this.pic_password.Size = new System.Drawing.Size(32, 32);
            this.pic_password.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_password.TabIndex = 4;
            this.pic_password.TabStop = false;
            // 
            // pic_user
            // 
            this.pic_user.Image = global::DB_Regiter_Login.Properties.Resources.male_user_48px;
            this.pic_user.Location = new System.Drawing.Point(24, 201);
            this.pic_user.Name = "pic_user";
            this.pic_user.Size = new System.Drawing.Size(32, 32);
            this.pic_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_user.TabIndex = 1;
            this.pic_user.TabStop = false;
            // 
            // pic_logo
            // 
            this.pic_logo.Image = ((System.Drawing.Image)(resources.GetObject("pic_logo.Image")));
            this.pic_logo.Location = new System.Drawing.Point(179, 12);
            this.pic_logo.Name = "pic_logo";
            this.pic_logo.Size = new System.Drawing.Size(100, 100);
            this.pic_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_logo.TabIndex = 0;
            this.pic_logo.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(434, 619);
            this.Controls.Add(this.panel_close);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel_password);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.pic_password);
            this.Controls.Add(this.panel_nick);
            this.Controls.Add(this.txt_nickname);
            this.Controls.Add(this.pic_user);
            this.Controls.Add(this.pic_logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(450, 720);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_close.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_password)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_user)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_logo;
        private System.Windows.Forms.PictureBox pic_user;
        private System.Windows.Forms.TextBox txt_nickname;
        private System.Windows.Forms.Panel panel_nick;
        private System.Windows.Forms.PictureBox pic_password;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Panel panel_password;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel_close;
    }
}

