namespace Banking_System
{
    partial class Transfer
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
            this.pnlProcess = new System.Windows.Forms.Panel();
            this.lblResult = new System.Windows.Forms.Label();
            this.picResult = new System.Windows.Forms.PictureBox();
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
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnTransact = new System.Windows.Forms.Button();
            this.btnInformation = new System.Windows.Forms.Button();
            this.btnRetrive = new System.Windows.Forms.Button();
            this.PnlTransact = new System.Windows.Forms.Panel();
            this.pnlPinCode = new System.Windows.Forms.Panel();
            this.txtPinCode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAccHolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            this.pnlProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.pnlInfo.SuspendLayout();
            this.pnlNotFound.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            this.pnlFound.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCustomer)).BeginInit();
            this.pnlRetrive.SuspendLayout();
            this.panel11.SuspendLayout();
            this.PnlTransact.SuspendLayout();
            this.pnlPinCode.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel1.Controls.Add(this.pnlProcess);
            this.Panel1.Controls.Add(this.pnlInfo);
            this.Panel1.Controls.Add(this.pnlRetrive);
            this.Panel1.Controls.Add(this.panel11);
            this.Panel1.Controls.Add(this.PnlTransact);
            this.Panel1.Controls.Add(this.Panel3);
            this.Panel1.Controls.Add(this.Panel2);
            this.Panel1.Location = new System.Drawing.Point(12, 12);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1315, 695);
            this.Panel1.TabIndex = 5;
            // 
            // pnlProcess
            // 
            this.pnlProcess.Controls.Add(this.lblResult);
            this.pnlProcess.Controls.Add(this.picResult);
            this.pnlProcess.Location = new System.Drawing.Point(25, 157);
            this.pnlProcess.Name = "pnlProcess";
            this.pnlProcess.Size = new System.Drawing.Size(1148, 510);
            this.pnlProcess.TabIndex = 8;
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(3, 282);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(1140, 67);
            this.lblResult.TabIndex = 1;
            this.lblResult.Text = "Processing...";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picResult
            // 
            this.picResult.Image = global::Banking_System.Properties.Resources._31;
            this.picResult.Location = new System.Drawing.Point(3, 41);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(1141, 180);
            this.picResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picResult.TabIndex = 0;
            this.picResult.TabStop = false;
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
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Gainsboro;
            this.panel11.Controls.Add(this.btnProcess);
            this.panel11.Controls.Add(this.btnTransact);
            this.panel11.Controls.Add(this.btnInformation);
            this.panel11.Controls.Add(this.btnRetrive);
            this.panel11.Location = new System.Drawing.Point(25, 84);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1148, 67);
            this.panel11.TabIndex = 5;
            // 
            // btnProcess
            // 
            this.btnProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Location = new System.Drawing.Point(351, 3);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(104, 57);
            this.btnProcess.TabIndex = 5;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            // 
            // btnTransact
            // 
            this.btnTransact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransact.Location = new System.Drawing.Point(236, 3);
            this.btnTransact.Name = "btnTransact";
            this.btnTransact.Size = new System.Drawing.Size(104, 57);
            this.btnTransact.TabIndex = 2;
            this.btnTransact.Text = "Transact";
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
            // PnlTransact
            // 
            this.PnlTransact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlTransact.Controls.Add(this.pnlPinCode);
            this.PnlTransact.Controls.Add(this.txtAccHolder);
            this.PnlTransact.Controls.Add(this.label3);
            this.PnlTransact.Controls.Add(this.txtAmount);
            this.PnlTransact.Controls.Add(this.label4);
            this.PnlTransact.Controls.Add(this.txtAccountNumber);
            this.PnlTransact.Controls.Add(this.Label2);
            this.PnlTransact.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTransact.Location = new System.Drawing.Point(25, 157);
            this.PnlTransact.Name = "PnlTransact";
            this.PnlTransact.Size = new System.Drawing.Size(1148, 510);
            this.PnlTransact.TabIndex = 0;
            // 
            // pnlPinCode
            // 
            this.pnlPinCode.Controls.Add(this.txtPinCode);
            this.pnlPinCode.Controls.Add(this.label10);
            this.pnlPinCode.Location = new System.Drawing.Point(292, 152);
            this.pnlPinCode.Name = "pnlPinCode";
            this.pnlPinCode.Size = new System.Drawing.Size(443, 141);
            this.pnlPinCode.TabIndex = 18;
            // 
            // txtPinCode
            // 
            this.txtPinCode.BackColor = System.Drawing.Color.White;
            this.txtPinCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPinCode.Location = new System.Drawing.Point(220, 53);
            this.txtPinCode.Name = "txtPinCode";
            this.txtPinCode.PasswordChar = '*';
            this.txtPinCode.Size = new System.Drawing.Size(203, 35);
            this.txtPinCode.TabIndex = 18;
            this.txtPinCode.UseSystemPasswordChar = true;
            this.txtPinCode.TextChanged += new System.EventHandler(this.txtPinCode_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 29);
            this.label10.TabIndex = 19;
            this.label10.Text = "Pin code :";
            // 
            // txtAccHolder
            // 
            this.txtAccHolder.BackColor = System.Drawing.Color.White;
            this.txtAccHolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccHolder.Location = new System.Drawing.Point(513, 205);
            this.txtAccHolder.Name = "txtAccHolder";
            this.txtAccHolder.Size = new System.Drawing.Size(203, 35);
            this.txtAccHolder.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(313, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 29);
            this.label3.TabIndex = 17;
            this.label3.Text = "Account Holder :";
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.White;
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(512, 246);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(204, 35);
            this.txtAmount.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(396, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 29);
            this.label4.TabIndex = 10;
            this.label4.Text = "Amount :";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.BackColor = System.Drawing.Color.White;
            this.txtAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountNumber.Location = new System.Drawing.Point(512, 164);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(204, 35);
            this.txtAccountNumber.TabIndex = 0;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(299, 167);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(203, 29);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Account Number :";
            // 
            // Panel3
            // 
            this.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel3.Controls.Add(this.button1);
            this.Panel3.Controls.Add(this.btnSearch);
            this.Panel3.Controls.Add(this.btnPrev);
            this.Panel3.Controls.Add(this.btnNext);
            this.Panel3.Controls.Add(this.btnCancel);
            this.Panel3.Controls.Add(this.btnClose);
            this.Panel3.Location = new System.Drawing.Point(1188, 84);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(111, 583);
            this.Panel3.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(13, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 28);
            this.button1.TabIndex = 9;
            this.button1.Text = "&Close";
            this.button1.UseVisualStyleBackColor = true;
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
            this.Label1.Location = new System.Drawing.Point(603, 22);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(87, 24);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Transfer";
            // 
            // Transfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.Panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Transfer";
            this.Text = "Transfer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Transfer_Load);
            this.Panel1.ResumeLayout(false);
            this.pnlProcess.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.pnlInfo.ResumeLayout(false);
            this.pnlNotFound.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            this.pnlFound.ResumeLayout(false);
            this.pnlFound.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCustomer)).EndInit();
            this.pnlRetrive.ResumeLayout(false);
            this.pnlRetrive.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.PnlTransact.ResumeLayout(false);
            this.PnlTransact.PerformLayout();
            this.pnlPinCode.ResumeLayout(false);
            this.pnlPinCode.PerformLayout();
            this.Panel3.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Panel PnlTransact;
        internal System.Windows.Forms.TextBox txtAccHolder;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtAmount;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtAccountNumber;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnTransact;
        private System.Windows.Forms.Button btnInformation;
        private System.Windows.Forms.Button btnRetrive;
        private System.Windows.Forms.Panel pnlRetrive;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.TextBox txtAcc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlProcess;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.PictureBox picResult;
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
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Button btnSearch;
        internal System.Windows.Forms.Button btnPrev;
        internal System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel pnlPinCode;
        internal System.Windows.Forms.TextBox txtPinCode;
        internal System.Windows.Forms.Label label10;

    }
}