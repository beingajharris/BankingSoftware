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
    public partial class StopOrder : Form
    {
                string opperation = "";
                bool operation_pressed = false;

        public StopOrder()
        {
            InitializeComponent();
        }
        private void GetData()
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Account.StopOrder WHERE accNmr ='" + textBox11.Text + "'" ,Connection.con);
                DataTable table = new DataTable();

                table.Load(command.ExecuteReader());


                dataGridView1.DataSource = table;

                table.Dispose();
                command.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void opperator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            opperation = b.Text;
            operation_pressed = true;

            string message;

            message = "";

            switch (opperation)
            {
                case "&Add":
                    message = "&Add";
                    break;

                case "&Remove":
                    message = "&Remove";
                    break;

                case "&Reverse transaction":
                    message = "&Reverse transaction";
                    break;
                default:
                    break;
            }

            operation_pressed = false;

            //MessageBox.Show(message.ToString());

            try
            {
                SqlCommand command = new SqlCommand("sp_stop_order",Connection.con);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = null;


                command.Parameters.AddWithValue("@AccHolder", txtAccHolder.Text);
                command.Parameters.AddWithValue("@DateTransaction", dateTimePicker1.Text);
                command.Parameters.AddWithValue("@DateAdded", DateTime.Today.ToShortDateString());
                command.Parameters.AddWithValue("@Selected", message);
                command.Parameters.AddWithValue("@AccountNumber", txtAccountNumber.Text);
                command.Parameters.AddWithValue("@Amount", txtAmount.Text);
                command.Parameters.AddWithValue("@AccNumber", textBox11.Text);


                rdr = command.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        if (message == "&Add")
                        {
                            MessageBox.Show("Added successfully");
                        }

                        if (message == "&Remove")
                        {
                            MessageBox.Show("Removed");
                        }
                    }
                }
                else
                {
                    if (message == "&Add")
                    {
                        MessageBox.Show("Adding unsuccessfully");
                    }

                    if (message == "&Remove")
                    {
                        MessageBox.Show("Failed to remove");
                    }
                }


                command.Dispose();
                rdr.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void tabPage5_Enter(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetInfo()
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
                    MessageBox.Show("No record found");
                }
                command.Dispose();
                rdr.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void txtIdentity_TextChanged(object sender, EventArgs e)
        {
            if (txtIdentity.TextLength > 1)
            {
                txtAccount.Enabled = false;
            }
            else
            {
                txtAccount.Enabled = true;
            }

            if (txtIdentity.TextLength==13)
            {
                GetInfo();
            }

        }

        private void tabPage4_Enter(object sender, EventArgs e)
        {
            try
            {
                if (Connection.con.State == ConnectionState.Open)
                { Connection.con.Close(); }
                Connection.con.Open();

                SqlCommand command = new SqlCommand("sp_get_accounts", Connection.con);
                command.CommandType = CommandType.StoredProcedure;
                DataTable table = new DataTable();

                command.Parameters.AddWithValue("@IdentityNumber", txtID.Text);

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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool cellClick = true;

            if (cellClick == true)
            {
                //display seleccted information if the selected new car row
                //from datagridview to the fields  
                if (e.RowIndex >= 0)
                {
                    try
                    {
                        DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                        textBox11.Text = row.Cells["Account_Number"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private void StopOrder_Load(object sender, EventArgs e)
        {

        }
    }
}
