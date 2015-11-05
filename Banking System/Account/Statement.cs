using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Printing;
//using CrystalDecisions.CrystalReports.Engine;

namespace Banking_System
{
    public partial class Statement : Form
    {
        string accountNumber;
        DataGridViewPrinter MyDataGridViewPrinter;

        public Statement()
        {
            InitializeComponent();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        public bool parseIdNo(string idNo)
        {
            try
            {
                int a = 0;
                for (int i = 0; (i <= 5); i++)
                {
                    a = (a + int.Parse(idNo.Substring((i * 2), 1)));
                }
                int b = 0;
                for (int i = 0; (i <= 5); i++)
                {
                    b = ((b * 10)
                        + int.Parse(idNo.Substring(((2 * i) + 1), 1)));
                }
                b *= 2;
                int c = 0;
                for (
                    ; ((b <= 0) == false); )
                {
                    c = c + (b % 10);
                    b = b / 10;
                }
                c = (c + a);
                int d = 0;
                d = (10 - (c % 10));

                if ((d == 10))
                {
                    d = 0;
                }

                if ((d == int.Parse(idNo.Substring(12, 1))))
                {
                    btnNext.PerformClick();
                    GetData();
                    btnNext.Enabled = false;
                    return true;
                }
                else
                {
                    if (pnlFound.Visible == true)
                    {
                        pnlFound.Visible = false;
                        pnlNotFound.Visible = true;
                    }
                    else
                    {
                        pnlNotFound.Visible = true;
                    }

                    btnNext.PerformClick();
                    btnNext.Enabled = false;
                    picError.Image = global::Banking_System.Properties.Resources.check_mark_errorcircle_error;
                    lblError.Text = "The identity number entered is not a valid SA identity number, please try again";
                    txtIdentity.Clear();
                    txtIdentity.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void txtIdentity_TextChanged(object sender, EventArgs e)
        {
            if (txtIdentity.TextLength > 0)
            {
                txtAccount.Enabled = false;
            }
            else
            {
                txtAccount.Enabled = true;
            }

            if (txtIdentity.TextLength == 13)
            {
                parseIdNo(txtIdentity.Text);
            }
        }

        private void txtAccount_TextChanged(object sender, EventArgs e)
        {
            if (txtAccount.TextLength > 0)
            {
                txtIdentity.Enabled = false;
            }
            else
            {
                txtIdentity.Enabled = true;
            }

            if (txtAccount.TextLength == 10)
            {
                GetData();
                btnNext.PerformClick();
            }
        }

        private void GetData()
        {
            if (Connection.con.State == ConnectionState.Open)
            { Connection.con.Close(); }
            Connection.con.Open();

            SqlCommand command = new SqlCommand("sp_statement_retrive_customer_info", Connection.con);
            SqlDataReader rdr = null;
            command.CommandType = CommandType.StoredProcedure;

            var _with = command.Parameters;

            _with.AddWithValue("@CheckID", txtIdentity.Text);
            _with.AddWithValue("@CheckAcc", txtAccount.Text);
            _with.AddWithValue("@IdentityNumber", txtIdentity.Text);
            _with.AddWithValue("@AccountNumber", txtAccount.Text);
            _with.AddWithValue("@CustomerID", "");
            _with.AddWithValue("@CustIDAcc", "");

            rdr = command.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    pnlNotFound.Visible = false;
                    pnlFound.Visible = true;
                    btnNext.Enabled = true;

                    txtCBName.Text = rdr["title"].ToString() + " " + rdr["firstName"].ToString() + " " + rdr["surname"].ToString();
                    txtCBContact.Text = rdr["cellNumber"].ToString();
                    txtAddress.Text = rdr["address1"].ToString();
                    txtStateAccNumber.Text = rdr["accNumber"].ToString();
                    txtStateAccType.Text = rdr["accType"].ToString();
                   
                    byte[] image = null;

                    image = (byte[])(rdr["picture"]);

                    if (image == null)
                    {
                        picCustomer.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(image);
                        picCustomer.Image = Image.FromStream(ms);
                    }
                }
            }
            else
            {
                if (pnlFound.Visible == true)
                {
                    pnlFound.Visible = false;
                    pnlNotFound.Visible = true;
                }
                else
                {
                    pnlNotFound.Visible = true;
                }

                lblError.Text = "The identity number entered does not bank with us";
                picError.Image = global ::Banking_System.Properties.Resources.check_mark_errorcircle_error;
                btnNext.Enabled = false;
            }
            command.Dispose();
            rdr.Dispose();



        }

        private void GetAccounts()
        {
            try
            {
                if (Connection.con.State == ConnectionState.Open)
                { Connection.con.Close(); }
                Connection.con.Open();

                SqlCommand command = new SqlCommand("sp_get_accounts", Connection.con);
                command.CommandType = CommandType.StoredProcedure;
                DataTable table = new DataTable();

                command.Parameters.AddWithValue("@IdentityNumber", txtAccount.Text);
                command.Parameters.AddWithValue("@AccountNumber", txtAccount.Text);
                command.Parameters.AddWithValue("@CheckID", "");
                command.Parameters.AddWithValue("@CheckAcc", "");

                table.Load(command.ExecuteReader());

                dataGridView2.DataSource = table;

                command.Dispose();
                table.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetTransactions()
        {
            try
            {
                if (Connection.con.State == ConnectionState.Open)
                { Connection.con.Close(); }
                Connection.con.Open();

                SqlCommand command = new SqlCommand("sp_transactions", Connection.con);
                command.CommandType = CommandType.StoredProcedure;
                DataTable table = new DataTable();

                command.Parameters.AddWithValue("@AccountNumber", accountNumber);

                table.Load(command.ExecuteReader());

                dataGridView1.DataSource = table;

                command.Dispose();
                table.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void Statement_Load(object sender, EventArgs e)
        {
            btnRetrive.BackColor = Color.RoyalBlue;
            btnRetrive.ForeColor = Color.White;
            btnPrint.Enabled = false;

            pnlRetrive.Visible = true;
            pnlInfo.Visible = false;
            pnlAccSelection.Visible = false;
            pnlPreview.Visible = false;
           
            //GetAccounts();
        }

        private bool SetupThePrinting()
        {
            string Text;
            printDialog1.AllowCurrentPage = false;
            printDialog1.AllowPrintToFile = false;
            printDialog1.AllowSelection = false;
            printDialog1.AllowSomePages = false;
            printDialog1.PrintToFile = false;
            printDialog1.ShowHelp = false;
            printDialog1.ShowNetwork = false;

            if (printDialog1.ShowDialog() != DialogResult.OK)
                return false;

            printDocument1.DocumentName = "Client Statement";
            printDocument1.PrinterSettings =
                                printDialog1.PrinterSettings;
            printDocument1.DefaultPageSettings =
            printDialog1.PrinterSettings.DefaultPageSettings;
            printDocument1.DefaultPageSettings.Margins =
                             new Margins(40, 40, 40, 40);

            Text = txtCBName.Text + Environment.NewLine +
            txtStateAccType.Text  + Environment.NewLine +
            "" + Environment.NewLine +
            txtAddress.Text + Environment.NewLine +
            "" + Environment.NewLine +
            "From date: " + Environment.NewLine +
            "To date: " + Environment.NewLine +
            "Print date: " + DateTime.Today.ToShortDateString() + Environment.NewLine +
            "" + Environment.NewLine +
            "Account number: " + txtStateAccNumber.Text + " " + txtStateAccType.Text  + Environment.NewLine +
            "" + Environment.NewLine +
            "";


            //if (MessageBox.Show("Do you want the report to be centered on the page",
            //    "InvoiceManager - Center on Page", MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question) == DialogResult.Yes)
            //    MyDataGridViewPrinter = new DataGridViewPrinter(dataGridView1,
            //    printDocument1, true, true, "Statement", new Font("Tahoma", 18,
            //    FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            //else
                MyDataGridViewPrinter = new DataGridViewPrinter(dataGridView1,
                printDocument1, false, true, Text, new Font("Tahoma", 8,
                FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
            {
                //PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pnlRetrive.Visible == true)
            {
                if (txtIdentity.Text == "" && txtAccount.Text == "")
                {
                    MessageBox.Show("Please enter the customer identity number or account number to proceed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                pnlRetrive.Visible = false;
                pnlInfo.Visible = false;
                pnlAccSelection.Visible = true;
                pnlPreview.Visible = false;

                GetAccounts();

                btnPrev.Enabled = true;

               

                btnInformation.BackColor = Color.WhiteSmoke;
                btnInformation.ForeColor = Color.Black;

                btnAccSelection.BackColor = Color.RoyalBlue;
                btnAccSelection.ForeColor = Color.White;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }

            if (pnlInfo.Visible == true)
            {

                pnlRetrive.Visible = false;
                pnlInfo.Visible = false;
                pnlAccSelection.Visible = false;
                pnlPreview.Visible = true;

                GetTransactions();
                btnPrint.Enabled = true;

                btnInformation.BackColor = Color.WhiteSmoke;
                btnInformation.ForeColor = Color.Black;

                btnAccSelection.BackColor = Color.WhiteSmoke;
                btnAccSelection.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnPreview.BackColor = Color.RoyalBlue;
                btnPreview.ForeColor = Color.White;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }

            if (pnlAccSelection.Visible == true)
            {
                pnlRetrive.Visible = false;
                pnlInfo.Visible = true;
                pnlAccSelection.Visible = false;
                pnlPreview.Visible = false;

                btnInformation.BackColor = Color.RoyalBlue;
                btnInformation.ForeColor = Color.White;

                btnAccSelection.BackColor = Color.WhiteSmoke;
                btnAccSelection.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool cellClick = true;

            if (cellClick == true)
            {

                if (e.RowIndex >= 0)
                {
                    try
                    {
                        DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                        accountNumber = row.Cells["Account_Number"].Value.ToString();
                        if (accountNumber == row.Cells["Account_Number"].Value.ToString())
                        {
                            btnNext.Enabled = true;
                            btnNext.PerformClick();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (pnlInfo.Visible == true)
            {

                pnlRetrive.Visible = false;
                pnlInfo.Visible = false;
                pnlAccSelection.Visible = true;
                pnlPreview.Visible = false;

                btnPrev.Enabled = false;

                btnInformation.BackColor = Color.WhiteSmoke;
                btnInformation.ForeColor = Color.Black;

                btnAccSelection.BackColor = Color.RoyalBlue;
                btnAccSelection.ForeColor = Color.White;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnPreview.BackColor = Color.WhiteSmoke;
                btnPreview.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }

            if (pnlAccSelection.Visible == true)
            {
                pnlRetrive.Visible = true;
                pnlInfo.Visible = false;
                pnlAccSelection.Visible = false;
                pnlPreview.Visible = false;

                btnInformation.BackColor = Color.WhiteSmoke;
                btnInformation.ForeColor = Color.Black;

                btnAccSelection.BackColor = Color.WhiteSmoke;
                btnAccSelection.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.RoyalBlue;
                btnRetrive.ForeColor = Color.White;

                return;
            }

        }
    }
}
