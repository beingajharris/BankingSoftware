using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banking_System
{
    public partial class OutOfService : Form
    {
        public OutOfService()
        {
            InitializeComponent();
        }

        private void OutOfService_Load(object sender, EventArgs e)
        {

        }
            int sec;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (sec <= 5)
            {
                sec = sec + 1;
            }
           
            try
            {
                if (Connection.con.State == ConnectionState.Open)
                { Connection.con.Close(); }
                Connection.con.Open();
                timer1.Stop();
                Application.Restart();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Out of Service";
                timer1.Start();
            }

            if (sec == 5)
            {
                sec = 0;
            }

        }

        private void OutOfService_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show("The application will automaticaly start when its able to connect to the server", "Banking Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //this.Hide();       
        }
    }
}
