namespace Banking_System
{
    partial class Deposite
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
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.txtAccHolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChange = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCash = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDeposite = new System.Windows.Forms.Button();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            this.Panel4.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel1.Controls.Add(this.Panel4);
            this.Panel1.Controls.Add(this.Panel3);
            this.Panel1.Controls.Add(this.Panel2);
            this.Panel1.Location = new System.Drawing.Point(26, 12);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1315, 695);
            this.Panel1.TabIndex = 4;
            // 
            // Panel4
            // 
            this.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel4.Controls.Add(this.txtAccHolder);
            this.Panel4.Controls.Add(this.label3);
            this.Panel4.Controls.Add(this.txtChange);
            this.Panel4.Controls.Add(this.label9);
            this.Panel4.Controls.Add(this.txtCash);
            this.Panel4.Controls.Add(this.label8);
            this.Panel4.Controls.Add(this.txtAmount);
            this.Panel4.Controls.Add(this.label4);
            this.Panel4.Controls.Add(this.txtAccountNumber);
            this.Panel4.Controls.Add(this.Label2);
            this.Panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel4.Location = new System.Drawing.Point(25, 160);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(1157, 507);
            this.Panel4.TabIndex = 0;
            // 
            // txtAccHolder
            // 
            this.txtAccHolder.BackColor = System.Drawing.Color.White;
            this.txtAccHolder.Enabled = false;
            this.txtAccHolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccHolder.Location = new System.Drawing.Point(700, 94);
            this.txtAccHolder.Name = "txtAccHolder";
            this.txtAccHolder.Size = new System.Drawing.Size(452, 35);
            this.txtAccHolder.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(505, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 29);
            this.label3.TabIndex = 17;
            this.label3.Text = "Account Holder :";
            // 
            // txtChange
            // 
            this.txtChange.BackColor = System.Drawing.Color.White;
            this.txtChange.Enabled = false;
            this.txtChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChange.Location = new System.Drawing.Point(248, 217);
            this.txtChange.Name = "txtChange";
            this.txtChange.Size = new System.Drawing.Size(204, 35);
            this.txtChange.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(123, 220);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 29);
            this.label9.TabIndex = 14;
            this.label9.Text = "Change :";
            // 
            // txtCash
            // 
            this.txtCash.BackColor = System.Drawing.Color.White;
            this.txtCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCash.Location = new System.Drawing.Point(247, 176);
            this.txtCash.Name = "txtCash";
            this.txtCash.Size = new System.Drawing.Size(204, 35);
            this.txtCash.TabIndex = 2;
            this.txtCash.TextChanged += new System.EventHandler(this.txtCash_TextChanged);
            this.txtCash.Leave += new System.EventHandler(this.txtCash_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(152, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 29);
            this.label8.TabIndex = 12;
            this.label8.Text = "Cash :";
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.White;
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(247, 135);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(204, 35);
            this.txtAmount.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(126, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 29);
            this.label4.TabIndex = 10;
            this.label4.Text = "Amount :";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.BackColor = System.Drawing.Color.White;
            this.txtAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountNumber.Location = new System.Drawing.Point(247, 94);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(204, 35);
            this.txtAccountNumber.TabIndex = 0;
            this.txtAccountNumber.TextChanged += new System.EventHandler(this.txtAccountNumber_TextChanged);
            this.txtAccountNumber.Leave += new System.EventHandler(this.txtAccountNumber_Leave);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(29, 97);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(203, 29);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Account Number :";
            // 
            // Panel3
            // 
            this.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel3.Controls.Add(this.btnCancel);
            this.Panel3.Controls.Add(this.btnClose);
            this.Panel3.Controls.Add(this.btnDeposite);
            this.Panel3.Location = new System.Drawing.Point(1188, 95);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(111, 572);
            this.Panel3.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(13, 498);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 28);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(13, 532);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 28);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnDeposite
            // 
            this.btnDeposite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeposite.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeposite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeposite.Location = new System.Drawing.Point(13, 20);
            this.btnDeposite.Name = "btnDeposite";
            this.btnDeposite.Size = new System.Drawing.Size(82, 28);
            this.btnDeposite.TabIndex = 2;
            this.btnDeposite.Text = "Deposite";
            this.btnDeposite.UseVisualStyleBackColor = true;
            this.btnDeposite.Click += new System.EventHandler(this.btnDeposite_Click);
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.Teal;
            this.Panel2.Controls.Add(this.Label1);
            this.Panel2.Location = new System.Drawing.Point(25, 16);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(1274, 62);
            this.Panel2.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(592, 24);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(92, 24);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Deposite";
            // 
            // Deposite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.Panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Deposite";
            this.Text = "Deposite";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Deposite_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            this.Panel3.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.TextBox txtChange;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txtCash;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtAmount;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtAccountNumber;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnDeposite;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtAccHolder;
        internal System.Windows.Forms.Label label3;
    }
}