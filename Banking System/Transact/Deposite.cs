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

namespace Banking_System
{
    public partial class Deposite : Form
    {
        public Deposite()
        {
            InitializeComponent();
        }

        private void Deposite_Load(object sender, EventArgs e)
        {
            txtAccountNumber.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
        
        }

        private void txtAccountNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtAccountNumber.TextLength == 10)
            {
                GetAccHolder();
                txtAccountNumber.Enabled = false;
            }
        }
        private void GetAccHolder()
        {
            try
            {
                string name, lastName, surname;

                if (Connection.con.State == ConnectionState.Open)
                { Connection.con.Close(); }
                Connection.con.Open();

                SqlCommand command = new SqlCommand("sp_account_holder", Connection.con);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = null;

                command.Parameters.AddWithValue("@AccountNumber", txtAccountNumber.Text);

                rdr = command.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {

                        txtAccHolder.Text = rdr["accountHolder"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Unknown account number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAccountNumber.Clear();
                    txtAccountNumber.Focus();
                }
                rdr.Dispose();
                command.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtCash_Leave(object sender, EventArgs e)
        {

        }
        private void Deposites()
        {
            try
            {
                if (Connection.con.State == ConnectionState.Open)
                { Connection.con.Close(); }
                Connection.con.Open();

                SqlCommand command = new SqlCommand("sp_deposite", Connection.con);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = null;

                command.Parameters.AddWithValue("@AccountNumber", txtAccountNumber.Text);
                command.Parameters.AddWithValue("@Amount", txtAmount.Text);
                command.Parameters.AddWithValue("@Available", "");
                command.Parameters.AddWithValue("@Balance", "");
                command.Parameters.AddWithValue("@TransDescription", "");
                command.Parameters.AddWithValue("@TransDate", DateTime.Today.ToShortDateString());
                command.Parameters.AddWithValue("@PostingDate", DateTime.Today.ToShortDateString());

                rdr = command.ExecuteReader();

                if (rdr.HasRows)
                {
                    MessageBox.Show("Amount " + txtAmount.Text + " was sent to " + txtAccHolder.Text + " successfuly", "Banking Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnCancel.PerformClick();
                }
                else
                {
                    MessageBox.Show("Unable to perform the transaction","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                 
                rdr.Dispose();
                command.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnDeposite_Click(object sender, EventArgs e)
        {


            decimal amount, cash, change;

            if (txtAmount.Text == "")
            {
                MessageBox.Show("Please enter amount to be deposited", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmount.Clear();
                txtAmount.Focus();
                return;
            }

            if (txtCash.Text == "")
            {
                MessageBox.Show("Please enter the cash received", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCash.Clear();
                txtCash.Focus();
                return;
            }

            amount = (Convert.ToDecimal(txtAmount.Text));
            cash = (Convert.ToDecimal(txtCash.Text));


            if (cash < amount)
            {
                MessageBox.Show("The amount is more than the amount received", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCash.Clear();
                txtCash.Focus();
                return;
            }

            change = cash - amount;

            txtChange.Text = change.ToString("C2");

            Deposites();
        }

        private void txtAccountNumber_Leave(object sender, EventArgs e)
        {
            if (txtAccountNumber.Text == "")
            {
                MessageBox.Show("Please enter the account number to proceed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountNumber.Focus();
                return;
            }
            if (txtAccountNumber.TextLength < 10)
            {
                MessageBox.Show("The account number digits must be 10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountNumber.Focus();
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtAccHolder.Clear();
            txtAccountNumber.Clear();
            txtAmount.Clear();
            txtCash.Clear();
            txtChange.Clear();
            txtAccountNumber.Enabled = true;
            txtAccountNumber.Focus();
        }
    }
}
