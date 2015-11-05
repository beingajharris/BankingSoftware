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
    public partial class Customerr : Form
    {
        public Customerr()
        {
            InitializeComponent();
        }


        int newDoc = 0;
        int cmbCMIndex = 0;
        Stopwatch sw = new Stopwatch();

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

        public void FillCombo()
        {
            try
            {
               
                SqlCommand command = new SqlCommand("SELECT AccountType FROM [Account].[Type] ORDER BY AccountType", Connection.con);
                SqlDataReader rdr = null;

                rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    cboAccoutType.Items.Add(rdr[0]);
                }
               command.Dispose();
                rdr.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            
        }
        WebCam webcam;
        private void Customerr_Load(object sender, EventArgs e)
        {
            pnlAccPinCode.Hide();
            pnlAccTnC.Hide();
            pnlAccType.Hide();
            pnlDailyAmount.Hide();
            pnlPersonalInfo.Show();
            pnlPicture.Hide();
            pnlScan.Hide();
            pnlWelcome.Hide();
            pnlProccess.Hide();
            btnPersonalInfo.BackColor = Color.RoyalBlue;
            btnPersonalInfo.ForeColor = Color.White;
            btnPrev.Enabled = false;

            webcam = new WebCam();
            webcam.InitializeWebCam(ref picCust);



            if (Connection.con.State == ConnectionState.Open)
            { Connection.con.Close(); }
            Connection.con.Open();
            
            axAcroPDF1.src = @"C:\Users\SURPRISEE\Documents\School Stuff\CREDIT REHABILITATION PACK_LP101325_20140919103121.pdf";

            txtPath.Text = Path.GetTempPath();
            nudHeightInch.Value = 11;
            nudWidthInch.Value = 8;
            cmbColorMode.SelectedIndex = 1;


            FillCombo();
        }

        private void txtIdentity_KeyPress(object sender, KeyPressEventArgs e)
        {

        //    If e.KeyChar >= "A" And e.KeyChar <= "Z" Or e.KeyChar >= "a" And e.KeyChar <= "z" Then
        //    e.Handled = True
        //    MsgBox("Enter Only Number")

        //End If
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

        private void btnStartScan_Click(object sender, EventArgs e)
        {
            bgwScan.RunWorkerAsync(5000);
            btnStartScan.Enabled = false;
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
            btnStartScan.Enabled = true;
            btnStopScan.Enabled = false;
            cmbColorMode.Enabled = true;

            //
            btnStartScan.Enabled = true;
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

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            
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

        private void bgwScan_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            {
                if (e.Cancelled) MessageBox.Show("Operation was canceled");
                else if (e.Error != null) MessageBox.Show(e.Error.Message);
                //else MessageBox.Show("Processing");
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

        private void nudWidthInch_ValueChanged(object sender, EventArgs e)
        {
            nudWidth.Value = nudRes.Value * nudWidthInch.Value;
        }

        private void nudHeightInch_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nudRes_ValueChanged(object sender, EventArgs e)
        {
            nudWidth.Value = nudRes.Value * nudWidthInch.Value;

            nudHeight.Value = nudRes.Value * nudHeightInch.Value;
        }

        private void nudWidth_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void nudHeight_ValueChanged(object sender, EventArgs e)
        {
            nudHeight.Value = nudRes.Value * nudHeightInch.Value;
        }

        int number = 1;

        private void picScan_Click(object sender, EventArgs e)
        {


            //number = number + 1;

            if (number == 1)
            {
                picDoc1.Image = picScan.Image;
                number = number + 1;
                MessageBox.Show("Now scan the customer profe of residence", "Banking Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (number == 2)
            {
                picDoc2.Image = picScan.Image;
                MessageBox.Show("Now scan a concern form if it will be needed", "Banking Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                number = number + 1;
                return;
            }
            if (number == 3)
            {
                picDoc3.Image = picScan.Image;
                MessageBox.Show("Now scan a surety ID copy", "Banking Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                number = number + 1;
                return;
            }
            if (number == 4)
            {
                picDoc4.Image = picScan.Image;
                MessageBox.Show("You can now proceed by clicking next", "Banking Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void tabPage6_Enter(object sender, EventArgs e)
        {
           
        }

        private void txtAccAccessPin2_TextChanged(object sender, EventArgs e)
        {
            if (txtAccAccessPin2.TextLength == 4)
            {

                if (txtAccAccessPin2.Text == txtAccAccessPin.Text)
                {

                }
                else
                {
                    MessageBox.Show("Pin Code does not match", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAccAccessPin2.Clear();
                    txtAccAccessPin2.Focus();
                }
            }
        }

        private void tabPage5_Enter(object sender, EventArgs e)
        {
            
        }

        private void cboAccoutType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT [Description],OpeningBal,MinimumBal FROM [Account].[Type] WHERE AccountType='" + cboAccoutType.Text + "'", Connection.con);
                SqlDataReader rdr = null;

                rdr = command.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        txtDescription.Text = rdr["Description"].ToString();
                        txtOpeningBal.Text = rdr["OpeningBal"].ToString();
                        txtMinBal.Text = rdr["MinimumBal"].ToString();
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
                    string year, month, day;
                    
                        year = "19" + txtIdentity.Text.Substring(0, 2);
                        month = txtIdentity.Text.Substring(2, 2);
                        day = txtIdentity.Text.Substring(4, 2);
                        txtBOD.Text = year + "/" + month + "/" + day;
                    
                    return true;
                }
                else
                {

                    MessageBox.Show("The identity number entered is not a valid SA identity number, please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (txtIdentity.TextLength == 13)
            {
                parseIdNo(txtIdentity.Text);
            }
        }

        private void Save()
        {
            
            try
            {
                SqlCommand command = new SqlCommand("sp_save_customer", Connection.con);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = null;

                //[Account]
                command.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                command.Parameters.AddWithValue("@LastName", txtLastname.Text);
                command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                command.Parameters.AddWithValue("@IdentityNumber", txtIdentity.Text);
                command.Parameters.AddWithValue("@BOD", txtBOD.Text);
                command.Parameters.AddWithValue("@gender", txtGender.Text);
                command.Parameters.AddWithValue("@Initials", "");
                command.Parameters.AddWithValue("@Title", "");
                command.Parameters.AddWithValue("@AccountHolder", "");

                //Images
                MemoryStream ms = new MemoryStream();
                picCust.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();

                SqlParameter picCus = new SqlParameter("@picture", SqlDbType.Image);
                picCus.Value = data;
                command.Parameters.Add(picCus);

                MemoryStream ms2 = new MemoryStream();
                picDoc1.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data2 = ms2.GetBuffer();
                SqlParameter picDo1 = new SqlParameter("@IdCopy", SqlDbType.Image);
                picDo1.Value = data2;
                command.Parameters.Add(picDo1);

                MemoryStream ms3 = new MemoryStream();
                picDoc2.Image.Save(ms3, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data3 = ms3.GetBuffer();
                SqlParameter picDo2 = new SqlParameter("@Residence", SqlDbType.Image);
                picDo2.Value = data3;
                command.Parameters.Add(picDo2);


                MemoryStream ms4 = new MemoryStream();
                picDoc3.Image.Save(ms4, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data4 = ms4.GetBuffer();
                SqlParameter picDo3 = new SqlParameter("@ConsernForm", SqlDbType.Image);
                picDo3.Value = data4;
                command.Parameters.Add(picDo3);


                MemoryStream ms5 = new MemoryStream();
                picDoc4.Image.Save(ms5, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data5 = ms5.GetBuffer();
                SqlParameter picDo4 = new SqlParameter("@SuretyIDcopy", SqlDbType.Image);
                picDo4.Value = data5;
                command.Parameters.Add(picDo4);

                //Acount
                command.Parameters.AddWithValue("@AccountType", cboAccoutType.Text);
                command.Parameters.AddWithValue("@Pin", txtAccAccessPin.Text);
                command.Parameters.AddWithValue("@PinAtempt", "3");
                command.Parameters.AddWithValue("@Available", "0.00");
                command.Parameters.AddWithValue("@Balance", "0.00");
                command.Parameters.AddWithValue("@AccState", "Inactive");
                command.Parameters.AddWithValue("@DateOpened", DateTime.Today.ToShortDateString());
                command.Parameters.AddWithValue("@Expires", DateTime.Today.ToShortDateString());

                //Contact
                command.Parameters.AddWithValue("@CellNumber", txtContactNo.Text);
                command.Parameters.AddWithValue("@Email", txtEmail.Text);
                command.Parameters.AddWithValue("@Address1", txtAddress.Text);
                command.Parameters.AddWithValue("@Address2", txtAddress2.Text);

                //Acount TnC
                command.Parameters.AddWithValue("@Accepted", chkAccTnC.Checked);

                //Daily limits
                command.Parameters.AddWithValue("@AccNmbDaily", "");
                command.Parameters.AddWithValue("@Amount", txtAmount.Text);
                command.Parameters.AddWithValue("@AccountNumber", "");
                command.Parameters.AddWithValue("@AccNumber", "");
              

                rdr = command.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        label2.Text = "New account has been created successfully";
                        picProgress.Image = global::Banking_System.Properties.Resources.tick;
                    }
                }
                else
                {
                    label2.Text = "Creating of new account was unsuccessfully";
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
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pnlPersonalInfo.Visible == true)
            {
                pnlPicture.Visible = true;
                pnlAccPinCode.Visible = false;
                pnlAccTnC.Visible = false;
                pnlAccType.Visible = false;
                pnlDailyAmount.Visible = false;
                pnlProccess.Visible = false;
                pnlScan.Visible = false;
                pnlWelcome.Visible = false;
                pnlPersonalInfo.Visible = false;
                btnPrev.Enabled = true;

                btnPicture.BackColor = Color.RoyalBlue;
                btnPicture.ForeColor = Color.White;

                btnAccountPin.BackColor = Color.WhiteSmoke;
                btnAccountPin.ForeColor = Color.Black;

                btnAccountTnC.BackColor = Color.WhiteSmoke;
                btnAccountTnC.ForeColor = Color.Black;

                btnAccounttype.BackColor = Color.WhiteSmoke;
                btnAccounttype.ForeColor = Color.Black;

                btnDailyLimit.BackColor = Color.WhiteSmoke;
                btnDailyLimit.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnScanning.BackColor = Color.WhiteSmoke;
                btnScanning.ForeColor = Color.Black;

                btnWelcome.BackColor = Color.WhiteSmoke;
                btnWelcome.ForeColor = Color.Black;

                btnPersonalInfo.BackColor = Color.WhiteSmoke;
                btnPersonalInfo.ForeColor = Color.Black;

                return;
            }

            if (pnlPicture.Visible == true)
            {
                pnlScan.Visible = true;
                pnlPicture.Visible = false;
                pnlAccPinCode.Visible = false;
                pnlAccTnC.Visible = false;
                pnlAccType.Visible = false;
                pnlDailyAmount.Visible = false;
                pnlProccess.Visible = false;
                pnlPersonalInfo.Visible = false;
                pnlWelcome.Visible = false;

                MessageBox .Show ("Scan the documents as follow :" + Environment.NewLine +
                    " " + Environment.NewLine +
                    "ID copy" + Environment.NewLine +
                    "Profe of residence" + Environment.NewLine +
                    "Concern form if needed" + Environment.NewLine +
                    "Surety ID copy");

                btnPicture.BackColor = Color.WhiteSmoke;
                btnPicture.ForeColor = Color.Black;

                btnAccountPin.BackColor = Color.WhiteSmoke;
                btnAccountPin.ForeColor = Color.Black;

                btnAccountTnC.BackColor = Color.WhiteSmoke;
                btnAccountTnC.ForeColor = Color.Black;

                btnAccounttype.BackColor = Color.WhiteSmoke;
                btnAccounttype.ForeColor = Color.Black;

                btnDailyLimit.BackColor = Color.WhiteSmoke;
                btnDailyLimit.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnScanning.BackColor = Color.RoyalBlue;
                btnScanning.ForeColor = Color.White;

                btnWelcome.BackColor = Color.WhiteSmoke;
                btnWelcome.ForeColor = Color.Black;

                btnPersonalInfo.BackColor = Color.WhiteSmoke;
                btnPersonalInfo.ForeColor = Color.Black;

                return;
            }

            if (pnlScan.Visible == true)
            {
                pnlScan.Visible = false;
                pnlPicture.Visible = false;
                pnlAccPinCode.Visible = false;
                pnlAccTnC.Visible = false;
                pnlAccType.Visible = true;
                pnlDailyAmount.Visible = false;
                pnlProccess.Visible = false;
                pnlPersonalInfo.Visible = false;
                pnlWelcome.Visible = false;

                btnPicture.BackColor = Color.WhiteSmoke;
                btnPicture.ForeColor = Color.Black;

                btnAccountPin.BackColor = Color.WhiteSmoke;
                btnAccountPin.ForeColor = Color.Black;

                btnAccountTnC.BackColor = Color.WhiteSmoke;
                btnAccountTnC.ForeColor = Color.Black;

                btnAccounttype.BackColor = Color.RoyalBlue;
                btnAccounttype.ForeColor = Color.White;

                btnDailyLimit.BackColor = Color.WhiteSmoke;
                btnDailyLimit.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnScanning.BackColor = Color.WhiteSmoke;
                btnScanning.ForeColor = Color.Black;

                btnWelcome.BackColor = Color.WhiteSmoke;
                btnWelcome.ForeColor = Color.Black;

                btnPersonalInfo.BackColor = Color.WhiteSmoke;
                btnPersonalInfo.ForeColor = Color.Black;

                return;
            }

            if (pnlAccType.Visible == true)
            {
                pnlScan.Visible = false;
                pnlPicture.Visible = false;
                pnlAccPinCode.Visible = true;
                pnlAccTnC.Visible = false;
                pnlAccType.Visible = false;
                pnlDailyAmount.Visible = false;
                pnlProccess.Visible = false;
                pnlPersonalInfo.Visible = false;
                pnlWelcome.Visible = false;

                txtAccName.Text = txtFirstName.Text;
                txtAccLastName.Text = txtLastname.Text;
                txtAccSurname.Text = txtSurname.Text;
                picAccCust.Image = picCust.Image;
                txtAccCellNumber.Text = txtContactNo.Text;

                btnPicture.BackColor = Color.WhiteSmoke;
                btnPicture.ForeColor = Color.Black;

                btnAccountPin.BackColor = Color.RoyalBlue;
                btnAccountPin.ForeColor = Color.White;

                btnAccountTnC.BackColor = Color.WhiteSmoke;
                btnAccountTnC.ForeColor = Color.Black;

                btnAccounttype.BackColor = Color.WhiteSmoke;
                btnAccounttype.ForeColor = Color.Black;

                btnDailyLimit.BackColor = Color.WhiteSmoke;
                btnDailyLimit.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnScanning.BackColor = Color.WhiteSmoke;
                btnScanning.ForeColor = Color.Black;

                btnWelcome.BackColor = Color.WhiteSmoke;
                btnWelcome.ForeColor = Color.Black;

                btnPersonalInfo.BackColor = Color.WhiteSmoke;
                btnPersonalInfo.ForeColor = Color.Black;

                return;
            }

            if (pnlAccPinCode.Visible == true)
            {
                pnlScan.Visible = false;
                pnlPicture.Visible = false;
                pnlAccPinCode.Visible = false;
                pnlAccTnC.Visible = true;
                pnlAccType.Visible = false;
                pnlDailyAmount.Visible = false;
                pnlProccess.Visible = false;
                pnlPersonalInfo.Visible = false;
                pnlWelcome.Visible = false;

                btnPicture.BackColor = Color.WhiteSmoke;
                btnPicture.ForeColor = Color.Black;

                btnAccountPin.BackColor = Color.WhiteSmoke;
                btnAccountPin.ForeColor = Color.Black;

                btnAccountTnC.BackColor = Color.RoyalBlue;
                btnAccountTnC.ForeColor = Color.White;

                btnAccounttype.BackColor = Color.WhiteSmoke;
                btnAccounttype.ForeColor = Color.Black;

                btnDailyLimit.BackColor = Color.WhiteSmoke;
                btnDailyLimit.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnScanning.BackColor = Color.WhiteSmoke;
                btnScanning.ForeColor = Color.Black;

                btnWelcome.BackColor = Color.WhiteSmoke;
                btnWelcome.ForeColor = Color.Black;

                btnPersonalInfo.BackColor = Color.WhiteSmoke;
                btnPersonalInfo.ForeColor = Color.Black;

                return;
            }

            if (pnlAccTnC.Visible == true)
            {
                pnlScan.Visible = false;
                pnlPicture.Visible = false;
                pnlAccPinCode.Visible = false;
                pnlAccTnC.Visible = false;
                pnlAccType.Visible = false;
                pnlDailyAmount.Visible = true;
                pnlProccess.Visible = false;
                pnlPersonalInfo.Visible = false;
                pnlWelcome.Visible = false;

                btnPicture.BackColor = Color.WhiteSmoke;
                btnPicture.ForeColor = Color.Black;

                btnAccountPin.BackColor = Color.WhiteSmoke;
                btnAccountPin.ForeColor = Color.Black;

                btnAccountTnC.BackColor = Color.WhiteSmoke;
                btnAccountTnC.ForeColor = Color.Black;

                btnAccounttype.BackColor = Color.WhiteSmoke;
                btnAccounttype.ForeColor = Color.Black;

                btnDailyLimit.BackColor = Color.RoyalBlue;
                btnDailyLimit.ForeColor = Color.White;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnScanning.BackColor = Color.WhiteSmoke;
                btnScanning.ForeColor = Color.Black;

                btnWelcome.BackColor = Color.WhiteSmoke;
                btnWelcome.ForeColor = Color.Black;

                btnPersonalInfo.BackColor = Color.WhiteSmoke;
                btnPersonalInfo.ForeColor = Color.Black;

                return;
            }

            if (pnlDailyAmount.Visible == true)
            {
                picProgress.Image = global::Banking_System.Properties.Resources._31;
                pnlScan.Visible = false;
                pnlPicture.Visible = false;
                pnlAccPinCode.Visible = false;
                pnlAccTnC.Visible = false;
                pnlAccType.Visible = false;
                pnlDailyAmount.Visible = false;
                pnlProccess.Visible = true;
                pnlPersonalInfo.Visible = false;
                pnlWelcome.Visible = false;
                btnPrev.Enabled = false;

                btnPicture.BackColor = Color.WhiteSmoke;
                btnPicture.ForeColor = Color.Black;

                btnAccountPin.BackColor = Color.WhiteSmoke;
                btnAccountPin.ForeColor = Color.Black;

                btnAccountTnC.BackColor = Color.WhiteSmoke;
                btnAccountTnC.ForeColor = Color.Black;

                btnAccounttype.BackColor = Color.WhiteSmoke;
                btnAccounttype.ForeColor = Color.Black;

                btnDailyLimit.BackColor = Color.WhiteSmoke;
                btnDailyLimit.ForeColor = Color.Black;

                btnProcess.BackColor = Color.RoyalBlue;
                btnProcess.ForeColor = Color.White;

                btnScanning.BackColor = Color.WhiteSmoke;
                btnScanning.ForeColor = Color.Black;

                btnWelcome.BackColor = Color.WhiteSmoke;
                btnWelcome.ForeColor = Color.Black;

                btnPersonalInfo.BackColor = Color.WhiteSmoke;
                btnPersonalInfo.ForeColor = Color.Black;

                Save();

                return;
            }

            if (pnlProccess.Visible == true)
            {
                pnlScan.Visible = false;
                pnlPicture.Visible = false;
                pnlAccPinCode.Visible = false;
                pnlAccTnC.Visible = false;
                pnlAccType.Visible = false;
                pnlDailyAmount.Visible = false;
                pnlProccess.Visible = false;
                pnlPersonalInfo.Visible = false;
                pnlWelcome.Visible = true;
                btnNext.Enabled = false;


                btnPicture.BackColor = Color.WhiteSmoke;
                btnPicture.ForeColor = Color.Black;

                btnAccountPin.BackColor = Color.WhiteSmoke;
                btnAccountPin.ForeColor = Color.Black;

                btnAccountTnC.BackColor = Color.WhiteSmoke;
                btnAccountTnC.ForeColor = Color.Black;

                btnAccounttype.BackColor = Color.WhiteSmoke;
                btnAccounttype.ForeColor = Color.Black;

                btnDailyLimit.BackColor = Color.WhiteSmoke;
                btnDailyLimit.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnScanning.BackColor = Color.WhiteSmoke;
                btnScanning.ForeColor = Color.Black;

                btnWelcome.BackColor = Color.RoyalBlue;
                btnWelcome.ForeColor = Color.White;

                btnPersonalInfo.BackColor = Color.WhiteSmoke;
                btnPersonalInfo.ForeColor = Color.Black;

                return;
            }

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
          

            if (pnlPicture.Visible == true)
            {
                pnlScan.Visible = false;
                pnlPicture.Visible = false;
                pnlAccPinCode.Visible = false;
                pnlAccTnC.Visible = false;
                pnlAccType.Visible = false;
                pnlDailyAmount.Visible = false;
                pnlProccess.Visible = false;
                pnlPersonalInfo.Visible = true;
                pnlWelcome.Visible = false;
                btnPrev.Enabled = false;

                btnPicture.BackColor = Color.WhiteSmoke;
                btnPicture.ForeColor = Color.Black;

                btnAccountPin.BackColor = Color.WhiteSmoke;
                btnAccountPin.ForeColor = Color.Black;

                btnAccountTnC.BackColor = Color.WhiteSmoke;
                btnAccountTnC.ForeColor = Color.Black;

                btnAccounttype.BackColor = Color.WhiteSmoke;
                btnAccounttype.ForeColor = Color.Black;

                btnDailyLimit.BackColor = Color.WhiteSmoke;
                btnDailyLimit.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnScanning.BackColor = Color.WhiteSmoke;
                btnScanning.ForeColor = Color.Black;

                btnWelcome.BackColor = Color.WhiteSmoke;
                btnWelcome.ForeColor = Color.Black;

                btnPersonalInfo.BackColor = Color.RoyalBlue;
                btnPersonalInfo.ForeColor = Color.White;

                return;
            }

            if (pnlScan.Visible == true)
            {
                pnlScan.Visible = false;
                pnlPicture.Visible = true;
                pnlAccPinCode.Visible = false;
                pnlAccTnC.Visible = false;
                pnlAccType.Visible = false;
                pnlDailyAmount.Visible = false;
                pnlProccess.Visible = false;
                pnlPersonalInfo.Visible = false;
                pnlWelcome.Visible = false;

                btnPicture.BackColor = Color.RoyalBlue;
                btnPicture.ForeColor = Color.White;

                btnAccountPin.BackColor = Color.WhiteSmoke;
                btnAccountPin.ForeColor = Color.Black;

                btnAccountTnC.BackColor = Color.WhiteSmoke;
                btnAccountTnC.ForeColor = Color.Black;

                btnAccounttype.BackColor = Color.WhiteSmoke;
                btnAccounttype.ForeColor = Color.Black;

                btnDailyLimit.BackColor = Color.WhiteSmoke;
                btnDailyLimit.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnScanning.BackColor = Color.WhiteSmoke;
                btnScanning.ForeColor = Color.Black;

                btnWelcome.BackColor = Color.WhiteSmoke;
                btnWelcome.ForeColor = Color.Black;

                btnPersonalInfo.BackColor = Color.WhiteSmoke;
                btnPersonalInfo.ForeColor = Color.Black;

                return;
            }

            if (pnlAccType.Visible == true)
            {
                pnlScan.Visible = true;
                pnlPicture.Visible = false;
                pnlAccPinCode.Visible = false;
                pnlAccTnC.Visible = false;
                pnlAccType.Visible = false;
                pnlDailyAmount.Visible = false;
                pnlProccess.Visible = false;
                pnlPersonalInfo.Visible = false;
                pnlWelcome.Visible = false;

                btnPicture.BackColor = Color.WhiteSmoke;
                btnPicture.ForeColor = Color.Black;

                btnAccountPin.BackColor = Color.WhiteSmoke;
                btnAccountPin.ForeColor = Color.Black;

                btnAccountTnC.BackColor = Color.WhiteSmoke;
                btnAccountTnC.ForeColor = Color.Black;

                btnAccounttype.BackColor = Color.WhiteSmoke;
                btnAccounttype.ForeColor = Color.Black;

                btnDailyLimit.BackColor = Color.WhiteSmoke;
                btnDailyLimit.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnScanning.BackColor = Color.RoyalBlue;
                btnScanning.ForeColor = Color.White;

                btnWelcome.BackColor = Color.WhiteSmoke;
                btnWelcome.ForeColor = Color.Black;

                btnPersonalInfo.BackColor = Color.WhiteSmoke;
                btnPersonalInfo.ForeColor = Color.Black;

                return;
            }

            if (pnlAccPinCode.Visible == true)
            {
                pnlScan.Visible = false;
                pnlPicture.Visible = false;
                pnlAccPinCode.Visible = false;
                pnlAccTnC.Visible = false;
                pnlAccType.Visible = true;
                pnlDailyAmount.Visible = false;
                pnlProccess.Visible = false;
                pnlPersonalInfo.Visible = false;
                pnlWelcome.Visible = false;

                btnPicture.BackColor = Color.WhiteSmoke;
                btnPicture.ForeColor = Color.Black;

                btnAccountPin.BackColor = Color.WhiteSmoke;
                btnAccountPin.ForeColor = Color.Black;

                btnAccountTnC.BackColor = Color.WhiteSmoke;
                btnAccountTnC.ForeColor = Color.Black;

                btnAccounttype.BackColor = Color.RoyalBlue;
                btnAccounttype.ForeColor = Color.White;

                btnDailyLimit.BackColor = Color.WhiteSmoke;
                btnDailyLimit.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnScanning.BackColor = Color.WhiteSmoke;
                btnScanning.ForeColor = Color.Black;

                btnWelcome.BackColor = Color.WhiteSmoke;
                btnWelcome.ForeColor = Color.Black;

                btnPersonalInfo.BackColor = Color.WhiteSmoke;
                btnPersonalInfo.ForeColor = Color.Black;

                return;
            }

            if (pnlAccTnC.Visible == true)
            {
                pnlScan.Visible = false;
                pnlPicture.Visible = false;
                pnlAccPinCode.Visible = true;
                pnlAccTnC.Visible = false;
                pnlAccType.Visible = false;
                pnlDailyAmount.Visible = false;
                pnlProccess.Visible = false;
                pnlPersonalInfo.Visible = false;
                pnlWelcome.Visible = false;

                txtAccName.Text = txtFirstName.Text;
                txtAccLastName.Text = txtLastname.Text;
                txtAccSurname.Text = txtSurname.Text;
                picAccCust.Image = picCust.Image;
                txtAccCellNumber.Text = txtContactNo.Text;

                btnPicture.BackColor = Color.WhiteSmoke;
                btnPicture.ForeColor = Color.Black;

                btnAccountPin.BackColor = Color.RoyalBlue;
                btnAccountPin.ForeColor = Color.White;

                btnAccountTnC.BackColor = Color.WhiteSmoke;
                btnAccountTnC.ForeColor = Color.Black;

                btnAccounttype.BackColor = Color.WhiteSmoke;
                btnAccounttype.ForeColor = Color.Black;

                btnDailyLimit.BackColor = Color.WhiteSmoke;
                btnDailyLimit.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnScanning.BackColor = Color.WhiteSmoke;
                btnScanning.ForeColor = Color.Black;

                btnWelcome.BackColor = Color.WhiteSmoke;
                btnWelcome.ForeColor = Color.Black;

                btnPersonalInfo.BackColor = Color.WhiteSmoke;
                btnPersonalInfo.ForeColor = Color.Black;

                return;
            }

            if (pnlDailyAmount.Visible == true)
            {
                pnlScan.Visible = false;
                pnlPicture.Visible = false;
                pnlAccPinCode.Visible = false;
                pnlAccTnC.Visible = true;
                pnlAccType.Visible = false;
                pnlDailyAmount.Visible = false;
                pnlProccess.Visible = false;
                pnlPersonalInfo.Visible = false;
                pnlWelcome.Visible = false;

                btnPicture.BackColor = Color.WhiteSmoke;
                btnPicture.ForeColor = Color.Black;

                btnAccountPin.BackColor = Color.WhiteSmoke;
                btnAccountPin.ForeColor = Color.Black;

                btnAccountTnC.BackColor = Color.RoyalBlue;
                btnAccountTnC.ForeColor = Color.White;

                btnAccounttype.BackColor = Color.WhiteSmoke;
                btnAccounttype.ForeColor = Color.Black;

                btnDailyLimit.BackColor = Color.WhiteSmoke;
                btnDailyLimit.ForeColor = Color.Black;

                btnProcess.BackColor = Color.WhiteSmoke;
                btnProcess.ForeColor = Color.Black;

                btnScanning.BackColor = Color.WhiteSmoke;
                btnScanning.ForeColor = Color.Black;

                btnWelcome.BackColor = Color.WhiteSmoke;
                btnWelcome.ForeColor = Color.Black;

                btnPersonalInfo.BackColor = Color.WhiteSmoke;
                btnPersonalInfo.ForeColor = Color.Black;

                return;
            }


        }

        private void pnlAccPinCode_Enter(object sender, EventArgs e)
        {
            
        }

    }
}
