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
using System.Management;

namespace Banking_System
{
    public partial class Transfer : Form
    {
        string serial_number;

        public Transfer()
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
                
                _with.AddWithValue("@CheckID", "");
                _with.AddWithValue("@CheckAcc", txtAcc.Text);
                _with.AddWithValue("@IdentityNumber", "");
                _with.AddWithValue("@AccountNumber", txtAcc.Text);
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

        private void Transact()
        {
            try
            {
                
                ManagementObjectSearcher searchInfo_Board = new ManagementObjectSearcher("Select * from Win32_BaseBoard");

                foreach (ManagementObject i in searchInfo_Board.Get())
                {
                    serial_number = i["SerialNumber"].ToString();
                }

                if (Connection.con.State == ConnectionState.Open)
                { Connection.con.Close(); }
                Connection.con.Open();

                SqlCommand command = new SqlCommand("sp_transfer", Connection.con);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = null;

                
                command.Parameters.AddWithValue("@AccountNumber", txtAcc.Text);
                command.Parameters.AddWithValue("@AccTransfer", txtAccountNumber.Text);
                command.Parameters.AddWithValue("@PostingDate", DateTime.Today.ToShortDateString());
                command.Parameters.AddWithValue("@TransDescription", "");
                command.Parameters.AddWithValue("@TransDescription1", "");
                command.Parameters.AddWithValue("@PinCode", txtPinCode.Text);
                command.Parameters.AddWithValue("@AccHolder",txtAccHolder.Text);
                command.Parameters.AddWithValue("@Amount",txtAmount.Text);
                command.Parameters.AddWithValue("@Available", "");
                command.Parameters.AddWithValue("@Balance", "");
                command.Parameters.AddWithValue("@Available1", "");
                command.Parameters.AddWithValue("@Balance1", "");
                command.Parameters.AddWithValue("@ComputerSN", serial_number);
                command.Parameters.AddWithValue("@CheckAccHlder", "");
                command.Parameters.AddWithValue("@TransDate", DateTime.Today.ToShortDateString());
                command.Parameters.AddWithValue("@Total", "");
                
                rdr = command.ExecuteReader();

                if (rdr.HasRows)
                {
                    picResult.Image = global::Banking_System.Properties.Resources.tick;
                    lblResult.Text = "Transaction was completed successfuly";
                }
                else
                {
                    if (Connection.con.State == ConnectionState.Open)
                    { Connection.con.Close(); }
                    Connection.con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT ErrorMsg FROM ErrorMsg WHERE ComputerSN='" + serial_number + "'", Connection.con);
                    SqlDataReader dr = null;
                    string msg;
                    dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            msg = dr["ErrorMsg"].ToString();
                            picResult.Image = global::Banking_System.Properties.Resources.check_mark_errorcircle_error;
                            lblResult.Text = msg;
                        }
                    }
                    dr.Dispose();
                    cmd.Dispose();

                    //picResult.Image = global::Banking_System.Properties.Resources.check_mark_errorcircle_error;
                    //lblResult.Text = "Unable to complete the transaction";
                }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Transfer_Load(object sender, EventArgs e)
        {
            pnlInfo.Visible = false;
            pnlProcess.Visible = false;
            PnlTransact.Visible = false;
            pnlRetrive.Visible = true;

            btnPrev.Enabled = false;

            btnRetrive.BackColor = Color.RoyalBlue;
            btnRetrive.ForeColor = Color.White;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pnlRetrive.Visible == true)
            {
                pnlInfo.Visible = true;
                pnlProcess.Visible = false;
                PnlTransact.Visible = false;
                pnlRetrive.Visible = false;

                btnPrev.Enabled = true;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                btnInformation.BackColor = Color.RoyalBlue;
                btnInformation.ForeColor = Color.White;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnTransact.BackColor = Color.WhiteSmoke;
                btnTransact.ForeColor = Color.Black;

                return;
            }

            if (pnlInfo.Visible == true)
            {
                pnlInfo.Visible = false;
                pnlProcess.Visible = false;
                PnlTransact.Visible = true;
                pnlRetrive.Visible = false;

                pnlPinCode.Visible = true;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                btnInformation.BackColor = Color.WhiteSmoke;
                btnInformation.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnTransact.BackColor = Color.RoyalBlue;
                btnTransact.ForeColor = Color.White;

                return;
            }

            if (PnlTransact.Visible == true)
            {
                pnlInfo.Visible = false;
                pnlProcess.Visible = true;
                PnlTransact.Visible = false;
                pnlRetrive.Visible = false;

                Transact();

                btnNext.Enabled = false;
                btnPrev.Enabled = false;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                btnInformation.BackColor = Color.WhiteSmoke;
                btnInformation.ForeColor = Color.Black;

                btnProcess.BackColor = Color.RoyalBlue;
                btnProcess.ForeColor = Color.White;

                btnTransact.BackColor = Color.WhiteSmoke;
                btnTransact.ForeColor = Color.Black;

                return;

            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            

            if (pnlInfo.Visible == true)
            {
                pnlInfo.Visible = false;
                pnlProcess.Visible = false;
                PnlTransact.Visible = false;
                pnlRetrive.Visible = true;

                btnPrev.Enabled = false;

                btnRetrive.BackColor = Color.RoyalBlue;
                btnRetrive.ForeColor = Color.White;

                btnInformation.BackColor = Color.WhiteSmoke;
                btnInformation.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnTransact.BackColor = Color.WhiteSmoke;
                btnTransact.ForeColor = Color.Black;

                return;
            }

            if (PnlTransact.Visible == true)
            {
                pnlInfo.Visible = true;
                pnlProcess.Visible = false;
                PnlTransact.Visible = false;
                pnlRetrive.Visible = false;


                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                btnInformation.BackColor = Color.RoyalBlue;
                btnInformation.ForeColor = Color.White;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnTransact.BackColor = Color.WhiteSmoke;
                btnTransact.ForeColor = Color.Black;

                return;

            }

            if (pnlProcess.Visible == true)
            {
                pnlInfo.Visible = false;
                pnlProcess.Visible = false;
                PnlTransact.Visible = true;
                pnlRetrive.Visible = false;


                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                btnInformation.BackColor = Color.RoyalBlue;
                btnInformation.ForeColor = Color.White;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnTransact.BackColor = Color.WhiteSmoke;
                btnTransact.ForeColor = Color.Black;

                return;

            }

        }

        private void txtAcc_TextChanged(object sender, EventArgs e)
        {
            if (txtAcc.TextLength == 10)
            {
                btnNext.PerformClick();
                GetData();
            }
        }

        private void txtPinCode_TextChanged(object sender, EventArgs e)
        {
            if (txtPinCode.TextLength == 4)
            {
                pnlPinCode.Visible = false;
            }
        }
    }
}
