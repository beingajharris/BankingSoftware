namespace Banking_System
{
    partial class Statement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Statement));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblDateActivated = new System.Windows.Forms.Label();
            this.picCustomer = new System.Windows.Forms.PictureBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtCBName = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtCBContact = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.pnlAccSelection = new System.Windows.Forms.Panel();
            this.pnlNotFound = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.picError = new System.Windows.Forms.PictureBox();
            this.pnlFound = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnAccSelection = new System.Windows.Forms.Button();
            this.btnInformation = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnRetrive = new System.Windows.Forms.Button();
            this.pnlRetrive = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIdentity = new System.Windows.Forms.TextBox();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.txtStateAccType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStateAccNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            this.pnlPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCustomer)).BeginInit();
            this.pnlAccSelection.SuspendLayout();
            this.pnlNotFound.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            this.pnlFound.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel11.SuspendLayout();
            this.pnlRetrive.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel1.Controls.Add(this.pnlPreview);
            this.Panel1.Controls.Add(this.pnlInfo);
            this.Panel1.Controls.Add(this.pnlAccSelection);
            this.Panel1.Controls.Add(this.panel11);
            this.Panel1.Controls.Add(this.pnlRetrive);
            this.Panel1.Controls.Add(this.Panel3);
            this.Panel1.Controls.Add(this.Panel2);
            this.Panel1.Location = new System.Drawing.Point(23, 21);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1317, 681);
            this.Panel1.TabIndex = 5;
            // 
            // pnlPreview
            // 
            this.pnlPreview.Controls.Add(this.dataGridView1);
            this.pnlPreview.Location = new System.Drawing.Point(7, 148);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(1164, 516);
            this.pnlPreview.TabIndex = 181;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(20, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1124, 419);
            this.dataGridView1.TabIndex = 37;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.txtStateAccType);
            this.pnlInfo.Controls.Add(this.label4);
            this.pnlInfo.Controls.Add(this.txtStateAccNumber);
            this.pnlInfo.Controls.Add(this.label5);
            this.pnlInfo.Controls.Add(this.txtAddress);
            this.pnlInfo.Controls.Add(this.lblDateActivated);
            this.pnlInfo.Controls.Add(this.picCustomer);
            this.pnlInfo.Controls.Add(this.label29);
            this.pnlInfo.Controls.Add(this.txtCBName);
            this.pnlInfo.Controls.Add(this.label24);
            this.pnlInfo.Controls.Add(this.txtCBContact);
            this.pnlInfo.Controls.Add(this.label23);
            this.pnlInfo.Location = new System.Drawing.Point(7, 148);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(1164, 516);
            this.pnlInfo.TabIndex = 37;
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.Enabled = false;
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(294, 128);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(221, 26);
            this.txtAddress.TabIndex = 179;
            // 
            // lblDateActivated
            // 
            this.lblDateActivated.AutoSize = true;
            this.lblDateActivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateActivated.Location = new System.Drawing.Point(150, 131);
            this.lblDateActivated.Name = "lblDateActivated";
            this.lblDateActivated.Size = new System.Drawing.Size(76, 20);
            this.lblDateActivated.TabIndex = 178;
            this.lblDateActivated.Text = "Address :";
            // 
            // picCustomer
            // 
            this.picCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.picCustomer.Location = new System.Drawing.Point(684, 62);
            this.picCustomer.Name = "picCustomer";
            this.picCustomer.Size = new System.Drawing.Size(240, 170);
            this.picCustomer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCustomer.TabIndex = 177;
            this.picCustomer.TabStop = false;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(587, 62);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(66, 20);
            this.label29.TabIndex = 176;
            this.label29.Text = "Picture :";
            // 
            // txtCBName
            // 
            this.txtCBName.BackColor = System.Drawing.Color.White;
            this.txtCBName.Enabled = false;
            this.txtCBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCBName.Location = new System.Drawing.Point(294, 64);
            this.txtCBName.Name = "txtCBName";
            this.txtCBName.Size = new System.Drawing.Size(222, 26);
            this.txtCBName.TabIndex = 172;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(168, 62);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(59, 20);
            this.label24.TabIndex = 171;
            this.label24.Text = "Name :";
            // 
            // txtCBContact
            // 
            this.txtCBContact.BackColor = System.Drawing.Color.White;
            this.txtCBContact.Enabled = false;
            this.txtCBContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCBContact.Location = new System.Drawing.Point(294, 96);
            this.txtCBContact.Name = "txtCBContact";
            this.txtCBContact.Size = new System.Drawing.Size(221, 26);
            this.txtCBContact.TabIndex = 168;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(125, 99);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(101, 20);
            this.label23.TabIndex = 167;
            this.label23.Text = "Cell number :";
            // 
            // pnlAccSelection
            // 
            this.pnlAccSelection.Controls.Add(this.pnlNotFound);
            this.pnlAccSelection.Controls.Add(this.pnlFound);
            this.pnlAccSelection.Location = new System.Drawing.Point(7, 148);
            this.pnlAccSelection.Name = "pnlAccSelection";
            this.pnlAccSelection.Size = new System.Drawing.Size(1164, 516);
            this.pnlAccSelection.TabIndex = 41;
            // 
            // pnlNotFound
            // 
            this.pnlNotFound.Controls.Add(this.lblError);
            this.pnlNotFound.Controls.Add(this.picError);
            this.pnlNotFound.Location = new System.Drawing.Point(4, 48);
            this.pnlNotFound.Name = "pnlNotFound";
            this.pnlNotFound.Size = new System.Drawing.Size(1157, 421);
            this.pnlNotFound.TabIndex = 38;
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.Location = new System.Drawing.Point(7, 213);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(1147, 127);
            this.lblError.TabIndex = 1;
            this.lblError.Text = "label3";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picError
            // 
            this.picError.Image = global::Banking_System.Properties.Resources.check_mark_errorcircle_error;
            this.picError.Location = new System.Drawing.Point(6, 28);
            this.picError.Name = "picError";
            this.picError.Size = new System.Drawing.Size(1148, 182);
            this.picError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picError.TabIndex = 0;
            this.picError.TabStop = false;
            // 
            // pnlFound
            // 
            this.pnlFound.Controls.Add(this.dataGridView2);
            this.pnlFound.Location = new System.Drawing.Point(4, 48);
            this.pnlFound.Name = "pnlFound";
            this.pnlFound.Size = new System.Drawing.Size(1157, 411);
            this.pnlFound.TabIndex = 37;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView2.Location = new System.Drawing.Point(16, 35);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1124, 364);
            this.dataGridView2.TabIndex = 36;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Gainsboro;
            this.panel11.Controls.Add(this.btnProcess);
            this.panel11.Controls.Add(this.btnAccSelection);
            this.panel11.Controls.Add(this.btnInformation);
            this.panel11.Controls.Add(this.btnPreview);
            this.panel11.Controls.Add(this.btnRetrive);
            this.panel11.Location = new System.Drawing.Point(7, 75);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1164, 67);
            this.panel11.TabIndex = 6;
            // 
            // btnProcess
            // 
            this.btnProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Location = new System.Drawing.Point(456, 3);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(104, 57);
            this.btnProcess.TabIndex = 5;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            // 
            // btnAccSelection
            // 
            this.btnAccSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccSelection.Location = new System.Drawing.Point(126, 3);
            this.btnAccSelection.Name = "btnAccSelection";
            this.btnAccSelection.Size = new System.Drawing.Size(104, 57);
            this.btnAccSelection.TabIndex = 4;
            this.btnAccSelection.Text = "Account Selection";
            this.btnAccSelection.UseVisualStyleBackColor = true;
            // 
            // btnInformation
            // 
            this.btnInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInformation.Location = new System.Drawing.Point(236, 3);
            this.btnInformation.Name = "btnInformation";
            this.btnInformation.Size = new System.Drawing.Size(104, 57);
            this.btnInformation.TabIndex = 1;
            this.btnInformation.Text = "Information";
            this.btnInformation.UseVisualStyleBackColor = true;
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(346, 3);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(104, 57);
            this.btnPreview.TabIndex = 3;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
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
            // pnlRetrive
            // 
            this.pnlRetrive.Controls.Add(this.label2);
            this.pnlRetrive.Controls.Add(this.txtAccount);
            this.pnlRetrive.Controls.Add(this.label10);
            this.pnlRetrive.Controls.Add(this.txtIdentity);
            this.pnlRetrive.Location = new System.Drawing.Point(7, 148);
            this.pnlRetrive.Name = "pnlRetrive";
            this.pnlRetrive.Size = new System.Drawing.Size(1164, 516);
            this.pnlRetrive.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(291, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 25);
            this.label2.TabIndex = 40;
            this.label2.Text = "Account Number :";
            // 
            // txtAccount
            // 
            this.txtAccount.BackColor = System.Drawing.Color.White;
            this.txtAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccount.Location = new System.Drawing.Point(567, 280);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(307, 31);
            this.txtAccount.TabIndex = 39;
            this.txtAccount.TextChanged += new System.EventHandler(this.txtAccount_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(300, 246);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(174, 25);
            this.label10.TabIndex = 38;
            this.label10.Text = "Identity Number :";
            // 
            // txtIdentity
            // 
            this.txtIdentity.BackColor = System.Drawing.Color.White;
            this.txtIdentity.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentity.Location = new System.Drawing.Point(567, 243);
            this.txtIdentity.Name = "txtIdentity";
            this.txtIdentity.Size = new System.Drawing.Size(307, 31);
            this.txtIdentity.TabIndex = 37;
            this.txtIdentity.TextChanged += new System.EventHandler(this.txtIdentity_TextChanged);
            // 
            // Panel3
            // 
            this.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel3.Controls.Add(this.btnCancel);
            this.Panel3.Controls.Add(this.btnClose);
            this.Panel3.Controls.Add(this.btnSave);
            this.Panel3.Controls.Add(this.btnPrint);
            this.Panel3.Controls.Add(this.btnPrev);
            this.Panel3.Controls.Add(this.btnNext);
            this.Panel3.Location = new System.Drawing.Point(1177, 74);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(111, 590);
            this.Panel3.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(13, 557);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 28);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Done";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(13, 103);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 28);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(13, 526);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 28);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(13, 72);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(82, 28);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrev.Location = new System.Drawing.Point(13, 41);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(82, 28);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "<< &Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(13, 10);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(82, 28);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "&Next >>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.Teal;
            this.Panel2.Controls.Add(this.Label1);
            this.Panel2.Location = new System.Drawing.Point(7, 7);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(1305, 62);
            this.Panel2.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(551, 19);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(102, 24);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Statement";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // txtStateAccType
            // 
            this.txtStateAccType.BackColor = System.Drawing.Color.White;
            this.txtStateAccType.Enabled = false;
            this.txtStateAccType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStateAccType.Location = new System.Drawing.Point(293, 221);
            this.txtStateAccType.Name = "txtStateAccType";
            this.txtStateAccType.Size = new System.Drawing.Size(222, 26);
            this.txtStateAccType.TabIndex = 185;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(112, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 184;
            this.label4.Text = "Account Type :";
            // 
            // txtStateAccNumber
            // 
            this.txtStateAccNumber.BackColor = System.Drawing.Color.White;
            this.txtStateAccNumber.Enabled = false;
            this.txtStateAccNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStateAccNumber.Location = new System.Drawing.Point(293, 190);
            this.txtStateAccNumber.Name = "txtStateAccNumber";
            this.txtStateAccNumber.Size = new System.Drawing.Size(222, 26);
            this.txtStateAccNumber.TabIndex = 183;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(90, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 20);
            this.label5.TabIndex = 182;
            this.label5.Text = "Account Number :";
            // 
            // Statement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.Panel1);
            this.Name = "Statement";
            this.Text = "Banking Management System v 1.0.0.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Statement_Load);
            this.Panel1.ResumeLayout(false);
            this.pnlPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCustomer)).EndInit();
            this.pnlAccSelection.ResumeLayout(false);
            this.pnlNotFound.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            this.pnlFound.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel11.ResumeLayout(false);
            this.pnlRetrive.ResumeLayout(false);
            this.pnlRetrive.PerformLayout();
            this.Panel3.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Button btnPrint;
        internal System.Windows.Forms.Button btnPrev;
        internal System.Windows.Forms.Button btnNext;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Panel pnlRetrive;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button btnAccSelection;
        private System.Windows.Forms.Button btnInformation;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnRetrive;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtAccount;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox txtIdentity;
        private System.Windows.Forms.Panel pnlAccSelection;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Panel pnlInfo;
        internal System.Windows.Forms.Label lblDateActivated;
        private System.Windows.Forms.PictureBox picCustomer;
        internal System.Windows.Forms.Label label29;
        internal System.Windows.Forms.TextBox txtCBName;
        internal System.Windows.Forms.Label label24;
        internal System.Windows.Forms.TextBox txtCBContact;
        internal System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel pnlPreview;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel pnlNotFound;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.PictureBox picError;
        private System.Windows.Forms.Panel pnlFound;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        internal System.Windows.Forms.TextBox txtStateAccType;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtStateAccNumber;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtAddress;
    }
}