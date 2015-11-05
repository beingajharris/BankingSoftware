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
    public partial class RemoteBank : Form
    {
        public RemoteBank()
        {
            InitializeComponent();
        }

        private void RemoteBank_Load(object sender, EventArgs e)
        {
            axAcroPDF1.src = @"C:\Users\SURPRISEE\Documents\School Stuff\CREDIT REHABILITATION PACK_LP101325_20140919103121.pdf";
        }
    }
}
