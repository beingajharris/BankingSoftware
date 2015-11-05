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
    public partial class Balance : Form
    {
        public Balance()
        {
            InitializeComponent();
        }


        private void GetData()
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

                _with.AddWithValue("@AccountNumber", txtAcc.Text);
                _with.AddWithValue("@CheckID", "");
                _with.AddWithValue("@CheckAcc", txtAcc.Text);
                _with.AddWithValue("@IdentityNumber", "");
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
                        //txtAcc.Clear();
                        //txtAcc.Focus();

                        txtFirstName.Text = rdr["firstName"].ToString();
                        txtLastName.Text = rdr["lastName"].ToString();
                        txtSurname.Text = rdr["surname"].ToString();


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
                    lblError.Text = "Invalid account number";
                    picError.Image = global ::Banking_System.Properties.Resources.check_mark_errorcircle_error;
                    txtAcc.Clear();
                    txtAcc.Focus();
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


        private void GetBalance()
        {
            try
            {
                if (Connection.con.State == ConnectionState.Open)
                { Connection.con.Close(); }
                Connection.con.Open();

                SqlCommand command = new SqlCommand("sp_balance_check", Connection.con);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = null;

                command.Parameters.AddWithValue("@AccountNumber",txtAcc.Text);
                command.Parameters.AddWithValue("@PiCode",txtPinCode.Text);

                rdr=command.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        pnlBalance.Visible = true;
                        btnTransact.Text = "Balance";
                        txtAvailable.Text = rdr["available"].ToString();
                        txtBalance.Text = rdr["balance"].ToString();
                    }
                    
                }
                else
                    {
                        MessageBox.Show("Transaction declined due to incorrect pin entered","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        txtPinCode.Clear();
                        txtPinCode.Focus();
                    }

                rdr.Dispose();
                command.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Balance_Load(object sender, EventArgs e)
        {
            pnlInfo.Visible = false;
            PnlPinCode.Visible = false;
            pnlRetrive.Visible = true;
            pnlBalance.Visible = false;

            txtAcc.Focus();

            txtPinCode.MaxLength = 4;

            btnPrev.Enabled = false;

            btnRetrive.BackColor = Color.RoyalBlue;
            btnRetrive.ForeColor = Color.White;
        }

        private void txtAcc_TextChanged(object sender, EventArgs e)
        {
            if (txtAcc.TextLength == 10)
            {
                btnNext.PerformClick();
                GetData();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pnlRetrive.Visible == true)
            {
                if (txtAcc.Text == "")
                {
                    MessageBox.Show("Please enter account number to proceed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                pnlInfo.Visible = true;
                PnlPinCode.Visible = false;
                pnlRetrive.Visible = false;

                btnPrev.Enabled = true;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                btnInformation.BackColor = Color.RoyalBlue;
                btnInformation.ForeColor = Color.White;

                btnTransact.BackColor = Color.WhiteSmoke;
                btnTransact.ForeColor = Color.Black;

                return;
            }

            if (pnlInfo.Visible == true)
            {
                pnlInfo.Visible = false;
                PnlPinCode.Visible = true;
                pnlRetrive.Visible = false;

                btnNext.Enabled = false;
                btnPrev.Enabled = false;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                btnInformation.BackColor = Color.WhiteSmoke;
                btnInformation.ForeColor = Color.Black;

                btnTransact.BackColor = Color.RoyalBlue;
                btnTransact.ForeColor = Color.White;

                return;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (pnlInfo.Visible == true)
            {
                pnlInfo.Visible = false;
                PnlPinCode.Visible = false;
                pnlRetrive.Visible = true;

                btnNext.Enabled = true;
                btnPrev.Enabled = false;

                btnRetrive.BackColor = Color.RoyalBlue;
                btnRetrive.ForeColor = Color.White;

                btnInformation.BackColor = Color.WhiteSmoke;
                btnInformation.ForeColor = Color.Black;

                btnTransact.BackColor = Color.WhiteSmoke;
                btnTransact.ForeColor = Color.Black;

                return;
            }

            if (PnlPinCode.Visible == true)
            {
                pnlInfo.Visible = true;
                PnlPinCode.Visible = false;
                pnlRetrive.Visible = false;


                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                btnInformation.BackColor = Color.RoyalBlue;
                btnInformation.ForeColor = Color.White;

                btnTransact.BackColor = Color.WhiteSmoke;
                btnTransact.ForeColor = Color.Black;

                return;

            }

        }

        private void txtPinCode_TextChanged(object sender, EventArgs e)
        {
            if (txtPinCode.TextLength == 4)
            {
                GetBalance();
            }
        }
    }
}
