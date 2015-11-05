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
using WIA;
using System.Diagnostics;
using System.Threading;

namespace Banking_System
{
    public partial class Customer : Form
    {

        int newDoc = 0;
        int cmbCMIndex = 0;
        Stopwatch sw = new Stopwatch();

        public Customer()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          

        }

       public bool parseIdNo(string idNo)
       {
           try { 
               int a = 0;
               for (int i = 0; (i<=5); i++) 
               {
                   a = (a + int.Parse (idNo.Substring ((i*2), 1)));
               }
               int b= 0;
               for (int i = 0; (i <=5); i++){
                   b = ((b * 10)
                       + int .Parse (idNo.Substring(((2*i) + 1),1)));
               }
                b *= 2;
               int c = 0;
               for (
                   ; ((b <=0) == false);)
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

               if ((d == int.Parse(idNo.Substring(12 ,1))))
               {
                   btnNext.PerformClick();
                   GetData();
                   return true;
               }
               else
               {
                   btnNext.PerformClick();
                   btnNext.Enabled = false;
                   picError.Image = global::Banking_System.Properties.Resources.check_mark_errorcircle_error;
                   lblError.Text = "The identity number entered is not a valid SA identity number, please try again";
                   txtID.Clear();
                   txtID.Focus();
                   return false;
               }
           }
           catch (Exception ex )
           {
               return false;
           }
       }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.TextLength == 13)
            {
                parseIdNo(txtID.Text);
                
            }

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

                _with.AddWithValue("@IdentityNumber", txtID.Text);
                _with.AddWithValue("@CheckID", txtID.Text);
                _with.AddWithValue("@CheckAcc", "");
                _with.AddWithValue("@AccountNumber", "");
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
                        txtIdentity.Text = rdr["identityNumber"].ToString();
                        txtGender.Text = rdr["gender"].ToString();
                        txtDOB.Text = rdr["DOB"].ToString();
                        txtContact.Text = rdr["cellNumber"].ToString();
                        txtEmail.Text = rdr["email"].ToString();
                        txtAddress.Text = rdr["address1"].ToString();
                        txtAddress2.Text = rdr["address2"].ToString();

                        byte[] image = null;
                        byte[] image1 = null;
                        byte[] image2 = null;
                        byte[] image3 = null;

                        image = (byte[])(rdr["picture"]);
                        image1 = (byte[])(rdr["idCopy"]);
                        image2 = (byte[])(rdr["Residence"]);
                        image3 = (byte[])(rdr["ConsernForm"]);

                        if (image == null)
                        {
                            picCust.Image = null;
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(image);
                            picCust.Image = Image.FromStream(ms);
                        }



                        if (image1 == null)
                        {
                            picDoc1.Image = null;
                        }
                        else
                        {
                            MemoryStream ms1 = new MemoryStream(image1);
                            picDoc1.Image = Image.FromStream(ms1);
                        }





                        if (image2 == null)
                        {
                            picDoc2.Image = null;
                        }
                        else
                        {
                            MemoryStream ms2 = new MemoryStream(image2);
                            picDoc2.Image = Image.FromStream(ms2);
                        }

                        if (image3 == null)
                        {
                            picDoc3.Image = null;
                        }
                        else
                        {
                            MemoryStream ms3 = new MemoryStream(image3);
                            picDoc3.Image = Image.FromStream(ms3);
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
                if (pnlFound.Visible == true)
                {
                    pnlFound.Visible = false;
                    pnlNotFound.Visible = true;
                }
                else
                {
                    pnlNotFound.Visible = true;
                }

                lblError.Text = ex.Message;
                picError.Image = global ::Banking_System.Properties.Resources.check_mark_errorcircle_error;
                btnNext.Enabled = false;
            }
        }
            WebCam webcam;
        private void Customer_Load(object sender, EventArgs e)
        {
            webcam = new WebCam();
            webcam.InitializeWebCam(ref picCust);


            pnlPersonalInfo.Visible = false;
            pnlPicture.Visible = false;
            pnlDocs.Visible = false;
            pnlProces.Visible = false;
            pnlRetrive.Visible = true;
            btnPrev.Enabled = false;

            btnRetrive.BackColor = Color.RoyalBlue;
            btnRetrive.ForeColor = Color.White;
            txtID.Focus();

            txtPath.Text = Path.GetTempPath();
            nudHeightInch.Value = 11;
            nudWidthInch.Value = 8;
            cmbColorMode.SelectedIndex = 1;

        }
        
        private void btnstartcam_Click(object sender, EventArgs e)
        {
            if (btnstartcam.Text == "Start Camera")
            {
                webcam.Start();
                btnstartcam.Text = "Capture";
                return;
            }
            if (btnstartcam.Text == "Capture")
            {
                webcam.Stop();
                btnstartcam.Text = "Start Camera";
            }
        }

        private void btnStopCam_Click(object sender, EventArgs e)
        {
            webcam.Stop();
        }

        private static void AdjustScannerSettings(IItem scannnerItem, int scanResolutionDPI, int scanStartLeftPixel, int scanStartTopPixel,
                int scanWidthPixels, int scanHeightPixels, int brightnessPercents, int contrastPercents, int colorMode)
        {
            const string WIA_SCAN_COLOR_MODE = "6146";
            const string WIA_HORIZONTAL_SCAN_RESOLUTION_DPI = "6147";
            const string WIA_VERTICAL_SCAN_RESOLUTION_DPI = "6148";
            const string WIA_HORIZONTAL_SCAN_START_PIXEL = "6149";
            const string WIA_VERTICAL_SCAN_START_PIXEL = "6150";
            const string WIA_HORIZONTAL_SCAN_SIZE_PIXELS = "6151";
            const string WIA_VERTICAL_SCAN_SIZE_PIXELS = "6152";
            const string WIA_SCAN_BRIGHTNESS_PERCENTS = "6154";
            const string WIA_SCAN_CONTRAST_PERCENTS = "6155";
            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_RESOLUTION_DPI, scanResolutionDPI);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_RESOLUTION_DPI, scanResolutionDPI);
            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_START_PIXEL, scanStartLeftPixel);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_START_PIXEL, scanStartTopPixel);
            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_SIZE_PIXELS, scanWidthPixels);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_SIZE_PIXELS, scanHeightPixels);
            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_BRIGHTNESS_PERCENTS, brightnessPercents);
            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_CONTRAST_PERCENTS, contrastPercents);
            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_COLOR_MODE, colorMode);



        }

        private static void SetWIAProperty(IProperties properties, object propName, object propValue)
        {
            Property prop = properties.get_Item(ref propName);
            prop.set_Value(ref propValue);
        }

        private static void SaveImageToTiff(ImageFile image, string fileName)
        {
            ImageProcess imgProcess = new ImageProcess();
            object convertFilter = "Convert";
            string convertFilterID = imgProcess.FilterInfos.get_Item(ref convertFilter).FilterID;
            imgProcess.Filters.Add(convertFilterID, 0);
            SetWIAProperty(imgProcess.Filters[imgProcess.Filters.Count].Properties, "FormatID", WIA.FormatID.wiaFormatTIFF);
            image = imgProcess.Apply(image);
            image.SaveFile(fileName);
        }
        private void ScanDoc()
        {
            try
            {
                CommonDialogClass commonDialogClass = new CommonDialogClass();
                Device scannerDevice = commonDialogClass.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, false, false);
                if (scannerDevice != null)
                {
                    Item scannnerItem = scannerDevice.Items[1];
                    AdjustScannerSettings(scannnerItem, (int)nudRes.Value, 0, 0, (int)nudWidth.Value, (int)nudHeight.Value, 0, 0, cmbCMIndex);

                    object scanResult = commonDialogClass.ShowTransfer(scannnerItem, WIA.FormatID.wiaFormatTIFF, false);
                    //picScan.Image = (System.Drawing.Image)scanResult;
                    if (scanResult != null)
                    {
                        ImageFile image = (ImageFile)scanResult;
                        string fileName = "";

                        var files = Directory.GetFiles(txtPath.Text, "*.tiff");

                        try
                        {
                            string f = ((files.Max(p1 => Int32.Parse(Path.GetFileNameWithoutExtension(p1)))) + 1).ToString();
                            fileName = txtPath.Text + "\\" + f + ".tiff";
                        }
                        catch (Exception ex)
                        {
                            fileName = txtPath.Text + "\\" + "1.tiff";
                        }
                        SaveImageToTiff(image, fileName);
                        picScan.ImageLocation = fileName;
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Check the Device Connection \n or \n Change the Scanner Device", "Devic Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void bgwScan_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!bgwScan.CancellationPending)
            {
                if (newDoc == 0)
                {
                    newDoc = 1;
                    ScanDoc();

                }

                for (int k = 1; k <= 10 * (int)nudTime.Value; k++)
                {

                    Thread.Sleep(100);

                    bgwScan.ReportProgress((int)(k / (int)nudTime.Value));
                    if (k == 10 * (int)nudTime.Value)
                        newDoc = 0;
                }
            }
        }

        private void bgwScan_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            btnStopScan.PerformClick();
            pbWaiting.Value = (int)e.ProgressPercentage * 10;
            sw.Start();
            txtWT.Text = (int)nudTime.Value - (int)(sw.ElapsedMilliseconds / 1000) + " Secs. Remaining";

            if (pbWaiting.Value == 100)
            {
                pbWaiting.Value = 0;
                txtWT.Text = "Proccessing";
                sw.Reset();
                sw.Stop();
            }
        }

        private void bgwScan_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            {
                if (e.Cancelled) MessageBox.Show("Operation was canceled");
                else if (e.Error != null) MessageBox.Show(e.Error.Message);
                //else MessageBox.Show("Processing");
            }
        }

        private void cbxCustomPixel_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCustomPixel.Checked == true)
            {
                nudWidth.ReadOnly = false;
                nudHeight.ReadOnly = false;
            }
            else
            {
                nudWidth.ReadOnly = true;
                nudHeight.ReadOnly = true;
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            bgwScan.RunWorkerAsync(5000);
            btnScan.Enabled = false;
            btnStopScan.Enabled = true;
            cmbColorMode.Enabled = false;
            nudWidthInch.Enabled = false;
            nudHeightInch.Enabled = false;
            nudRes.Enabled = false;
            cbxCustomPixel.Enabled = false;
            nudHeight.Enabled = false;
            nudWidth.Enabled = false;

            cmbCMIndex = cmbColorMode.SelectedIndex;
        }

        private void btnStopScan_Click(object sender, EventArgs e)
        {
            bgwScan.CancelAsync();
            btnScan.Enabled = true;
            btnStopScan.Enabled = false;
            cmbColorMode.Enabled = true;

            //
            btnScan.Enabled = true;
            btnStopScan.Enabled = false;
            cmbColorMode.Enabled = true;
            nudWidthInch.Enabled = true;
            nudHeightInch.Enabled = true;
            nudRes.Enabled = true;
            cbxCustomPixel.Enabled = true;
            if (cbxCustomPixel.Checked == true)
            {
                nudHeight.Enabled = true;
                nudWidth.Enabled = true;
            }


            sw.Reset();
            sw.Stop();
        }

        private void nudWidthInch_ValueChanged(object sender, EventArgs e)
        {
            nudWidth.Value = nudRes.Value * nudWidthInch.Value;
        }

        private void nudRes_ValueChanged(object sender, EventArgs e)
        {
            nudWidth.Value = nudRes.Value * nudWidthInch.Value;

            nudHeight.Value = nudRes.Value * nudHeightInch.Value;
        }

        private void nudHeight_ValueChanged(object sender, EventArgs e)
        {
            nudHeight.Value = nudRes.Value * nudHeightInch.Value;
        }

        int number = 1;

        private void picScan_Click(object sender, EventArgs e)
        {

            if (number == 1)
            {
                picDoc1.Image = picScan.Image;
                number = number + 1;
                return;
            }

            if (number == 2)
            {
                picDoc2.Image = picScan.Image;
                number = number + 1;
                return;
            }
            if (number == 3)
            {
                picDoc3.Image = picScan.Image;
                return;
            }
            

        }

        private void picDoc1_Click(object sender, EventArgs e)
        {
            picScan.Image = picDoc1.Image;
        }

        private void picDoc2_Click(object sender, EventArgs e)
        {
            picScan.Image = picDoc2.Image;
        }

        private void picDoc3_Click(object sender, EventArgs e)
        {
            picScan.Image = picDoc3.Image;
        }

        private void Save()
        {
            try
            {


                if (Connection.con.State == ConnectionState.Open)
                { Connection.con.Close(); }
                Connection.con.Open();


                SqlCommand command = new SqlCommand("sp_update_customer", Connection.con);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = null;

                command.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                command.Parameters.AddWithValue("@LastName", txtLastName.Text);
                command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                command.Parameters.AddWithValue("@BOD", txtDOB.Text);
                command.Parameters.AddWithValue("@IdentityNumber", txtIdentity.Text);
                command.Parameters.AddWithValue("@gender", txtGender.Text);

                command.Parameters.AddWithValue("@CellNumber", txtContact.Text);
                command.Parameters.AddWithValue("@Email", txtEmail.Text);
                command.Parameters.AddWithValue("@Address1", txtAddress.Text);
                command.Parameters.AddWithValue("@Address2", txtAddress2.Text);


                MemoryStream ms = new MemoryStream();
                picCust.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();

                SqlParameter picCus = new SqlParameter("@picture", SqlDbType.Image);
                picCus.Value = data;
                command.Parameters.Add(picCus);

                MemoryStream ms2 = new MemoryStream();
                picDoc1.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data2 = ms2.GetBuffer();
                SqlParameter picDo1 = new SqlParameter("@Residence", SqlDbType.Image);
                picDo1.Value = data2;
                command.Parameters.Add(picDo1);

                MemoryStream ms3 = new MemoryStream();
                picDoc2.Image.Save(ms3, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data3 = ms3.GetBuffer();
                SqlParameter picDo2 = new SqlParameter("@ConsernForm", SqlDbType.Image);
                picDo2.Value = data3;
                command.Parameters.Add(picDo2);

                MemoryStream ms4 = new MemoryStream();
                picDoc3.Image.Save(ms4, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data4 = ms4.GetBuffer();
                SqlParameter picDo3 = new SqlParameter("@Surety", SqlDbType.Image);
                picDo3.Value = data4;
                command.Parameters.Add(picDo3);

                command.Parameters.AddWithValue("@Today", DateTime.Today.ToShortDateString());

                rdr = command.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        pictureBox1.Image = global::Banking_System.Properties.Resources.tick;
                        lblResult.Text = "Customer infromation has been successfully updated";
                    }
                }
                else
                {
                    lblResult.Text = "Customer information was not updated";
                    pictureBox1.Image = global::Banking_System.Properties.Resources.check_mark_errorcircle_error;
                }

                rdr.Dispose();
                command.Dispose();

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
                pnlPersonalInfo.Visible = true;
                pnlPicture.Visible = false;
                pnlDocs.Visible = false;
                pnlProces.Visible = false;
                pnlRetrive.Visible = false;
                btnPrev.Enabled = true;

                btnInfor.BackColor = Color.RoyalBlue;
                btnInfor.ForeColor = Color.White;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnDocuments.BackColor = Color.WhiteSmoke;
                btnDocuments.ForeColor = Color.Black;

                btnPicture.BackColor = Color.WhiteSmoke;
                btnPicture.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;
                return;
            }

            if (pnlPersonalInfo.Visible == true)
            {
                pnlPersonalInfo.Visible = false;
                pnlPicture.Visible = true;
                pnlDocs.Visible = false;
                pnlProces.Visible = false;
                pnlRetrive.Visible = false;

                btnInfor.BackColor = Color.WhiteSmoke;
                btnInfor.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnDocuments.BackColor = Color.WhiteSmoke;
                btnDocuments.ForeColor = Color.Black;

                btnPicture.BackColor = Color.RoyalBlue;
                btnPicture.ForeColor = Color.White;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }

            if (pnlPicture.Visible == true)
            {
                pnlPersonalInfo.Visible = false;
                pnlPicture.Visible = false;
                pnlDocs.Visible = true;
                pnlProces.Visible = false;
                pnlRetrive.Visible = false;

                btnInfor.BackColor = Color.WhiteSmoke;
                btnInfor.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnDocuments.BackColor = Color.RoyalBlue;
                btnDocuments.ForeColor = Color.White;

                btnPicture.BackColor = Color.WhiteSmoke;
                btnPicture.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }

            if (pnlDocs.Visible == true)
            {
                pnlPersonalInfo.Visible = false;
                pnlPicture.Visible = false;
                pnlDocs.Visible = false;
                pnlProces.Visible = true;
                pnlRetrive.Visible = false;

                btnPrev.Enabled = false;
                btnNext.Enabled = false;

                Save();

                btnInfor.BackColor = Color.WhiteSmoke;
                btnInfor.ForeColor = Color.Black;

                btnProcess.BackColor = Color.RoyalBlue;
                btnProcess.ForeColor = Color.White;

                btnDocuments.BackColor = Color.WhiteSmoke;
                btnDocuments.ForeColor = Color.Black;

                btnPicture.BackColor = Color.WhiteSmoke;
                btnPicture.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {

            if (pnlPersonalInfo.Visible == true)
            {
                pnlPersonalInfo.Visible = false;
                pnlPicture.Visible = false;
                pnlDocs.Visible = false;
                pnlProces.Visible = false;
                pnlRetrive.Visible = true;
                btnPrev.Enabled = false;

                btnNext.Enabled = true;

                txtID.Clear();
                txtID.Focus();

                btnInfor.BackColor = Color.WhiteSmoke;
                btnInfor.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnDocuments.BackColor = Color.WhiteSmoke;
                btnDocuments.ForeColor = Color.Black;

                btnPicture.BackColor = Color.WhiteSmoke;
                btnPicture.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.RoyalBlue;
                btnRetrive.ForeColor = Color.White;

                return;
            }

            if (pnlPicture.Visible == true)
            {
                pnlPersonalInfo.Visible = true;
                pnlPicture.Visible = false;
                pnlDocs.Visible = false;
                pnlProces.Visible = false;
                pnlRetrive.Visible = false;

                btnInfor.BackColor = Color.RoyalBlue;
                btnInfor.ForeColor = Color.White;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnDocuments.BackColor = Color.WhiteSmoke;
                btnDocuments.ForeColor = Color.Black;

                btnPicture.BackColor = Color.WhiteSmoke;
                btnPicture.ForeColor = Color.Black;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }

            if (pnlDocs.Visible == true)
            {
                pnlPersonalInfo.Visible = false;
                pnlPicture.Visible = true;
                pnlDocs.Visible = false;
                pnlProces.Visible = false;
                pnlRetrive.Visible = false;

                btnInfor.BackColor = Color.WhiteSmoke;
                btnInfor.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnDocuments.BackColor = Color.WhiteSmoke;
                btnDocuments.ForeColor = Color.Black;

                btnPicture.BackColor = Color.RoyalBlue;
                btnPicture.ForeColor = Color.White;

                btnRetrive.BackColor = Color.WhiteSmoke;
                btnRetrive.ForeColor = Color.Black;

                return;
            }

        }

    }
}
