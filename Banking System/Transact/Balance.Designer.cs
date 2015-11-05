namespace Banking_System
{
    partial class Balance
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.pnlNotFound = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.picError = new System.Windows.Forms.PictureBox();
            this.pnlFound = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.picCustomer = new System.Windows.Forms.PictureBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlRetrive = new System.Windows.Forms.Panel();
            this.txtAcc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnTransact = new System.Windows.Forms.Button();
            this.btnInformation = new System.Windows.Forms.Button();
            this.btnRetrive = new System.Windows.Forms.Button();
            this.PnlPinCode = new System.Windows.Forms.Panel();
            this.txtPinCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlBalance = new System.Windows.Forms.Panel();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAvailable = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlNotFound.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            this.pnlFound.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCustomer)).BeginInit();
            this.pnlRetrive.SuspendLayout();
            this.panel5.SuspendLayout();
            this.PnlPinCode.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.pnlBalance.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.pnlInfo);
            this.panel4.Controls.Add(this.pnlRetrive);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.PnlPinCode);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Location = new System.Drawing.Point(25, 23);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1315, 695);
            this.panel4.TabIndex = 8;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.pnlNotFound);
            this.pnlInfo.Controls.Add(this.pnlFound);
            this.pnlInfo.Location = new System.Drawing.Point(25, 157);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(1148, 510);
            this.pnlInfo.TabIndex = 2;
            // 
            // pnlNotFound
            // 
            this.pnlNotFound.Controls.Add(this.lblError);
            this.pnlNotFound.Controls.Add(this.picError);
            this.pnlNotFound.Location = new System.Drawing.Point(61, 38);
            this.pnlNotFound.Name = "pnlNotFound";
            this.pnlNotFound.Size = new System.Drawing.Size(1030, 427);
            this.pnlNotFound.TabIndex = 16;
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.Location = new System.Drawing.Point(13, 263);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(1011, 132);
            this.lblError.TabIndex = 1;
            this.lblError.Text = "label11";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picError
            // 
            this.picError.Image = global::Banking_System.Properties.Resources.check_mark_errorcircle_error;
            this.picError.Location = new System.Drawing.Point(3, 36);
            this.picError.Name = "picError";
            this.picError.Size = new System.Drawing.Size(1021, 202);
            this.picError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picError.TabIndex = 0;
            this.picError.TabStop = false;
            // 
            // pnlFound
            // 
            this.pnlFound.Controls.Add(this.label9);
            this.pnlFound.Controls.Add(this.picCustomer);
            this.pnlFound.Controls.Add(this.txtSurname);
            this.pnlFound.Controls.Add(this.label8);
            this.pnlFound.Controls.Add(this.txtLastName);
            this.pnlFound.Controls.Add(this.label7);
            this.pnlFound.Controls.Add(this.txtFirstName);
            this.pnlFound.Controls.Add(this.label6);
            this.pnlFound.Location = new System.Drawing.Point(61, 38);
            this.pnlFound.Name = "pnlFound";
            this.pnlFound.Size = new System.Drawing.Size(1030, 427);
            this.pnlFound.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(197, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 31);
            this.label9.TabIndex = 15;
            this.label9.Text = "Picture :";
            // 
            // picCustomer
            // 
            this.picCustomer.BackColor = System.Drawing.Color.Gainsboro;
            this.picCustomer.Location = new System.Drawing.Point(400, 186);
            this.picCustomer.Name = "picCustomer";
            this.picCustomer.Size = new System.Drawing.Size(320, 224);
            this.picCustomer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCustomer.TabIndex = 14;
            this.picCustomer.TabStop = false;
            // 
            // txtSurname
            // 
            this.txtSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSurname.Location = new System.Drawing.Point(400, 109);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(304, 38);
            this.txtSurname.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(180, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 31);
            this.label8.TabIndex = 12;
            this.label8.Text = "Surname :";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(400, 65);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(304, 38);
            this.txtLastName.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(158, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 31);
            this.label7.TabIndex = 10;
            this.label7.Text = "Last Name :";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(400, 21);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(304, 38);
            this.txtFirstName.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(156, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 31);
            this.label6.TabIndex = 8;
            this.label6.Text = "First Name :";
            // 
            // pnlRetrive
            // 
            this.pnlRetrive.Controls.Add(this.txtAcc);
            this.pnlRetrive.Controls.Add(this.label5);
            this.pnlRetrive.Location = new System.Drawing.Point(25, 157);
            this.pnlRetrive.Name = "pnlRetrive";
            this.pnlRetrive.Size = new System.Drawing.Size(1148, 510);
            this.pnlRetrive.TabIndex = 18;
            // 
            // txtAcc
            // 
            this.txtAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcc.Location = new System.Drawing.Point(509, 241);
            this.txtAcc.Name = "txtAcc";
            this.txtAcc.Size = new System.Drawing.Size(382, 38);
            this.txtAcc.TabIndex = 1;
            this.txtAcc.TextChanged += new System.EventHandler(this.txtAcc_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(257, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 31);
            this.label5.TabIndex = 0;
            this.label5.Text = "Account Number :";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.Controls.Add(this.btnTransact);
            this.panel5.Controls.Add(this.btnInformation);
            this.panel5.Controls.Add(this.btnRetrive);
            this.panel5.Location = new System.Drawing.Point(25, 84);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1148, 67);
            this.panel5.TabIndex = 5;
            // 
            // btnTransact
            // 
            this.btnTransact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransact.Location = new System.Drawing.Point(236, 3);
            this.btnTransact.Name = "btnTransact";
            this.btnTransact.Size = new System.Drawing.Size(104, 57);
            this.btnTransact.TabIndex = 2;
            this.btnTransact.Text = "Pin code";
            this.btnTransact.UseVisualStyleBackColor = true;
            // 
            // btnInformation
            // 
            this.btnInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInformation.Location = new System.Drawing.Point(126, 3);
            this.btnInformation.Name = "btnInformation";
            this.btnInformation.Size = new System.Drawing.Size(104, 57);
            this.btnInformation.TabIndex = 1;
            this.btnInformation.Text = "Information";
            this.btnInformation.UseVisualStyleBackColor = true;
            // 
            // btnRetrive
            // 
            this.btnRetrive.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRetrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetrive.ForeColor = System.Drawing.Color.Black;
            this.btnRetrive.Location = new System.Drawing.Point(16, 3);
            this.btnRetrive.Name = "btnRetrive";
            this.btnRetrive.Size = new System.Drawing.Size(104, 57);
            this.btnRetrive.TabIndex = 0;
            this.btnRetrive.Text = "Retrival";
            this.btnRetrive.UseVisualStyleBackColor = false;
            // 
            // PnlPinCode
            // 
            this.PnlPinCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlPinCode.Controls.Add(this.pnlBalance);
            this.PnlPinCode.Controls.Add(this.txtPinCode);
            this.PnlPinCode.Controls.Add(this.label3);
            this.PnlPinCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlPinCode.Location = new System.Drawing.Point(25, 157);
            this.PnlPinCode.Name = "PnlPinCode";
            this.PnlPinCode.Size = new System.Drawing.Size(1148, 510);
            this.PnlPinCode.TabIndex = 0;
            // 
            // txtPinCode
            // 
            this.txtPinCode.BackColor = System.Drawing.Color.White;
            this.txtPinCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPinCode.Location = new System.Drawing.Point(508, 296);
            this.txtPinCode.Name = "txtPinCode";
            this.txtPinCode.PasswordChar = '*';
            this.txtPinCode.Size = new System.Drawing.Size(203, 35);
            this.txtPinCode.TabIndex = 16;
            this.txtPinCode.UseSystemPasswordChar = true;
            this.txtPinCode.TextChanged += new System.EventHandler(this.txtPinCode_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(377, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 29);
            this.label3.TabIndex = 17;
            this.label3.Text = "Pin code :";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.button4);
            this.panel6.Controls.Add(this.btnSearch);
            this.panel6.Controls.Add(this.btnPrev);
            this.panel6.Controls.Add(this.btnNext);
            this.panel6.Controls.Add(this.button7);
            this.panel6.Controls.Add(this.button8);
            this.panel6.Location = new System.Drawing.Point(1188, 84);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(111, 583);
            this.panel6.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(13, 109);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(82, 28);
            this.button4.TabIndex = 9;
            this.button4.Text = "&Close";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(13, 78);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(82, 28);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "&Cancel";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrev.Location = new System.Drawing.Point(13, 47);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(82, 28);
            this.btnPrev.TabIndex = 7;
            this.btnPrev.Text = "<< &Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(13, 16);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(82, 28);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "&Next >>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // button7
            // 
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(13, 498);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(82, 28);
            this.button7.TabIndex = 5;
            this.button7.Text = "Cancel";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(13, 532);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(82, 28);
            this.button8.TabIndex = 3;
            this.button8.Text = "Close";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Teal;
            this.panel7.Controls.Add(this.label10);
            this.panel7.Location = new System.Drawing.Point(25, 16);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1274, 62);
            this.panel7.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(534, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 24);
            this.label10.TabIndex = 0;
            this.label10.Text = "Withdrawal";
            // 
            // pnlBalance
            // 
            this.pnlBalance.Controls.Add(this.txtBalance);
            this.pnlBalance.Controls.Add(this.label2);
            this.pnlBalance.Controls.Add(this.txtAvailable);
            this.pnlBalance.Controls.Add(this.label4);
            this.pnlBalance.Location = new System.Drawing.Point(162, 90);
            this.pnlBalance.Name = "pnlBalance";
            this.pnlBalance.Size = new System.Drawing.Size(823, 328);
            this.pnlBalance.TabIndex = 21;
            // 
            // txtBalance
            // 
            this.txtBalance.BackColor = System.Drawing.Color.White;
            this.txtBalance.Enabled = false;
            this.txtBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.Location = new System.Drawing.Point(329, 120);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(204, 35);
            this.txtBalance.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(140, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 29);
            this.label2.TabIndex = 23;
            this.label2.Text = "Balance :";
            // 
            // txtAvailable
            // 
            this.txtAvailable.BackColor = System.Drawing.Color.White;
            this.txtAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvailable.Location = new System.Drawing.Point(329, 161);
            this.txtAvailable.Name = "txtAvailable";
            this.txtAvailable.Size = new System.Drawing.Size(204, 35);
            this.txtAvailable.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(135, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 29);
            this.label4.TabIndex = 21;
            this.label4.Text = "Availabe :";
            // 
            // Balance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panel4);
            this.Name = "Balance";
            this.Text = "Balance";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Balance_Load);
            this.panel4.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlNotFound.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            this.pnlFound.ResumeLayout(false);
            this.pnlFound.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCustomer)).EndInit();
            this.pnlRetrive.ResumeLayout(false);
            this.pnlRetrive.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.PnlPinCode.ResumeLayout(false);
            this.PnlPinCode.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.pnlBalance.ResumeLayout(false);
            this.pnlBalance.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Panel pnlNotFound;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.PictureBox picError;
        private System.Windows.Forms.Panel pnlFound;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox picCustomer;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlRetrive;
        private System.Windows.Forms.TextBox txtAcc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnTransact;
        private System.Windows.Forms.Button btnInformation;
        private System.Windows.Forms.Button btnRetrive;
        internal System.Windows.Forms.Panel PnlPinCode;
        internal System.Windows.Forms.TextBox txtPinCode;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Panel panel6;
        internal System.Windows.Forms.Button button4;
        internal System.Windows.Forms.Button btnSearch;
        internal System.Windows.Forms.Button btnPrev;
        internal System.Windows.Forms.Button btnNext;
        internal System.Windows.Forms.Button button7;
        internal System.Windows.Forms.Button button8;
        internal System.Windows.Forms.Panel panel7;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnlBalance;
        internal System.Windows.Forms.TextBox txtBalance;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtAvailable;
        internal System.Windows.Forms.Label label4;

    }
}