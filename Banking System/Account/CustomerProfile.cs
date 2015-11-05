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

namespace Banking_System
{
    public partial class CustomerProfile : Form
    {
        public CustomerProfile()
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
                btnNext.Enabled = true;
                parseIdNo(txtIdentity.Text);
            }
           
        }

        void GetData()
        {

            try
            {
                SqlCommand command = new SqlCommand("sp_customer_profile", Connection.con);
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

                        txtFistName.Text = rdr["firstName"].ToString();
                        txtLastName.Text = rdr["lastName"].ToString();
                        txtSurname.Text = rdr["surname"].ToString();
                        txtID.Text = rdr["identityNumber"].ToString();
                        txtGender.Text = rdr["gender"].ToString();
                        txtDOB.Text = rdr["DOB"].ToString();
                        txtDateOpened.Text = rdr["dateOpened"].ToString();
                        txtExpiryDate.Text = rdr["expires"].ToString();
                        txtCellNumber.Text = rdr["cellNumber"].ToString();
                        txtEmail.Text = rdr["email"].ToString();
                        txtAddress1.Text = rdr["address1"].ToString();
                        txtAddress2.Text = rdr["address2"].ToString();
                        txtAccountType.Text = rdr["accType"].ToString();
                        txtAccountState.Text = rdr["accState"].ToString();
                        txtAccountNumber.Text = rdr["accNumber"].ToString();

                        byte[] image = null;

                        //image = (byte[])(prodRow.Cells["Image"].Value);
                        image = (byte[])(rdr["picture"]);

                        if (image == null)
                        {
                            picCust.Image = null;
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(image);
                            picCust.Image = Image.FromStream(ms);
                        }
                    }
                    txtAccount.Clear();
                    txtIdentity.Clear();
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
                    txtIdentity.Clear();
                    txtAccount.Clear();
                }
                command.Dispose();
                rdr.Dispose();
            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
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
                btnNext.Enabled = true;
                GetData();
                btnNext.PerformClick();
            }
        }

        private void txtIdentity_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        //    If e.KeyChar >= "A" And e.KeyChar <= "Z" Or e.KeyChar >= "a" And e.KeyChar <= "z" Then
        //    e.Handled = True
        //    MsgBox("Enter Only Number")

        //End If

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {


            Single leftmarin = e.MarginBounds.Left;
            Single topmargin = e.MarginBounds.Top;
            Single myline = 0;
            Single ypostion = 0;
            int counter = 0;
            string currentline = "0";
            Font myfont = new Font("Aerial", 16, FontStyle.Regular, GraphicsUnit.Pixel);
            myline = e.MarginBounds.Height / myfont.GetHeight(e.Graphics);
            ypostion = topmargin + counter * myfont.GetHeight(e.Graphics);
            e.Graphics.DrawImage(this.picCust.Image, 632, 0);
            e.Graphics.DrawString("Customer Profile" + Environment.NewLine +
                               " " + Environment.NewLine +
                               "First National Bank " + Environment.NewLine +
                               " " + Environment.NewLine +
                               " " + Environment.NewLine +
                               "Personal Information " + Environment.NewLine +
                               " " + Environment.NewLine +
                               " " + Environment.NewLine +
                               "Fisrt Name_________:___________" + txtFistName.Text + Environment.NewLine +
                               "Last name__________:___________" + txtLastName.Text + Environment.NewLine +
                               "Surname____________:___________" + txtSurname.Text + Environment.NewLine +
                               "Identity Number____:___________" + txtID.Text + Environment.NewLine +
                               "Gender              :           " +  txtGender.Text + Environment.NewLine +
                               "Cell Number " + "\t : " + txtCellNumber.Text + Environment.NewLine +
                               "E-mail " + "\t" + "\t : " + txtEmail.Text + Environment.NewLine +
                               "Address1 " + "\t" + "\t : " + txtAddress1.Text + Environment.NewLine +
                               "Address2 " + "\t" + "\t : " + txtAddress2.Text + Environment.NewLine +
                               "Gender " + "\t" + "\t : " + txtGender.Text + Environment.NewLine +
                               " " + Environment.NewLine +
                               " " + Environment.NewLine +
                               "Account Information" + Environment.NewLine +
                               " " + Environment.NewLine +
                               " " + Environment.NewLine +
                               "Account Number " + "\t : " + txtAccount.Text + Environment.NewLine +
                               "Account Type " + "\t : " + txtAccountType.Text + Environment.NewLine +
                               "Account State " + "\t : " + txtAccountState.Text + Environment.NewLine +
                               "Date opened " + "\t : " + txtDateOpened.Text + Environment.NewLine +
                               "Expiring Date " + "\t : " + txtExpiryDate.Text + Environment.NewLine +
                               " ", myfont, Brushes.Black, leftmarin, ypostion, new StringFormat());
                              

        //     Dim leftmargin As Single = e.MarginBounds.Left
        //Dim topmargin As Single = e.MarginBounds.Top
        //Dim myline As Single = 0
        //Dim ypostion As Single = 0
        //Dim countre As Integer = 0
        //Dim currentline As String = 0
        //Dim myfont As New Font("Aerial", 12, FontStyle.Regular, GraphicsUnit.Pixel)
        //myline = e.MarginBounds.Height / myfont.GetHeight(e.Graphics)
        //ypostion = topmargin + countre * myfont.GetHeight(e.Graphics)
        //e.Graphics.DrawImage(Me.PictureBox1.Image, 0, 0)
        //e.Graphics.DrawString("______________________________________________________________ proof of Registration  _______________________________________________" & ControlChars.NewLine & _
        //                      " " & ControlChars.NewLine &
        //                      " Date            : " & Date.Now() & ControlChars.NewLine & _
        //                      " ID Number       : " & txtidno.Text & ControlChars.NewLine & _
        //                      " Studen Number   : " & lblstudentnum.Text & ControlChars.NewLine & _
        //                      " Intials         : " & txtinitial.Text & ControlChars.NewLine & _
        //                      " Student Names   : " & txtsurname.Text & Space(2) & txtfname.Text & Space(2) & txtsecname.Text & ControlChars.NewLine & _
        //                      " Student Surname : " & txtsurname.Text & ControlChars.NewLine & _
        //                      "===========================================Subject Registerd===============================================================================================================================================================================" & ControlChars.NewLine & _
        //                     "Course Code :" & cmbcoursid.Text & Space(2) & " Subject Code " & Space(2) & " Subject Name : " & RichTextBox4.Text & Space(2) & "level :" & lbllvl.Text & Space(2) & " P/F " & Space(10) & " Level" & Space(10) & " Cost" & ControlChars.NewLine & _
        //                      "===========================================================================================================================================================================================================================================" & ControlChars.NewLine & _
        //                      " ", myfont, Brushes.Black, leftmargin, ypostion, New StringFormat)



        }

        private void CustomerProfile_Load(object sender, EventArgs e)
        {
            pnlCustomerInfo.Visible = false;
            pnlAccountInfo.Visible = false;
            pnlRetrival.Visible = true;

            btnNext.Enabled = false;

            btnRetrive.BackColor = Color.RoyalBlue;
            btnRetrive.ForeColor = Color.White;

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pnlRetrival.Visible == true)
            {

                pnlCustomerInfo.Visible = true;
                pnlAccountInfo.Visible = false;
                pnlRetrival.Visible = false;

                btnPrev.Enabled = true;

                btnInformation.BackColor = Color.RoyalBlue;
                btnInformation.ForeColor = Color.White;


                btnSelected.BackColor = Color.WhiteSmoke;
                btnSelected.ForeColor = Color.Black;

                btnAccountInfo.BackColor = Color.WhiteSmoke;
                btnAccountInfo.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }

            if (pnlCustomerInfo.Visible == true)
            {
                pnlCustomerInfo.Visible = false;
                pnlAccountInfo.Visible = true;
                pnlRetrival.Visible = false;

                btnInformation.BackColor = Color.WhiteSmoke;
                btnInformation.ForeColor = Color.Black;

                btnSelected.BackColor = Color.WhiteSmoke;
                btnSelected.ForeColor = Color.Black;

                btnAccountInfo.BackColor = Color.RoyalBlue;
                btnAccountInfo.ForeColor = Color.White;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }

            if (pnlAccountInfo.Visible == true)
            {
                pnlCustomerInfo.Visible = false;
                pnlAccountInfo.Visible = false;
                pnlRetrival.Visible = false;

                btnNext.Enabled = false;
                btnPrev.Enabled = false;

                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();

                btnInformation.BackColor = Color.WhiteSmoke;
                btnInformation.ForeColor = Color.Black;

                btnSelected.BackColor = Color.RoyalBlue;
                btnSelected.ForeColor = Color.White;

                btnAccountInfo.BackColor = Color.WhiteSmoke;
                btnAccountInfo.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
           

            if (pnlCustomerInfo.Visible == true)
            {
                pnlCustomerInfo.Visible = false;
                pnlAccountInfo.Visible = false;
                pnlRetrival.Visible = true;

                btnNext.Enabled = false;
                btnPrev.Enabled = false;

                btnInformation.BackColor = Color.WhiteSmoke;
                btnInformation.ForeColor = Color.Black;

                btnSelected.BackColor = Color.WhiteSmoke;
                btnSelected.ForeColor = Color.Black;

                btnAccountInfo.BackColor = Color.WhiteSmoke;
                btnAccountInfo.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.RoyalBlue;
                btnRetrive.ForeColor = Color.White;

                return;
            }

            if (pnlAccountInfo.Visible == true)
            {
                pnlCustomerInfo.Visible = true;
                pnlAccountInfo.Visible = false;
                pnlRetrival.Visible = false;

                btnInformation.BackColor = Color.RoyalBlue;
                btnInformation.ForeColor = Color.White;

                btnSelected.BackColor = Color.WhiteSmoke;
                btnSelected.ForeColor = Color.Black;

                btnAccountInfo.BackColor = Color.WhiteSmoke;
                btnAccountInfo.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }
        }

        }
    }

