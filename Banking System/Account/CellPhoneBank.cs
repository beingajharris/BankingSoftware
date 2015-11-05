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

namespace Banking_System
{
    public partial class CellPhoneBank : Form
    {
        string accountNumber;

        public CellPhoneBank()
        {
            InitializeComponent();
        }

        private void CellPhoneBank_Load(object sender, EventArgs e)
        {
            axAcroPDF1.src = @"C:\Users\SURPRISEE\Documents\School Stuff\CREDIT REHABILITATION PACK_LP101325_20140919103121.pdf";
            txtCurrentPin.Hide();
            lblCurrentPin.Hide();
            lblEmp.Hide();
            lblDateActivated.Hide();
            txtCBDateActivated.Hide();
            picTick.Hide();
            lblTick.Hide();
            btnChangePin.Enabled = false;
            btnPrev.Enabled = false;

            txtCurrentPin.MaxLength = 4;
            txtCBAccessPin.MaxLength = 4;
            txtCBAccessPin2.MaxLength = 4;

            btnRetrive.BackColor = Color.RoyalBlue;
            btnRetrive.ForeColor = Color.White;

            pnlRetrive.Visible = true;
            pnlInfo.Visible = false;
            pnlAccSelection.Visible = false;
            pnlProcess.Visible = false;
            pnlTnC.Visible = false;

        }

        private void activate()
        {
            try
            {
                if (Connection.con.State == ConnectionState.Open)
                { Connection.con.Close(); }
                Connection.con.Open();

                SqlCommand command = new SqlCommand("sp_cellphone_banking", Connection.con);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = null;

                command.Parameters.AddWithValue("@EmployeeNumber", lblEmp.Text);
                command.Parameters.AddWithValue("@AccessPinCode", txtCBAccessPin.Text);
                command.Parameters.AddWithValue("@CurentPin", txtCurrentPin.Text);
                command.Parameters.AddWithValue("@DateActivated", DateTime.Today.ToShortDateString());
                command.Parameters.AddWithValue("@DateModified", DateTime.Today.ToShortDateString());
                command.Parameters.AddWithValue("@Accepted", chkAccepted.Checked);
                command.Parameters.AddWithValue("@AccountNumber", accountNumber);

                rdr = command.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        lblReults.Text = "Cell phone banking has been activated successfuly";
                        picProgress.Image = global ::Banking_System.Properties.Resources.tick;
                    }
                }
                else
                {
                    lblReults.Text = "Unable to activate cell phone banking please make sure you old pin is correct";
                    picProgress.Image = global ::Banking_System.Properties.Resources.check_mark_errorcircle_error;
                }


                command.Dispose();
                rdr.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
               
        }
        
        private void btnChangePin_Click(object sender, EventArgs e)
        {
            txtCurrentPin.Focus();
            lblAccessPin.Show();
            lblReEnter.Show();
            lblAccessPin.Text = "New access pin code :";
            lblReEnter.Text = "Re-enter new access pin code :";
            lblCurrentPin.Show();
            txtCurrentPin.Show();
            txtCBAccessPin.Show();
            txtCBAccessPin2.Show();
            btnChangePin.Enabled = false;
            btnNext.Enabled = true;

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

        private void GetData()
        {
            if (Connection.con.State == ConnectionState.Open)
            { Connection.con.Close(); }
            Connection.con.Open();

            SqlCommand command = new SqlCommand("sp_cbretrive_customer_info", Connection.con);
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

                    txtCBName.Text = rdr["firstName"].ToString();
                    txtCBLastName.Text = rdr["lastName"].ToString();
                    txtCBSurname.Text = rdr["surname"].ToString();
                    txtCBContact.Text = rdr["cellNumber"].ToString();


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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool cellClick = true;

            if (cellClick == true)
            {
                
                if (e.RowIndex >= 0)
                {
                    try
                    {
                        DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                        accountNumber = row.Cells["Account_Number"].Value.ToString();
                        if (accountNumber == row.Cells["Account_Number"].Value.ToString())
                        {
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
        private void txtCBDateActivated_TextChanged(object sender, EventArgs e)
        {
            

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

        private void txtCBAccessPin2_TextChanged(object sender, EventArgs e)
        {
            if (txtCBAccessPin2.TextLength == 4)
            {
                if (txtCBAccessPin.Text == txtCBAccessPin2.Text)
                {

                }
                else
                {
                    MessageBox.Show("Password does not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Check()
        {
            try
            {
                if (Connection.con.State == ConnectionState.Open)
                { Connection.con.Close(); }
                Connection.con.Open();

                SqlCommand command = new SqlCommand("SELECT dateActivated FROM Customer.MobileBanking WHERE accNmrMobBank='" + accountNumber + "'", Connection.con);
                SqlDataReader rdr = null;

                rdr = command.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        txtCBDateActivated.Text = rdr["dateActivated"].ToString();
                        btnChangePin.Enabled = true;
                        btnNext.Enabled = false;
                        txtCBDateActivated.Show();
                        lblDateActivated.Show();
                        lblTick.Show();
                        picTick.Show();
                        lblAccessPin.Hide();
                        lblReEnter.Hide();
                        lblCurrentPin.Hide();
                        txtCurrentPin.Hide();
                        txtCBAccessPin.Hide();
                        txtCBAccessPin2.Hide();
                    }
                }
                else
                {
                    btnChangePin.Enabled = false;
                    btnNext.Enabled = true;
                    txtCBDateActivated.Hide();
                    lblDateActivated.Hide();
                    lblTick.Hide();
                    picTick.Hide();
                    lblAccessPin.Show();
                    lblReEnter.Show();
                    lblCurrentPin.Show();
                    txtCurrentPin.Show();
                    txtCBAccessPin.Show();
                    txtCBAccessPin2.Show();
                }

                command.Dispose();
                rdr.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

                command.Parameters.AddWithValue("@IdentityNumber", txtIdentity.Text);
                command.Parameters.AddWithValue("@AccountNumber", txtAccount.Text);
                command.Parameters.AddWithValue("@CheckID", "");
                command.Parameters.AddWithValue("@CheckAcc", "");

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
                pnlProcess.Visible = false;
                pnlTnC.Visible = false;

                GetAccounts();

                btnPrev.Enabled = true;

                btnInformation.BackColor = Color.WhiteSmoke;
                btnInformation.ForeColor = Color.Black;

                btnAccSelection.BackColor = Color.RoyalBlue;
                btnAccSelection.ForeColor = Color.White;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnSelected.BackColor = Color.WhiteSmoke;
                btnSelected.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }

            if (pnlInfo.Visible == true)
            {

                if (txtCBAccessPin.Text == "" && txtCBAccessPin2.Text == "")
                {
                    MessageBox.Show("Please tell the customer enter the cellphone banking pin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtCBAccessPin.TextLength < 4)
                {
                    MessageBox.Show("Password digits must be 4", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                pnlRetrive.Visible = false;
                pnlInfo.Visible = false;
                pnlAccSelection.Visible = false;
                pnlProcess.Visible = false;
                pnlTnC.Visible = true;

              
                btnInformation.BackColor = Color.WhiteSmoke;
                btnInformation.ForeColor = Color.Black;

                btnAccSelection.BackColor = Color.WhiteSmoke;
                btnAccSelection.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnSelected.BackColor = Color.RoyalBlue;
                btnSelected.ForeColor = Color.White;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }

            if (pnlAccSelection.Visible == true)
            {
                pnlRetrive.Visible = false;
                pnlInfo.Visible = true;
                pnlAccSelection.Visible = false;
                pnlProcess.Visible = false;
                pnlTnC.Visible = false;

                Check();

               

                btnInformation.BackColor = Color.RoyalBlue;
                btnInformation.ForeColor = Color.White;

                btnAccSelection.BackColor = Color.WhiteSmoke;
                btnAccSelection.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnSelected.BackColor = Color.WhiteSmoke;
                btnSelected.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }

            if (pnlTnC.Visible == true)
            {
                pnlRetrive.Visible = false;
                pnlInfo.Visible = false;
                pnlAccSelection.Visible = false;
                pnlProcess.Visible = true;
                pnlTnC.Visible = false;

                btnNext.Enabled = false;
                btnPrev.Enabled = false;

                btnInformation.BackColor = Color.WhiteSmoke;
                btnInformation.ForeColor = Color.Black;

                btnAccSelection.BackColor = Color.WhiteSmoke;
                btnAccSelection.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnSelected.BackColor = Color.WhiteSmoke;
                btnSelected.ForeColor = Color.Black;

                btnProcess.BackColor = Color.RoyalBlue;
                btnProcess.ForeColor = Color.White;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                activate();

                return;
            }

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {

            if (pnlInfo.Visible == true)
            {
                pnlRetrive.Visible = false;
                pnlInfo.Visible = false;
                pnlAccSelection.Visible = true;
                pnlProcess.Visible = false;
                pnlTnC.Visible = false;

                if (btnNext.Enabled == false)
                {
                    btnNext.Enabled = true;
                }

                btnInformation.BackColor = Color.WhiteSmoke;
                btnInformation.ForeColor = Color.Black;

                btnAccSelection.BackColor = Color.WhiteSmoke;
                btnAccSelection.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnSelected.BackColor = Color.WhiteSmoke;
                btnSelected.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }

            

          

            if (pnlAccSelection.Visible == true)
            {
                pnlRetrive.Visible = true;
                pnlInfo.Visible = false;
                pnlAccSelection.Visible = false;
                pnlProcess.Visible = false;
                pnlTnC.Visible = false;

                btnNext.Enabled = true;

                btnPrev.Enabled = false;

                txtIdentity.Clear();
                txtIdentity.Focus();

                btnInformation.BackColor = Color.WhiteSmoke;
                btnInformation.ForeColor = Color.Black;

                btnAccSelection.BackColor = Color.WhiteSmoke;
                btnAccSelection.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnSelected.BackColor = Color.WhiteSmoke;
                btnSelected.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.RoyalBlue;
                btnRetrive.ForeColor = Color.White;

                return;
            }

            if (pnlTnC.Visible == true)
            {
                pnlRetrive.Visible = false;
                pnlInfo.Visible = true;
                pnlAccSelection.Visible = false;
                pnlProcess.Visible = false;
                pnlTnC.Visible = false;
                btnPrev.Enabled = false;

                btnInformation.BackColor = Color.RoyalBlue;
                btnInformation.ForeColor = Color.White;

                btnAccSelection.BackColor = Color.WhiteSmoke;
                btnAccSelection.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnSelected.BackColor = Color.WhiteSmoke;
                btnSelected.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }
        }

    }
}
