namespace Banking_System
{
    partial class SQLServerConnectionscs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbServer = new System.Windows.Forms.ComboBox();
            this.lbBase = new System.Windows.Forms.Label();
            this.cbDataBase = new System.Windows.Forms.ComboBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lbServidor = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.rbAuthenticationWin = new System.Windows.Forms.RadioButton();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.lbClave = new System.Windows.Forms.Label();
            this.rbAuthenticationSql = new System.Windows.Forms.RadioButton();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbServer
            // 
            this.cbServer.FormattingEnabled = true;
            this.cbServer.Location = new System.Drawing.Point(12, 54);
            this.cbServer.Name = "cbServer";
            this.cbServer.Size = new System.Drawing.Size(232, 21);
            this.cbServer.TabIndex = 44;
            // 
            // lbBase
            // 
            this.lbBase.AutoSize = true;
            this.lbBase.Location = new System.Drawing.Point(3, 29);
            this.lbBase.Name = "lbBase";
            this.lbBase.Size = new System.Drawing.Size(161, 13);
            this.lbBase.TabIndex = 36;
            this.lbBase.Text = "Select or enter a database name";
            // 
            // cbDataBase
            // 
            this.cbDataBase.FormattingEnabled = true;
            this.cbDataBase.Location = new System.Drawing.Point(25, 45);
            this.cbDataBase.Name = "cbDataBase";
            this.cbDataBase.Size = new System.Drawing.Size(268, 21);
            this.cbDataBase.TabIndex = 27;
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.Controls.Add(this.lbBase);
            this.GroupBox1.Controls.Add(this.cbDataBase);
            this.GroupBox1.Location = new System.Drawing.Point(15, 226);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(317, 108);
            this.GroupBox1.TabIndex = 49;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Connect to database";
            // 
            // btnTest
            // 
            this.btnTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTest.Location = new System.Drawing.Point(250, 353);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(82, 23);
            this.btnTest.TabIndex = 48;
            this.btnTest.Text = "Test";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 353);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(144, 23);
            this.btnOK.TabIndex = 47;
            this.btnOK.Tag = "";
            this.btnOK.Text = "Save Connection and Exit";
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCancel.Location = new System.Drawing.Point(162, 353);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 23);
            this.btnCancel.TabIndex = 46;
            this.btnCancel.Text = "Cancel";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(250, 52);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(82, 23);
            this.btnRefresh.TabIndex = 45;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lbServidor
            // 
            this.lbServidor.AutoSize = true;
            this.lbServidor.BackColor = System.Drawing.Color.Transparent;
            this.lbServidor.Location = new System.Drawing.Point(12, 38);
            this.lbServidor.Name = "lbServidor";
            this.lbServidor.Size = new System.Drawing.Size(69, 13);
            this.lbServidor.TabIndex = 43;
            this.lbServidor.Text = "Server Name";
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox2.Controls.Add(this.txtPassword);
            this.GroupBox2.Controls.Add(this.txtUser);
            this.GroupBox2.Controls.Add(this.rbAuthenticationWin);
            this.GroupBox2.Controls.Add(this.lbUsuario);
            this.GroupBox2.Controls.Add(this.lbClave);
            this.GroupBox2.Controls.Add(this.rbAuthenticationSql);
            this.GroupBox2.Location = new System.Drawing.Point(15, 81);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(317, 128);
            this.GroupBox2.TabIndex = 50;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Log on to the server";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(81, 98);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(212, 20);
            this.txtPassword.TabIndex = 8;
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.Enabled = false;
            this.txtUser.Location = new System.Drawing.Point(81, 72);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(212, 20);
            this.txtUser.TabIndex = 7;
            // 
            // rbAuthenticationWin
            // 
            this.rbAuthenticationWin.AutoSize = true;
            this.rbAuthenticationWin.Checked = true;
            this.rbAuthenticationWin.Location = new System.Drawing.Point(13, 20);
            this.rbAuthenticationWin.Name = "rbAuthenticationWin";
            this.rbAuthenticationWin.Size = new System.Drawing.Size(162, 17);
            this.rbAuthenticationWin.TabIndex = 3;
            this.rbAuthenticationWin.TabStop = true;
            this.rbAuthenticationWin.Text = "Use Windows Authentication";
            this.rbAuthenticationWin.UseVisualStyleBackColor = true;
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Location = new System.Drawing.Point(22, 75);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(29, 13);
            this.lbUsuario.TabIndex = 9;
            this.lbUsuario.Text = "User";
            // 
            // lbClave
            // 
            this.lbClave.AutoSize = true;
            this.lbClave.Location = new System.Drawing.Point(22, 101);
            this.lbClave.Name = "lbClave";
            this.lbClave.Size = new System.Drawing.Size(53, 13);
            this.lbClave.TabIndex = 10;
            this.lbClave.Text = "Password";
            // 
            // rbAuthenticationSql
            // 
            this.rbAuthenticationSql.AutoSize = true;
            this.rbAuthenticationSql.Location = new System.Drawing.Point(13, 42);
            this.rbAuthenticationSql.Name = "rbAuthenticationSql";
            this.rbAuthenticationSql.Size = new System.Drawing.Size(173, 17);
            this.rbAuthenticationSql.TabIndex = 4;
            this.rbAuthenticationSql.Text = "Use SQL Server Authentication";
            // 
            // SQLServerConnectionscs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(376, 441);
            this.Controls.Add(this.cbServer);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lbServidor);
            this.Controls.Add(this.GroupBox2);
            this.Name = "SQLServerConnectionscs";
            this.Text = "SQLServerConnectionscs";
            this.Load += new System.EventHandler(this.SQLServerConnectionscs_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox cbServer;
        internal System.Windows.Forms.Label lbBase;
        internal System.Windows.Forms.ComboBox cbDataBase;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnTest;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.Label lbServidor;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.TextBox txtUser;
        internal System.Windows.Forms.RadioButton rbAuthenticationWin;
        internal System.Windows.Forms.Label lbUsuario;
        internal System.Windows.Forms.Label lbClave;
        internal System.Windows.Forms.RadioButton rbAuthenticationSql;
    }
}