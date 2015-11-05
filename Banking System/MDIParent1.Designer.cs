namespace Banking_System
{
    partial class MDIParent1
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
            this.components = new System.ComponentModel.Container();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnsingin = new System.Windows.Forms.Button();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnTransact = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlTransact = new System.Windows.Forms.Panel();
            this.btnbalance = new System.Windows.Forms.Button();
            this.btnWithdraw = new System.Windows.Forms.Button();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnDeposite = new System.Windows.Forms.Button();
            this.pnlAccount = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.btnNewAcc = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.pnlNavigation.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlTransact.SuspendLayout();
            this.pnlAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip.Location = new System.Drawing.Point(0, 710);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1362, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            this.statusStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip_ItemClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = ".";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(76, 17);
            this.toolStripStatusLabel2.Text = "Signed in as :";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(112, 17);
            this.toolStripStatusLabel3.Text = "Employee Number :";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel4.Text = ".";
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.White;
            this.pnlLogin.Controls.Add(this.btncancel);
            this.pnlLogin.Controls.Add(this.btnsingin);
            this.pnlLogin.Controls.Add(this.txtpassword);
            this.pnlLogin.Controls.Add(this.txtusername);
            this.pnlLogin.Controls.Add(this.label3);
            this.pnlLogin.Controls.Add(this.label2);
            this.pnlLogin.Controls.Add(this.label1);
            this.pnlLogin.Location = new System.Drawing.Point(537, 222);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(355, 207);
            this.pnlLogin.TabIndex = 6;
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(264, 168);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 6;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnsingin
            // 
            this.btnsingin.Location = new System.Drawing.Point(46, 168);
            this.btnsingin.Name = "btnsingin";
            this.btnsingin.Size = new System.Drawing.Size(75, 23);
            this.btnsingin.TabIndex = 5;
            this.btnsingin.Text = "Sing in";
            this.btnsingin.UseVisualStyleBackColor = true;
            this.btnsingin.Click += new System.EventHandler(this.btnsingin_Click_2);
            // 
            // txtpassword
            // 
            this.txtpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.Location = new System.Drawing.Point(127, 112);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(212, 31);
            this.txtpassword.TabIndex = 4;
            this.txtpassword.UseSystemPasswordChar = true;
            // 
            // txtusername
            // 
            this.txtusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusername.Location = new System.Drawing.Point(127, 72);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(212, 31);
            this.txtusername.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sing in";
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlNavigation.Controls.Add(this.btnExit);
            this.pnlNavigation.Controls.Add(this.btnTransact);
            this.pnlNavigation.Controls.Add(this.button1);
            this.pnlNavigation.Location = new System.Drawing.Point(3, 39);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(221, 621);
            this.pnlNavigation.TabIndex = 7;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(12, 295);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(196, 44);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnTransact
            // 
            this.btnTransact.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnTransact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransact.Location = new System.Drawing.Point(12, 241);
            this.btnTransact.Name = "btnTransact";
            this.btnTransact.Size = new System.Drawing.Size(196, 44);
            this.btnTransact.TabIndex = 1;
            this.btnTransact.Text = "Transact";
            this.btnTransact.UseVisualStyleBackColor = false;
            this.btnTransact.Click += new System.EventHandler(this.btnTransact_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 44);
            this.button1.TabIndex = 0;
            this.button1.Text = "Accouts";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pnlNavigation);
            this.panel1.Controls.Add(this.pnlLogin);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 675);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.pnlTransact);
            this.panel2.Controls.Add(this.pnlAccount);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(230, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1128, 621);
            this.panel2.TabIndex = 12;
            // 
            // pnlTransact
            // 
            this.pnlTransact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlTransact.Controls.Add(this.btnbalance);
            this.pnlTransact.Controls.Add(this.btnWithdraw);
            this.pnlTransact.Controls.Add(this.btnTransfer);
            this.pnlTransact.Controls.Add(this.btnDeposite);
            this.pnlTransact.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlTransact.Location = new System.Drawing.Point(50, 87);
            this.pnlTransact.Name = "pnlTransact";
            this.pnlTransact.Size = new System.Drawing.Size(1026, 472);
            this.pnlTransact.TabIndex = 2;
            // 
            // btnbalance
            // 
            this.btnbalance.BackColor = System.Drawing.Color.DimGray;
            this.btnbalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbalance.ForeColor = System.Drawing.Color.White;
            this.btnbalance.Location = new System.Drawing.Point(643, 274);
            this.btnbalance.Name = "btnbalance";
            this.btnbalance.Size = new System.Drawing.Size(140, 51);
            this.btnbalance.TabIndex = 11;
            this.btnbalance.Text = "Balance";
            this.btnbalance.UseVisualStyleBackColor = false;
            this.btnbalance.Click += new System.EventHandler(this.btnbalance_Click);
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.BackColor = System.Drawing.Color.DimGray;
            this.btnWithdraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWithdraw.ForeColor = System.Drawing.Color.White;
            this.btnWithdraw.Location = new System.Drawing.Point(204, 274);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(140, 51);
            this.btnWithdraw.TabIndex = 6;
            this.btnWithdraw.Text = "Withdraw";
            this.btnWithdraw.UseVisualStyleBackColor = false;
            this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);
            // 
            // btnTransfer
            // 
            this.btnTransfer.BackColor = System.Drawing.Color.DimGray;
            this.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfer.ForeColor = System.Drawing.Color.White;
            this.btnTransfer.Location = new System.Drawing.Point(643, 174);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(140, 51);
            this.btnTransfer.TabIndex = 4;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.UseVisualStyleBackColor = false;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnDeposite
            // 
            this.btnDeposite.BackColor = System.Drawing.Color.DimGray;
            this.btnDeposite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeposite.ForeColor = System.Drawing.Color.White;
            this.btnDeposite.Location = new System.Drawing.Point(204, 174);
            this.btnDeposite.Name = "btnDeposite";
            this.btnDeposite.Size = new System.Drawing.Size(140, 51);
            this.btnDeposite.TabIndex = 0;
            this.btnDeposite.Text = "Deposite";
            this.btnDeposite.UseVisualStyleBackColor = false;
            this.btnDeposite.Click += new System.EventHandler(this.btnDeposite_Click);
            // 
            // pnlAccount
            // 
            this.pnlAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlAccount.Controls.Add(this.button6);
            this.pnlAccount.Controls.Add(this.button13);
            this.pnlAccount.Controls.Add(this.button14);
            this.pnlAccount.Controls.Add(this.button15);
            this.pnlAccount.Controls.Add(this.button16);
            this.pnlAccount.Controls.Add(this.button10);
            this.pnlAccount.Controls.Add(this.btnNewAcc);
            this.pnlAccount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlAccount.Location = new System.Drawing.Point(50, 87);
            this.pnlAccount.Name = "pnlAccount";
            this.pnlAccount.Size = new System.Drawing.Size(1026, 472);
            this.pnlAccount.TabIndex = 1;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.DimGray;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(643, 201);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(140, 51);
            this.button6.TabIndex = 11;
            this.button6.Text = "Customer profile";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.DimGray;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.ForeColor = System.Drawing.Color.White;
            this.button13.Location = new System.Drawing.Point(643, 300);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(140, 51);
            this.button13.TabIndex = 9;
            this.button13.Text = "Remote Banking";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.DimGray;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.ForeColor = System.Drawing.Color.White;
            this.button14.Location = new System.Drawing.Point(204, 300);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(140, 51);
            this.button14.TabIndex = 8;
            this.button14.Text = "Cell phone Banking";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.DimGray;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.ForeColor = System.Drawing.Color.White;
            this.button15.Location = new System.Drawing.Point(436, 201);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(140, 51);
            this.button15.TabIndex = 7;
            this.button15.Text = "Statement";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.DimGray;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.ForeColor = System.Drawing.Color.White;
            this.button16.Location = new System.Drawing.Point(204, 201);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(140, 51);
            this.button16.TabIndex = 6;
            this.button16.Text = "Customer";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.DimGray;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(643, 101);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(140, 51);
            this.button10.TabIndex = 4;
            this.button10.Text = "Account Management";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // btnNewAcc
            // 
            this.btnNewAcc.BackColor = System.Drawing.Color.DimGray;
            this.btnNewAcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewAcc.ForeColor = System.Drawing.Color.White;
            this.btnNewAcc.Location = new System.Drawing.Point(204, 101);
            this.btnNewAcc.Name = "btnNewAcc";
            this.btnNewAcc.Size = new System.Drawing.Size(140, 51);
            this.btnNewAcc.TabIndex = 0;
            this.btnNewAcc.Text = "New Account";
            this.btnNewAcc.UseVisualStyleBackColor = false;
            this.btnNewAcc.Click += new System.EventHandler(this.btnNewAcc_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Monotype Corsiva", 48F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(182, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(707, 79);
            this.label4.TabIndex = 0;
            this.label4.Text = "Banking Management System";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MDIParent1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1362, 732);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip);
            this.IsMdiContainer = true;
            this.Name = "MDIParent1";
            this.Text = "Banking Management System v 1.0.0.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.MDIParent1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDIParent1_FormClosing);
            this.Load += new System.EventHandler(this.MDIParent1_Load);
            this.Enter += new System.EventHandler(this.MDIParent1_Enter);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.pnlNavigation.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlTransact.ResumeLayout(false);
            this.pnlAccount.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnsingin;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlNavigation;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlAccount;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button btnNewAcc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnTransact;
        private System.Windows.Forms.Panel pnlTransact;
        private System.Windows.Forms.Button btnbalance;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnDeposite;

    }
}



