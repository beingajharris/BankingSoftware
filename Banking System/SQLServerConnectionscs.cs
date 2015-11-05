using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace Banking_System
{
    public partial class SQLServerConnectionscs : Form
    {
        public SQLServerConnectionscs()
        {
            InitializeComponent();
        }

        SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder();
        //public string RootPath();

        public string GetServerName()
        {
            return conn.DataSource;
        }

        public string GetDatabaseName()
        {
            return conn.InitialCatalog;
        }

        public string GetUserName()
        {
            return conn.UserID;
        }

        public string GetPassword()
        {
            return conn.Password;
        }

        public bool GetSecurity()
        {
            return conn.IntegratedSecurity;
        }

        private void SQLServerConnectionscs_Load(object sender, EventArgs e)
        {

            cbServer.Text = conn.DataSource;
            cbDataBase.Text = conn.InitialCatalog;

            if (conn.IntegratedSecurity == false)
            {
             txtUser.Enabled = true;
            txtPassword.Enabled = true;
            rbAuthenticationWin.Checked = false;
            rbAuthenticationSql.Checked = true;
            txtUser.Text = conn.UserID;
            txtPassword.Text = conn.Password;

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SqlInstances();
        }
        void ContructConnection()
        {
            conn.DataSource = cbServer.Text;
            conn.IntegratedSecurity = true;
            conn.UserID = "";
            conn.Password = "";
            conn.InitialCatalog = "";

            if (rbAuthenticationSql.Checked)
            {
                conn.IntegratedSecurity = false;
                conn.UserID = txtUser.Text;
                conn.Password = txtPassword.Text;
            }
            if (cbDataBase.Text != "")
            {
                conn.IntegratedSecurity = Convert.ToBoolean(cbDataBase.Text);
            }
        }

        void SqlInstances()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                cbServer.Items.Clear();
                DataTable sqlSources;

            }

    //    Sub SqlInstances()
            //    
            //    Try
            //        cbServer.Items.Clear()
            //        Dim sqlSources As DataTable = SqlDataSourceEnumerator.Instance.GetDataSources
            //        For Each datarow As DataRow In sqlSources.Rows
            //            Dim datasource As String = datarow("ServerName").ToString
            //            If Not datarow("InstanceName") Is DBNull.Value Then
            //                datasource &= String.Format("\{0}", datarow("InstanceName"))
            //            End If
            //            cbServer.Items.Add(datasource)
            //        Next
            //    Catch ex As Exception
            //        MsgBox(ex.Message)
            //    End Try
            //    Cursor.Current = Cursors.Default
            //End Sub




            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



             
                   
        }

    
    }
}
