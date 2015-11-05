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

namespace Banking_System.Account
{
    public partial class AccountManagement : Form
    {
        public AccountManagement()
        {
            InitializeComponent();
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


        private void txtIdentity_TextChanged(object sender, EventArgs e)
        {
            if (txtIdentity.TextLength >= 1)
            {
                txtAccount.Enabled = false;
            }
            else
            {
                txtAccount.Enabled = true;
            }

            if (txtIdentity.Text.Length == 13)
            {
                parseIdNo(txtIdentity.Text);
            }
        }

        private void txtAccount_TextChanged(object sender, EventArgs e)
        {
            if (txtAccount.TextLength >= 1)
            {
                txtIdentity.Enabled = false;
            }
            else
            {
                txtIdentity.Enabled = true;
            }

            if (txtAccount.Text.Length == 10)
            {
                btnNext.PerformClick();
                GetData();
            }
        }

        void GetData()
        {
            try
            {
                if (Connection.con.State == ConnectionState.Open)
                { Connection.con.Close(); }
                Connection.con.Open();

                SqlCommand command = new SqlCommand("sp_retrive_customer_info", Connection.con);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = null;

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

                        txtFirstName.Text = rdr["firstName"].ToString();
                        txtLastName.Text = rdr["lastName"].ToString();
                        txtSurname.Text = rdr["surname"].ToString();
                        txtID.Text = rdr["identityNumber"].ToString();
                        txtGender.Text = rdr["gender"].ToString();
                        txtDOB.Text = rdr["DOB"].ToString();
                        txtContact.Text = rdr["cellNumber"].ToString();
                        txtEmail.Text = rdr["email"].ToString();
                        txtAddress.Text = rdr["address1"].ToString();
                        txtAddress2.Text = rdr["address2"].ToString();
                        
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
                    lblError.Text = "No information found";
                    picError.Image = global ::Banking_System.Properties.Resources.check_mark_errorcircle_error;
                    btnNext.Enabled = false;
                }
                command.Dispose();
                rdr.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void AccountManagement_Load(object sender, EventArgs e)
        {
            pnlRetrive.Visible = true;
            pnlInfo.Visible = false;
            pnlSelection.Visible = false;
            pnlSelected.Visible = false;
            pnlAccSelection.Visible = false;
            pnlProcess.Visible = false;

            btnRetrive.BackColor = Color.RoyalBlue;
            btnRetrive.ForeColor = Color.White;

            cboSelect.SelectedIndex = 0;
            lblFrom.Hide();
            lblTo.Hide();
            txtTo.Hide();
            txtFrom.Hide();

            lblselect.Hide();
            cboSelect.Hide();
           
        }

        private void btnFreeze_Click(object sender, EventArgs e)
        {
            btnNext.Enabled = true;
            pnlFreez.Visible = true;
            pnlDailyLimit.Visible = false;
            pnlChangePin.Visible = false;
            btnSelected.Text = btnFreeze.Text;
            btnNext.PerformClick();
        }

        private void btnChangePin_Click(object sender, EventArgs e)
        {
            btnNext.Enabled = true;
            pnlFreez.Visible = false;
            pnlDailyLimit.Visible = false;
            pnlChangePin.Visible = true;
            btnSelected.Text = btnChangePin.Text;
            btnNext.PerformClick();
        }

        string accountNumber;

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

        private void Freezing()
        {
            picProgress.Image = global::Banking_System.Properties.Resources._31;
            try
            {
                if (Connection.con.State == ConnectionState.Open)
                { Connection.con.Close(); }
                Connection.con.Open();

                SqlCommand command = new SqlCommand("sp_freezing", Connection.con);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = null;

                command.Parameters.AddWithValue("@Reason", rctReason.Text);
                command.Parameters.AddWithValue("@DateFreeze", DateTime.Today.ToShortDateString());
                command.Parameters.AddWithValue("@AccountNumber", accountNumber);

                rdr = command.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        label7.Text = "The account has been froozen";
                        picProgress.Image = global::Banking_System.Properties.Resources.tick;
                    }
                }
                else
                {
                    label7.Text = "Unable to freeze account " + accountNumber;
                    picProgress.Image = global::Banking_System.Properties.Resources.check_mark_errorcircle_error;
                }

                command.Dispose();
                rdr.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChangeDailyLimit()
        {
            picProgress.Image = global::Banking_System.Properties.Resources._31;

            try
            {
                if (Connection.con.State == ConnectionState.Open)
                { Connection.con.Close(); }
                Connection.con.Open();

                
                SqlCommand command = new SqlCommand("sp_update_daily_limit", Connection.con);
                SqlDataReader rdr = null;

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Amount", txtNewDailyAmount.Text);
                command.Parameters.AddWithValue("@Period", cboPeriod.Text);
                command.Parameters.AddWithValue("@From", DateTime.Today.ToShortDateString());
                command.Parameters.AddWithValue("@Selected", cboPeriod.Text);
                command.Parameters.AddWithValue("@To", cboSelect.Text);
                command.Parameters.AddWithValue("@AccountNumber", accountNumber);

                rdr = command.ExecuteReader();

                
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        picProgress.Image = global::Banking_System.Properties.Resources.tick;
                        txtFrom.Text = rdr["From"].ToString();
                        txtTo.Text = rdr["To"].ToString();

                        if (txtTo.Text == "" || txtFrom.Text == "")
                        {
                            label7.Text = "The daily limit has been changed to " + txtNewDailyAmount.Text;
                            return;
                        }

                        label7.Text = "The daily limit has been changed to " + txtNewDailyAmount.Text + " which is valid from now until " + txtTo.Text;
                        picProgress.Image = global::Banking_System.Properties.Resources.tick;
                    }
                }
                else
                {
                    label7.Text = "unable to change the daily limit";
                    picProgress.Image = global::Banking_System.Properties.Resources.check_mark_errorcircle_error;
                }

                command.Dispose();
                rdr.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdatePin()
        {
            picProgress.Image = global::Banking_System.Properties.Resources._31;
            try
            {
                if (Connection.con.State == ConnectionState.Open)
                { Connection.con.Close(); }
                Connection.con.Open();

                SqlCommand command = new SqlCommand("sp_update_pincode", Connection.con);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = null;
                string attempts;

                command.Parameters.AddWithValue("@NewPin", txtNewpin.Text);
                command.Parameters.AddWithValue("@PinEntered", txtCurrentpin.Text);
                command.Parameters.AddWithValue("@AccountNumber", accountNumber);

                rdr = command.ExecuteReader();

                if (rdr.HasRows)
                {
                    label7.Text = "Pin code has been successfuly changed";
                    picProgress.Image = global::Banking_System.Properties.Resources.tick;
                }
                else
                {
                    if (Connection.con.State == ConnectionState.Open)
                    { Connection.con.Close(); }
                    Connection.con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT pinAtempt FROM Customer.Account WHERE accNumber ='" + accountNumber + "'", Connection.con);
                    SqlDataReader rdr1 = null;

                    rdr1 = cmd.ExecuteReader();

                    if (rdr1.HasRows)
                    {
                        while (rdr1.Read())
                        {
                            attempts = rdr1["pinAtempt"].ToString();
                            label7.Text = "Cannot change pin code due to the old pin code entered was wrong, you can try again but you have left with " + attempts + " attempts for you account to be suspended";
                            picProgress.Image = global::Banking_System.Properties.Resources.check_mark_errorcircle_error;
                        }
                    }
                    else
                    {
                        label7.Text = "Unable to change the pin";
                        picProgress.Image = global ::Banking_System.Properties.Resources.check_mark_errorcircle_error;
                    }

                }

                rdr.Dispose();
                command.Dispose();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string accountNumber;

            bool cellClick = true;

            if (cellClick == true)
            {
                //display seleccted information if the selected new car row
                //from datagridview to the fields  
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

        private void btnDailLimit_Click(object sender, EventArgs e)
        {
            btnNext.Enabled = true;
            pnlDailyLimit.Visible = true;
            pnlChangePin.Visible = false;
            pnlFreez.Visible = false;
            btnSelected.Text = btnDailLimit.Text;
            btnNext.PerformClick();
        }
        void days()
        {
            cboSelect.Items.Clear();
            cboSelect.Items.Add("1");
            cboSelect.Items.Add("2");
            cboSelect.Items.Add("3");
            cboSelect.Items.Add("4");
            cboSelect.Items.Add("6");
            cboSelect.Items.Add("6");
            cboSelect.Items.Add("7");
            cboSelect.Items.Add("8");
            cboSelect.Items.Add("9");
            cboSelect.Items.Add("10");
            cboSelect.Items.Add("11");
            cboSelect.Items.Add("12");
            cboSelect.Items.Add("13");
            cboSelect.Items.Add("14");
            cboSelect.Items.Add("15");
            cboSelect.Items.Add("16");
            cboSelect.Items.Add("17");
            cboSelect.Items.Add("18");
            cboSelect.Items.Add("19");
            cboSelect.Items.Add("20");
            cboSelect.Items.Add("21");
            cboSelect.Items.Add("22");
            cboSelect.Items.Add("23");
            cboSelect.Items.Add("24");
            cboSelect.Items.Add("25");
            cboSelect.Items.Add("26");
            cboSelect.Items.Add("27");
            cboSelect.Items.Add("28");
            cboSelect.Items.Add("29");
            cboSelect.Items.Add("30");
            cboSelect.SelectedIndex = 0;
        }
        void weeks()
        {
            cboSelect.Items.Clear();
            cboSelect.Items.Add("1");
            cboSelect.Items.Add("2");
            cboSelect.Items.Add("3");
            cboSelect.Items.Add("4");
            cboSelect.SelectedIndex = 0;
        }
        void months()
        {
            cboSelect.Items.Clear();
            cboSelect.Items.Add("1");
            cboSelect.Items.Add("2");
            cboSelect.Items.Add("3");
            cboSelect.Items.Add("4");
            cboSelect.Items.Add("5");
            cboSelect.Items.Add("6");
            cboSelect.Items.Add("7");
            cboSelect.Items.Add("8");
            cboSelect.Items.Add("9");
            cboSelect.Items.Add("10");
            cboSelect.Items.Add("11");
            cboSelect.Items.Add("12");
            cboSelect.SelectedIndex = 0;
        }
        private void cboPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPeriod.SelectedIndex == 0 || cboPeriod.SelectedIndex == 2 || cboPeriod.SelectedIndex == 4)
            {
                lblselect.Hide();
                cboSelect.Hide();
            }

            if (cboPeriod.SelectedIndex == 1)
            {
                lblselect.Show();
                cboSelect.Show();
                lblselect.Text = "Select Days";
                days();

            }

            if (cboPeriod.SelectedIndex == 2)
            {
                lblselect.Show();
                cboSelect.Show();
                lblselect.Text = "Select Weeks";
                weeks();
            }

            if (cboPeriod.SelectedIndex == 3)
            {
                lblselect.Show();
                cboSelect.Show();
                lblselect.Text = "Select Months";
                months();
            }

        }

        private void cboSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
                command.Parameters.AddWithValue("@CheckID", txtIdentity.Text);
                command.Parameters.AddWithValue("@CheckAcc", txtAccount.Text);

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
        private void PreProcess()
        {
            if (btnSelected.Text == btnDailLimit.Text)
            {
                ChangeDailyLimit();
            }

            if (btnSelected.Text == btnFreeze.Text)
            {
                Freezing();
            }
            if (btnSelected.Text == btnChangePin.Text)
            {
                UpdatePin();
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
                pnlInfo.Visible = true;
                pnlSelection.Visible = false;
                pnlSelected.Visible = false;
                pnlAccSelection.Visible = false;
                pnlProcess.Visible = false;
                btnPrev.Enabled = true;

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

                btnSelection.BackColor = Color.WhiteSmoke;
                btnSelection.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }

            if (pnlInfo.Visible == true)
            {
                pnlRetrive.Visible = false;
                pnlInfo.Visible = false;
                pnlSelection.Visible = true;
                pnlSelected.Visible = false;
                pnlAccSelection.Visible = false;
                pnlProcess.Visible = false;

                btnNext.Enabled = false;

                btnPrev.Enabled = true;

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

                btnSelection.BackColor = Color.RoyalBlue;
                btnSelection.ForeColor = Color.White;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }

            if (pnlSelection.Visible == true)
            {
                pnlRetrive.Visible = false;
                pnlInfo.Visible = false;
                pnlSelection.Visible = false;
                pnlSelected.Visible = true;
                pnlAccSelection.Visible = false;
                pnlProcess.Visible = false;
                
                btnPrev.Enabled = true;

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

                btnSelection.BackColor = Color.WhiteSmoke;
                btnSelection.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }

            if (pnlSelected.Visible == true)
            {
                pnlRetrive.Visible = false;
                pnlInfo.Visible = false;
                pnlSelection.Visible = false;
                pnlSelected.Visible = false;
                pnlAccSelection.Visible = true;
                pnlProcess.Visible = false;
                btnPrev.Enabled = true;

                GetAccounts();

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

                btnSelection.BackColor = Color.WhiteSmoke;
                btnSelection.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }

            if (pnlAccSelection.Visible == true)
            {
                pnlRetrive.Visible = false;
                pnlInfo.Visible = false;
                pnlSelection.Visible = false;
                pnlSelected.Visible = false;
                pnlAccSelection.Visible = false;
                pnlProcess.Visible = true;
                btnPrev.Enabled = false;

                PreProcess();

                btnInformation.BackColor = Color.WhiteSmoke;
                btnInformation.ForeColor = Color.Black;

                btnAccSelection.BackColor = Color.WhiteSmoke;
                btnAccSelection.ForeColor = Color.Black;

                btnProcess.BackColor = Color.RoyalBlue;
                btnProcess.ForeColor = Color.White;

                btnSelected.BackColor = Color.WhiteSmoke;
                btnSelected.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnSelection.BackColor = Color.WhiteSmoke;
                btnSelection.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }
        }

        private void btnChangePinClear_Click(object sender, EventArgs e)
        {
            txtNewDailyAmount.Clear();
            cboPeriod.Text = "";
            cboSelect.Text = "";
        }

        private void btnDailyClear_Click(object sender, EventArgs e)
        {

        }

        private void btnFreezeClear_Click(object sender, EventArgs e)
        {
            rctReason.Clear();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {

            if (pnlInfo.Visible == true)
            {
                pnlRetrive.Visible = true;
                pnlInfo.Visible = false;
                pnlSelection.Visible = false;
                pnlSelected.Visible = false;
                pnlAccSelection.Visible = false;
                pnlProcess.Visible = false;

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

                btnSelection.BackColor = Color.WhiteSmoke;
                btnSelection.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.RoyalBlue;
                btnRetrive.ForeColor = Color.White;

                return;
            }

            if (pnlSelection.Visible == true)
            {
                pnlRetrive.Visible = false;
                pnlInfo.Visible = true;
                pnlSelection.Visible = false;
                pnlSelected.Visible = false;
                pnlAccSelection.Visible = false;
                pnlProcess.Visible = false;
                btnPrev.Enabled = true;

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

                btnSelection.BackColor = Color.WhiteSmoke;
                btnSelection.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }

            if (pnlSelected.Visible == true)
            {
                pnlRetrive.Visible = false;
                pnlInfo.Visible = false;
                pnlSelection.Visible = true;
                pnlSelected.Visible = false;
                pnlAccSelection.Visible = false;
                pnlProcess.Visible = false;
                btnPrev.Enabled = true;

                GetAccounts();

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

                btnSelection.BackColor = Color.RoyalBlue;
                btnSelection.ForeColor = Color.White;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }

            if (pnlAccSelection.Visible == true)
            {
                pnlRetrive.Visible = false;
                pnlInfo.Visible = false;
                pnlSelection.Visible = false;
                pnlSelected.Visible = true;
                pnlAccSelection.Visible = false;
                pnlProcess.Visible = false;
                btnPrev.Enabled = true;

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

                btnSelection.BackColor = Color.WhiteSmoke;
                btnSelection.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }

        }

        private void txtReEnterPin_TextChanged(object sender, EventArgs e)
        {
            if (txtReEnterPin.TextLength == 4)
            {
                if (txtReEnterPin.Text == txtNewpin.Text)
                {

                }
                else
                {
                    MessageBox.Show("Password does not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewpin.Clear();
                    txtReEnterPin.Clear();
                    txtNewpin.Focus();
                }
            }
        }

    }
}
