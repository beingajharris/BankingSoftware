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
    public partial class MDIParent1 : Form
    {
        string serial_number;
        int sec = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            pnlTransact.Visible = false;
            pnlNavigation.Enabled = false;
            panel2.Hide();
            pnlAccount.Hide();

            toolStripStatusLabel1.Text = "Not Connected";
            try
            {
                if (Connection.con.State == ConnectionState.Open)
                { Connection.con.Close(); }
                Connection.con.Open();
            }
            catch (Exception ex)
            {
                OutOfService outOfService = new OutOfService();
                outOfService.Show();
                this.Hide();
            }
            toolStripStatusLabel1.Text = "Connected to database";

            ManagementObjectSearcher searchInfo_Board = new ManagementObjectSearcher("Select * from Win32_BaseBoard");

           foreach (ManagementObject i in searchInfo_Board.Get())
           {
               serial_number = i["SerialNumber"].ToString();
           }

        }

        private void btnsingin_Click_2(object sender, EventArgs e)
        {
            
            try
            {

                if (Connection.con.State == ConnectionState.Open)
                { Connection.con.Close(); }
                Connection.con.Open();

                SqlCommand command = new SqlCommand("sp_sign_in", Connection.con);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = null;
                string Name,surname,locked,serial,employeeNumber;

                var _with = command.Parameters;

                _with.AddWithValue("@UserName", txtusername.Text);
                _with.AddWithValue("@Password", txtpassword.Text);
                _with.AddWithValue("@ErrorMsg", serial_number);

                rdr = command.ExecuteReader();
                
                if (rdr.HasRows)
                {

                    while (rdr.Read())
                    {
                        if (txtpassword.Text == rdr["userPwd"].ToString())
                        {
                            locked = rdr["lock"].ToString();
                            Name = rdr["firstname"].ToString();
                            surname = rdr["surname"].ToString();
                            serial = rdr["errorMsg"].ToString();
                            employeeNumber = rdr["empNumber"].ToString();

                            if (locked == "False")
                            {
                                pnlNavigation.Enabled = true;
                                panel2.Show();
                                pnlLogin.Hide();
                                toolStripStatusLabel2.Text = "Signed in as " + Name + " " + surname;
                                toolStripStatusLabel4.Text = employeeNumber;
                                timer1.Start();
                            }
                            else if (locked == "True" && serial == serial_number)
                            {
                                pnlNavigation.Enabled = true;
                                panel2.Show();
                                pnlLogin.Hide();
                                toolStripStatusLabel2.Text = "Signed in as " + Name + " " + surname;
                                toolStripStatusLabel4.Text =  employeeNumber;
                                timer1.Start();
                            }
                            else
                            {
                                MessageBox.Show("you have signed in on another computer please sign out from that computer first, computer serial number " + serial , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {

                            string Attempts;
                            
                            
                            Attempts = rdr["pwdAttempt"].ToString();
                            MessageBox.Show("Incorrect password, you haave " + Attempts + " password attempt(s) left." , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtpassword.Clear();
                            txtpassword.Focus();
                        }
                        
                    }
                }
                else 
                {
                    MessageBox .Show ("Invalid username entered, please enter a valid username.", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

                command.Dispose();
                rdr.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void btncancel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pnlAccount.Visible == true)
            {
                pnlAccount.Visible = false;
                btnTransact.Enabled = true;
            }
            else
            {
                pnlAccount.Visible = true;
                btnTransact.Enabled = false;
            }
            
        }

        private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnNewAcc_Click(object sender, EventArgs e)
        {
            Customerr customer = new Customerr();
            customer.ShowDialog();
            sec = 0;
            timer1.Stop();
        }

        private void SignOut()
        {
            try
            {
                if (Connection.con.State == ConnectionState.Open)
                { Connection.con.Close(); }
                Connection.con.Open();

                SqlCommand cmd1 = new SqlCommand("UPDATE [Users].[Users] SET lock='False' WHERE userName='" + txtusername.Text + "'", Connection.con);
                cmd1.ExecuteNonQuery();
                Connection.con.Close();
                cmd1.Dispose();
                Application.Exit();
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MDIParent1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SignOut();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            CellPhoneBank bank = new CellPhoneBank();
            bank.Show();
            bank.lblEmp.Text = toolStripStatusLabel4.Text;
            sec = 0;
            timer1.Stop();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            RemoteBank remote = new RemoteBank();
            remote.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.ShowDialog();
            sec = 0;
            timer1.Stop();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Statement statement = new Statement();
            statement.ShowDialog();
            sec = 0;
            timer1.Stop();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CustomerProfile customerProfile = new CustomerProfile();
            customerProfile.ShowDialog();
            sec = 0;
            timer1.Stop();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            StopOrder stopOrder = new StopOrder();
            stopOrder.ShowDialog();
            sec = 0;
            timer1.Stop();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Account.AccountManagement AccountManagement = new Account.AccountManagement();
            AccountManagement.ShowDialog();
            sec = 0;
            timer1.Stop();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
           
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {

            //if (sec < 60)
            //{
            //    sec = sec + 1;
                
            //}

            //if (sec == 60)
            //{
            //    Application.Restart();
            //}

        }

        private void MDIParent1_Enter(object sender, EventArgs e)
        {
            //timer1.Start();
        }

        private void MDIParent1_Activated(object sender, EventArgs e)
        {
            //timer1.Start();
        }

        private void btnDeposite_Click(object sender, EventArgs e)
        {
            Deposite deposite = new Deposite();
            deposite.ShowDialog();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            Transfer transfer = new Transfer();
            transfer.ShowDialog();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            Withdrawal withdraw = new Withdrawal();
            withdraw.ShowDialog();
        }

        private void btnbalance_Click(object sender, EventArgs e)
        {
            Balance balance = new Balance();
            balance.ShowDialog();
        }

        private void btnTransact_Click(object sender, EventArgs e)
        {
            if (pnlTransact.Visible == true)
            {
                pnlTransact.Visible = false;
                button1.Enabled = true;
            }
            else
            {
                pnlTransact.Visible = true;
                button1.Enabled = false;
            }
        }
    }
}
